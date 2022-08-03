using CustomTool.Extensions;
using PDFXEdit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
public enum MSG
{
    WM_MOUSEMOVE = 0x0200,
    WM_LBUTTONDOWN = 0x0201,
    WM_LBUTTONUP = 0x0202,
};
namespace CustomTool
{
    public class PagesMarkupTool : IPXV_Tool
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public uint Features { get; }
        public List<PageRegions> PageRegions { get; set; }

        //edit existing
        public int EditRegionIndex { get; set; } // index of element in PageRegions
        public int EditPageRectIndex { get; set; }
        public PXC_Point EditCtlPtOffset;
        public HitTestCode EditHT { get; set; }

        //new creation
        public int NewPageIndex { get; set; }
        public PXC_Rect NewPageRect;

        //new||edit
        private PXC_Point CurrOriginPoint;
        private PXC_Rect CurrPageBBox;

        public List<int> Cursors { get; set; }

        private readonly MainForm _Form;
        public readonly IPXV_Inst _Inst;
        private IPXV_Document _Doc;

        private readonly IMathHelper _Math;
        private readonly DrawHighlightOnPagesCallback _DrawPagesCallback;

        public PagesMarkupTool(MainForm form)
        {
            _Form = form;
            _Inst = _Form.pdfCtl.Inst;
            Name = "Pages Markup Tool";
            ID = _Inst.Str2ID("pagesMarkupTool");
            _Math = (_Inst.GetExtension("AUX") as IAUX_Inst)?.MathHelper;
            PageRegions = new List<PageRegions>();
            NewPageIndex = -1;
            EditHT = HitTestCode.None;
            EditPageRectIndex = -1;
            EditRegionIndex = -1;

            Cursors = new List<int>()
            {
                (int)UIX_StdCursor.UIX_StdCursor_Arrow,     // None
                (int)UIX_StdCursor.UIX_StdCursor_SizeNWSE,  // LT
	            (int) UIX_StdCursor.UIX_StdCursor_SizeNESW, // RT
	            (int)UIX_StdCursor.UIX_StdCursor_SizeNWSE,  // RB
	            (int)UIX_StdCursor.UIX_StdCursor_SizeNESW,  // LB
	            (int)UIX_StdCursor.UIX_StdCursor_SizeAll   // Inside
            };

            _DrawPagesCallback = new DrawHighlightOnPagesCallback(this);
        }
        public bool get_IsEnabled(IPXV_PagesView pView) => true;
        public bool get_IsExclusive(IPXV_Document pDoc) => true;

        public void OnActivated(IPXV_Document pDoc, uint nFlags)
        {
            if ((_Doc != null) && (_Doc != pDoc))
                PageRegions.Clear();

            _Doc = pDoc;

            _DrawPagesCallback?.Start(pDoc);
        }

        public void OnDeactivated(IPXV_Document pDoc, uint nFlags)
        {
            if ((_Doc != null) && (_Doc == pDoc))
            {
                if ((PageRegions.Count != 0) || (NewPageIndex >= 0))
                    pDoc.ActiveView?.PagesView?.Obj?.Redraw();

                StopEditRect(null, null);
                PageRegions.Clear();
                _Doc = null;
            }

            if ((pDoc != null) && (_DrawPagesCallback != null))
                _DrawPagesCallback.Stop(pDoc);

            _Form?.OnCustomRegionsChanged();
        }

        public void StopEditRect(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            if (pEvent != null)
                UpdateEditRect(pView, pEvent.get_Pos());

            EditRegionIndex = -1;
            EditPageRectIndex = -1;
            EditCtlPtOffset.x = EditCtlPtOffset.y = 0;

        }

