using CustomTool.Extensions;
using PDFXEdit;
using System.Drawing;

namespace CustomTool
{
    public class DrawHighlightOnPagesCallback : IPXV_PagesViewDrawCallback
    {
        private readonly PagesMarkupTool Tool;
        private readonly IUIX_Brush Brush;
        private readonly IUIX_Pen Pen;
        private readonly IUIX_Brush BrushCtlPt;
        private readonly IUIX_Pen PenCtlPt;

        public DrawHighlightOnPagesCallback(PagesMarkupTool pTool)
        {
            Tool = pTool;
            var uiInst = pTool._Inst.GetExtension("UIX") as IUIX_Inst;
            Brush = uiInst?.CreateNewBrush();
            Pen = uiInst?.CreateNewPen();
            Brush.Color0 = (uint)ColorTranslator.ToWin32(Color.Blue) | 0xFF000000;
            Brush.Opacity = 0.1;
            Pen.Brush.Color0 = Brush.Color0;
            Pen.Brush.Opacity = 0.5;
            Pen.Inside = true;

            BrushCtlPt = uiInst.CreateNewBrush();
            PenCtlPt = uiInst.CreateNewPen();
            BrushCtlPt.Color0 = (uint)ColorTranslator.ToWin32(Color.BlanchedAlmond) | 0xFF000000;
            PenCtlPt.Brush.Color0 = (uint)ColorTranslator.ToWin32(Color.Black) | 0xFF000000;
            PenCtlPt.Inside = true;
        }

        public void Start(IPXV_Document pDoc) => pDoc?.RegisterPagesViewDrawCallback(PXV_PagesViewDrawStage.PXV_PagesViewDraw_Foreground, this, 0);

        public void Stop(IPXV_Document pDoc) => pDoc?.UnregisterPagesViewDrawCallback(PXV_PagesViewDrawStage.PXV_PagesViewDraw_Foreground, this);

        void DrawCtlPt(IUIX_RenderContext pRC, int x, int y, int ctlPtSizePx, tagRECT clipRect, int roundRadius)
        {
            tagRECT ctlPtRect;
            int s = ctlPtSizePx / 2;

            ctlPtRect.left = x - s;
            ctlPtRect.right = x + s;
            ctlPtRect.top = y - s;
            ctlPtRect.bottom = y + s;

            pRC.DrawRoundRect(ref ctlPtRect, BrushCtlPt, PenCtlPt, roundRadius, roundRadius, roundRadius, roundRadius, clipRect);
        }

        // PDFXEdit.IPXV_PagesViewDrawCallback
        public void OnDrawPagesView(IPXV_PagesView pView, PXV_PagesViewDrawStage nStage, IUIX_RenderContext pRC, IPXV_PagesLayoutRegions pPageRegions)
        {
            uint cnt = pPageRegions.Count;

            IPXV_PagesLayoutManager layout = pView.Layout;

            int ctlPtSizePx = pView.CalcCtlPtSize();
            tagRECT clipRect = pRC.GetUpdateRegion(out _, 0);

            int roundRadius = pView.Obj.Px96toPx(2);

            for (uint i = 0; i < cnt; i++)
            {
                PXV_PagesLayoutRegion rgn = pPageRegions[i];
                foreach (var pr in Tool.PageRegions)
                {
                    if ((uint)pr.PageIndex != rgn.nPage)
                        continue;

                    foreach (var rc in pr.Rects)
                    {
                        var rect = layout.PageRectToDeviceRect((uint)pr.PageIndex, rc, true);

                        pRC.DrawRect(rect, Brush, Pen, clipRect);

                        DrawCtlPt(pRC, rect.left, rect.top, ctlPtSizePx, clipRect, roundRadius);
                        DrawCtlPt(pRC, rect.right, rect.top, ctlPtSizePx, clipRect, roundRadius);
                        DrawCtlPt(pRC, rect.right, rect.bottom, ctlPtSizePx, clipRect, roundRadius);
                        DrawCtlPt(pRC, rect.left, rect.bottom, ctlPtSizePx, clipRect, roundRadius);
                    }
                }
            }

            if (Tool.NewPageIndex >= 0)
            {
                tagRECT rect = layout.PageRectToDeviceRect((uint)Tool.NewPageIndex, Tool.NewPageRect, true);
                pRC.DrawRect(rect, Brush, Pen, clipRect);
            }
        }
    }
}
