using CustomTool.Extensions;
using PDFXEdit;
using System.Collections.Generic;

namespace CustomTool
{
    public class PageRegions
    {
        public int PageIndex { get; set; }
        public List<PXC_Rect> Rects { get; set; } = new List<PXC_Rect>();

        public int HitTest(PXC_Point pt, double ctlPtSize, out HitTestCode ht)
        {
            ht = HitTestCode.None;
            foreach (var rc in Rects)
            {
                var rcTemp = rc;
                rcTemp.Inflate(ctlPtSize);
                if (!rcTemp.ContainPoint(pt))
                    continue;
                // LeftTop
                PXC_Rect cp;
                cp = CalcAssistant.CalcCtlPtRect(rc.left, rc.top, ctlPtSize);
                if (cp.ContainPoint(pt))
                {
                    ht = HitTestCode.LT;
                    return Rects.FindIndex(x => x.Equal(rc));
                }

                // RightTop
                cp = CalcAssistant.CalcCtlPtRect(rc.right, rc.top, ctlPtSize);
                if (cp.ContainPoint(pt))
                {
                    ht = HitTestCode.RT;
                    return Rects.FindIndex(x => x.Equal(rc));
                }

                // RightBottom
                cp = CalcAssistant.CalcCtlPtRect(rc.right, rc.bottom, ctlPtSize);
                if (cp.ContainPoint(pt))
                {
                    ht = HitTestCode.RB;
                    return Rects.FindIndex(x => x.Equal(rc));
                }

                // LeftBottom
                cp = CalcAssistant.CalcCtlPtRect(rc.left, rc.bottom, ctlPtSize);
                if (cp.ContainPoint(pt))
                {
                    ht = HitTestCode.LB;
                    return Rects.FindIndex(x => x.Equal(rc));
                }

                if (rc.ContainPoint(pt))
                {
                    ht = HitTestCode.Inside;
                    return Rects.FindIndex(x => x.Equal(rc));
                }
            }
            return -1;
        }

        public bool Equal(PageRegions obj)
        {
            if ((obj.PageIndex != this.PageIndex) || (obj.Rects.Count != this.Rects.Count))
                return false;
            for (int i = 0; i < obj.Rects.Count; i++)
            {
                if (!obj.Rects[i].Equal(this.Rects[i]))
                    return false;
            }
            return true;
        }
    }
}