        private void UpdateEditRect(IPXV_PagesView pView, tagPOINT pt)
        {
            if (pView == null)
                return;
            if ((EditRegionIndex < 0) || (EditRegionIndex >= PageRegions.Count))
                return;

            IPXV_PagesLayoutManager layout = pView.Layout;

            PageRegions pageRegions = PageRegions[EditRegionIndex];
            int pageIndex = pageRegions.PageIndex;

            PXC_Point pagePt = layout.DevicePointToPagePoint((uint)pageIndex, pt, true);

            pagePt.x -= EditCtlPtOffset.x;
            pagePt.y -= EditCtlPtOffset.y;

            PXC_Rect rect = pageRegions.Rects[EditPageRectIndex];
            PXC_Rect oldRect = rect;

            if (EditHT == HitTestCode.Inside)
            {
                rect.Offset(pagePt.x - rect.left, pagePt.y - rect.top);
                rect.FixupByBBox(CurrPageBBox);
            }
            else
            {
                rect.left = Math.Min(pagePt.x, CurrOriginPoint.x);
                rect.right = Math.Max(pagePt.x, CurrOriginPoint.x);
                rect.top = Math.Max(pagePt.y, CurrOriginPoint.y);
                rect.bottom = Math.Min(pagePt.y, CurrOriginPoint.y);

                rect = rect.Intersection(CurrPageBBox);
            }

            PageRegions[EditRegionIndex].Rects[EditPageRectIndex] = rect;

            RedrawPageRect(pView, pageIndex, oldRect, true);
            RedrawPageRect(pView, pageIndex, rect, true);
        }

        void RedrawPageRect(IPXV_PagesView pView, int pageIndex, PXC_Rect rect, bool bWithCtlPt = false)
        {
            if (pView == null)
                return;
            var DeviceRect = pView.Layout.PageRectToDeviceRect((uint)pageIndex, rect, true);
            if (bWithCtlPt)
                DeviceRect.Inflate(pView.CalcCtlPtSize());
            pView.Obj.RedrawRect(DeviceRect);
        }

        public void OnProcessViewEvent(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            switch (pEvent.Code)
            {
                case (int)MSG.WM_LBUTTONDOWN:
                    OnMouseDown(pView, pEvent);
                    break;
                case (int)MSG.WM_LBUTTONUP:
                    OnMouseUp(pView, pEvent);
                    break;
                case (int)MSG.WM_MOUSEMOVE:
                    OnMouseMove(pView, pEvent);
                    break;
                case (int)UIX_EventCodes.e_MouseCaptureLost:
                    OnMouseCaptureLost(pView, pEvent);
                    break;
                case (int)UIX_EventCodes.e_ScrollChanged:
                    OnScrollChanged(pView, pEvent);
                    break;
            }
        }

        private void OnScrollChanged(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            // to additionally redraw regions which were invalidated by control-points which are outside of page-rect
            var obj = pView.Obj;
            obj.GetScrollInfo(out tagPOINT newPos, out tagSIZE allSize);

            IPXV_PagesLayoutManager layout = pView.Layout;

            var oldPos = (tagPOINT)Marshal.PtrToStructure((IntPtr)pEvent.Param1, typeof(tagPOINT));

            int dx = newPos.x - oldPos.x;
            int dy = newPos.y - oldPos.y;

            if (dx != 0 || dy != 0)
            {
                int ctlPtSizePx = pView.CalcCtlPtSize();
                tagRECT pageRect;
                tagRECT t1, t2;
                tagRECT bbox;
                foreach (PageRegions pr in PageRegions)
                {
                    int pageIndex = pr.PageIndex;
                    bbox.left = bbox.right = bbox.top = bbox.bottom = 0;
                    foreach (PXC_Rect r in pr.Rects)
                    {
                        tagRECT rc = layout.PageRectToDeviceRect((uint)pageIndex, r, true);
                        if (bbox.IsEmpty())
                            bbox = rc;
                        else
                            bbox = rc.Union(bbox);
                    }

                    pageRect = layout.GetPageRect((uint)pageIndex);

                    bbox.Inflate(ctlPtSizePx);

                    if (bbox.left < pageRect.left)
                    {
                        t1 = bbox;
                        t1.right = pageRect.left;
                        t2 = t1;
                        t2.Offset(dx, dy);
                        t1 = t1.Union(t2);
                        obj.RedrawRect(t1);
                    }
                    if (bbox.top < pageRect.top)
                    {
                        t1 = bbox;
                        t1.bottom = pageRect.top;
                        t2 = t1;
                        t2.Offset(dx, dy);
                        t1 = t1.Union(t2);
                        obj.RedrawRect(t1);
                    }
                    if (pageRect.right < bbox.right)
                    {
                        t1 = bbox;
                        t1.left = pageRect.right;
                        t2 = t1;
                        t2.Offset(dx, dy);
                        t1 = t1.Union(t2);
                        obj.RedrawRect(t1);
                    }
                    if (pageRect.bottom < bbox.bottom)
                    {
                        t1 = bbox;
                        t1.top = pageRect.bottom;
                        t2 = t1;
                        t2.Offset(dx, dy);
                        t1 = t1.Union(t2);
                        obj.RedrawRect(t1);
                    }
                }
            }
        }

