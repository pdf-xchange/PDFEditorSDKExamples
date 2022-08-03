using PDFXEdit;
using System;

namespace CustomTool.Extensions
{
    public static class RectEx
    {
        public static void Inflate(this ref PXC_Rect rc, double dxy)
        {
            rc.left -= dxy;
            rc.right += dxy;
            rc.top += dxy;
            rc.bottom -= dxy;
        }

        public static void Inflate(this ref tagRECT rc, int dxy)
        {
            rc.left -= dxy;
            rc.right += dxy;
            rc.top -= dxy;
            rc.bottom += dxy;
        }

        public static bool Equal(this PXC_Rect source, PXC_Rect rect)
        {
            return (source.left == rect.left) && (source.right == rect.right) && (source.top == rect.top) && (source.bottom == rect.bottom);
        }

        public static void FixupByBBox(this ref PXC_Rect rect, PXC_Rect bbox)
        {
            double dx = rect.right - bbox.right;
            if (dx > 0)
            {
                rect.left -= dx;
                rect.right -= dx;
            }
            dx = rect.left - bbox.left;
            if (dx < 0)
            {
                rect.left -= dx;
                rect.right -= dx;
            }
            double dy = rect.bottom - bbox.bottom;
            if (dy < 0)
            {
                rect.top -= dy;
                rect.bottom -= dy;
            }
            dy = rect.top - bbox.top;
            if (dy > 0)
            {
                rect.top -= dy;
                rect.bottom -= dy;
            }
        }

        public static void Offset(this ref tagRECT rc, int dx, int dy)
        {
            rc.left += dx;
            rc.right += dx;
            rc.top += dy;
            rc.bottom += dy;
        }

        public static void Offset(this ref PXC_Rect rc, double dx, double dy)
        {
            rc.left += dx;
            rc.right += dx;
            rc.top += dy;
            rc.bottom += dy;
        }

        public static void Clear(this ref PXC_Rect rc)
        {
            rc.left = rc.right = rc.top = rc.bottom = 0;
        }

        public static void Clear(this ref tagRECT rc)
        {
            rc.left = rc.right = rc.top = rc.bottom = 0;
        }

        public static bool IsEmpty(this ref PXC_Rect rc)
        {
            return (((rc.right - rc.left) <= 0) || ((rc.top - rc.bottom) <= 0));
        }

        public static bool IsEmpty(this ref tagRECT rc)
        {
            return (((rc.right - rc.left) <= 0) || ((rc.bottom - rc.top) <= 0));
        }

        public static PXC_Rect Intersection(this PXC_Rect source, PXC_Rect rect)
        {
            PXC_Rect res;
            res.left = Math.Max(source.left, rect.left);
            res.right = Math.Min(source.right, rect.right);
            if (res.right < res.left)
                res.right = res.left;
            res.bottom = Math.Max(source.bottom, rect.bottom);
            res.top = Math.Min(source.top, rect.top);
            if (res.top < res.bottom)
                res.top = res.bottom;
            return res;
        }

        public static tagRECT Union(this tagRECT source, tagRECT rect)
        {
            tagRECT res;
            res.left = Math.Min(source.left, rect.left);
            res.right = Math.Max(source.right, rect.right);
            res.bottom = Math.Max(source.bottom, rect.bottom);
            res.top = Math.Min(source.top, rect.top);
            return res;
        }

        public static bool ContainPoint(this tagRECT rc, tagPOINT pt)
        {
            return (rc.left <= pt.x && pt.x <= rc.right) && (rc.top <= pt.y && pt.y <= rc.bottom);
        }

        public static bool ContainPoint(this PXC_Rect rc, PXC_Point pt)
        {
            return ((rc.left <= pt.x) && (pt.x <= rc.right)) && ((rc.bottom <= pt.y) && (pt.y <= rc.top));
        }
    }
}