        private void OnMouseCaptureLost(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            StopNewRectCreation(pView, null);
            StopEditRect(pView, null);
        }

        private void StopNewRectCreation(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            if (NewPageIndex < 0)
                return;

            bool bCancel = pEvent == null;

            int pageIndex = NewPageIndex;
            PXC_Rect rect = NewPageRect;

            NewPageRect.Clear();
            NewPageIndex = -1;

            tagRECT r = pView.Layout.PageRectToDeviceRect((uint)pageIndex, rect, true);
            if (r.IsEmpty())
                return;

            RedrawPageRect(pView, pageIndex, rect, true);

            if (bCancel)
                return;

            foreach (PageRegions pr in PageRegions)
            {
                if (pr.PageIndex == pageIndex)
                {
                    pr.Rects.Add(rect);
                    return;
                }
            }

            PageRegions npr = new PageRegions
            {
                PageIndex = pageIndex
            };
            npr.Rects.Add(rect);

            PageRegions.Add(npr);

            _Form.OnCustomRegionsChanged();
        }

        public int HitTestPageRegions(int pageIndex, PXC_Point pt, double ctlPtSize, out int rectIndex, out HitTestCode ht)
        {
            rectIndex = -1;
            ht = HitTestCode.None;
            foreach (var pr in PageRegions)
            {
                if (pr.PageIndex == pageIndex)
                {
                    rectIndex = pr.HitTest(pt, ctlPtSize, out ht);
                    if (rectIndex >= 0)
                        return PageRegions.FindIndex(x => x.Equal(pr));
                }
            }
            return -1;
        }

        private void OnMouseMove(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            tagPOINT pt = pEvent.get_Pos();
            IPXV_PagesLayoutManager layout = pView.Layout;

            if (!pView.Obj.HasMouseCapture)
            {
                // update cursor
                int nCursor = Cursors[0]; // arrow
                do
                {
                    int pageIndex = layout.GetNearestPage(pt, false);
                    if (pageIndex < 0)
                        break;

                    PXC_Point pagePt = layout.DevicePointToPagePoint((uint)pageIndex, pt, true);

                    PXC_Matrix v2p = layout.GetDeviceToPageMatrix((uint)pageIndex, true);
                    int ctlPtSizePx = pView.CalcCtlPtSize();
                    double v2ps = _Math.Matrix_GetScale(v2p);
                    double ctlPtSize = ctlPtSizePx * v2ps;

                    if (HitTestPageRegions(pageIndex, pagePt, ctlPtSize, out int pageRectIndex, out HitTestCode ht) < 0)
                        break;

                    ht = CalcAssistant.GetCursorFromHT(ht, layout.ViewRotation + pView.Doc.CoreDoc.Pages[(uint)pageIndex].Rotation);
                    nCursor = Cursors[(int)ht];
                }
                while (false);

                pView.Cursor = nCursor;
                pEvent.Handled = true;

                return;
            }

            if (NewPageIndex >= 0) // new
            {
                pEvent.Handled = true;

                PXC_Rect oldRect = NewPageRect;

                PXC_Point pagePt = layout.DevicePointToPagePoint((uint)NewPageIndex, pt, true);
                NewPageRect.left = Math.Min(pagePt.x, CurrOriginPoint.x);
                NewPageRect.right = Math.Max(pagePt.x, CurrOriginPoint.x);
                NewPageRect.top = Math.Max(pagePt.y, CurrOriginPoint.y);
                NewPageRect.bottom = Math.Min(pagePt.y, CurrOriginPoint.y);

                NewPageRect = NewPageRect.Intersection(CurrPageBBox);

                RedrawPageRect(pView, NewPageIndex, oldRect);
                RedrawPageRect(pView, NewPageIndex, NewPageRect);
            }
            else if (EditRegionIndex >= 0) // edit
            {
                pEvent.Handled = true;

                UpdateEditRect(pView, pt);
            }
        }

        private void OnMouseUp(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            StopNewRectCreation(pView, pEvent);
            StopEditRect(pView, pEvent);

            pView.Obj.ReleaseMouse();
        }



        public void StartEditRect(IPXV_PagesView pView, int editPageIndex, int editPageRectIndex, tagPOINT pt, PXC_Point pagePt, HitTestCode ht)
        {
            StopEditRect(pView, null);

            EditRegionIndex = editPageIndex;
            EditPageRectIndex = editPageRectIndex;
            EditHT = ht;

            PXC_Rect rect = PageRegions[editPageIndex].Rects[editPageRectIndex];

            PXC_Point startPt = pagePt;
            switch (EditHT)
            {
                case HitTestCode.LT:
                    startPt.x = rect.left;
                    startPt.y = rect.top;
                    break;
                case HitTestCode.RT:
                    startPt.x = rect.right;
                    startPt.y = rect.top;
                    break;
                case HitTestCode.RB:
                    startPt.x = rect.right;
                    startPt.y = rect.bottom;
                    break;
                case HitTestCode.LB:
                    startPt.x = rect.left;
                    startPt.y = rect.bottom;
                    break;
                case HitTestCode.Inside:
                    startPt.x = rect.left;
                    startPt.y = rect.top;
                    break;
            };

            EditCtlPtOffset.x = pagePt.x - startPt.x;
            EditCtlPtOffset.y = pagePt.y - startPt.y;

            startPt.x = startPt.y = 0;
            switch (EditHT)
            {
                case HitTestCode.LT:
                    startPt.x = rect.right;
                    startPt.y = rect.bottom;
                    break;
                case HitTestCode.RT:
                    startPt.x = rect.left;
                    startPt.y = rect.bottom;
                    break;
                case HitTestCode.RB:
                    startPt.x = rect.left;
                    startPt.y = rect.top;
                    break;
                case HitTestCode.LB:
                    startPt.x = rect.right;
                    startPt.y = rect.top;
                    break;
            };

            CurrOriginPoint = startPt;
            CurrPageBBox = pView.Doc.CoreDoc.Pages[(uint)editPageIndex].get_Box(PXC_BoxType.PBox_ViewBox);

            UpdateEditRect(pView, pt);
        }
        public void StartNewRectCreation(IPXV_PagesView pView, int pageIndex, PXC_Point pagePt)
        {
            StopEditRect(pView, null);
            StopNewRectCreation(pView, null);

            NewPageRect.Clear();

            NewPageIndex = pageIndex;
            CurrOriginPoint = pagePt;
            CurrPageBBox = pView.Doc.CoreDoc.Pages[(uint)pageIndex].get_Box(PXC_BoxType.PBox_ViewBox);
        }

        private void OnMouseDown(IPXV_PagesView pView, IUIX_Event pEvent)
        {
            tagPOINT pt = pEvent.get_Pos();

            IPXV_PagesLayoutManager layout = pView.Layout;

            int pageIndex = layout.GetNearestPage(pt, false);
            if (pageIndex < 0)
                return;

            PXC_Matrix v2p = layout.GetDeviceToPageMatrix((uint)pageIndex, true);
            PXC_Point pagePt = layout.DevicePointToPagePoint((uint)pageIndex, pt, true);
            int ctlPtSizePx = pView.CalcCtlPtSize();
            double v2ps = _Math.Matrix_GetScale(v2p);
            double ctlPtSize = ctlPtSizePx * v2ps;

            HitTestCode ht;
            int editPageRectIndex;
            int editPageIndex = HitTestPageRegions(pageIndex, pagePt, ctlPtSize, out editPageRectIndex, out ht);

            if (editPageIndex >= 0)
            {
                // edit existing
                StartEditRect(pView, editPageIndex, editPageRectIndex, pt, pagePt, ht);
            }
            else
            {
                // create new
                tagRECT rcPage = layout.GetPageRect((uint)pageIndex);

                if (!rcPage.ContainPoint(pt))
                    return;

                StartNewRectCreation(pView, pageIndex, pagePt);
            }

            pView.Obj.CaptureMouse();
        }

        public bool CanActivateForDocument(IPXV_Document pDoc) => true;

        public void ProcessSelRegions()
        {
            if ((_Doc == null) || (PageRegions.Count == 0))
                return;

            var ixcInst = _Inst.GetExtension("IXC") as IIXC_Inst;

            string destFolder = _Inst.GetStdFolder(PXV_StdFolderID.PXV_StdFolder_Documents, true, true);
            destFolder += "\\SampleImages";
            System.IO.Directory.CreateDirectory(destFolder);

            int dpi = 300;

            int imageIndex = 0;
            bool OpenFolder = false;


            foreach (var pr in PageRegions)
            {
                var pageIndex = pr.PageIndex;
                IPXC_Page page = _Doc?.CoreDoc?.Pages[(uint)pageIndex];
                foreach (var rect in pr.Rects)
                {
                    double width = rect.right - rect.left;
                    double height = rect.top - rect.bottom;

                    int wpx = (int)Math.Round(width * dpi / 72.0);
                    int hpx = (int)Math.Round(height * dpi / 72.0);

                    PXC_Point fromA;
                    PXC_Point fromB;
                    PXC_Point fromC;

                    PXC_Point toA;
                    PXC_Point toB;
                    PXC_Point toC;

                    fromA.x = rect.left;
                    fromA.y = rect.bottom;
                    fromB.x = rect.left;
                    fromB.y = rect.top;
                    fromC.x = rect.right;
                    fromC.y = rect.bottom;

                    tagRECT irect;
                    irect.left = 0;
                    irect.top = 0;
                    irect.right = wpx;
                    irect.bottom = hpx;

                    toA.x = irect.left;
                    toA.y = irect.bottom;
                    toB.x = irect.left;
                    toB.y = irect.top;
                    toC.x = irect.right;
                    toC.y = irect.bottom;

                    // page-to-image matrix
                    PXC_Matrix p2i = _Math.Matrix_ParlToParl(ref fromA, ref fromB, ref fromC, ref toA, ref toB, ref toC);

                    IIXC_Page imgPage = ixcInst.Page_CreateEmpty((uint)wpx, (uint)hpx, IXC_PageFormat.PageFormat_8RGB, 0xFFFFFFFF);

                    page.DrawToIXCPage(imgPage, irect, p2i);
                    imgPage.FmtInt[(uint)IXC_FormatParametersIDS.FP_ID_FORMAT] = (uint)IXC_ImageFileFormatIDs.FMT_PNG_ID;

                    IIXC_Image img = ixcInst.CreateEmptyImage();
                    img.InsertPage(imgPage);

                    string imgName = destFolder + "\\Page-" + (pageIndex + 1) + ", Image-" + (imageIndex + 1) + ".png";

                    img.Save(imgName, IXC_CreationDisposition.CreationDisposition_Overwrite);
                    if (!OpenFolder)
                        OpenFolder = true;
                    imageIndex++;
                }
            }

            if (OpenFolder)
                Process.Start(destFolder);
        }

        public void OnFinalize()
        {
            //throw new NotImplementedException();
        }
    }
}
