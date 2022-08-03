using PDFXEdit;

namespace CustomTool
{
    public enum HitTestCode
    {
        None = 0,
        //
        LT,
        RT,
        RB,
        LB,
        //
        Inside,
    };

    public static class CalcAssistant
    {
        public static PXC_Rect CalcCtlPtRect(double x, double y, double size)
        {
            PXC_Rect r;
            r.left = x - size / 2;
            r.right = r.left + size;
            r.top = y + size / 2;
            r.bottom = r.top - size;
            return r;
        }

        public static HitTestCode GetCursorFromHT(HitTestCode ht, int rotation)
        {
            if ((ht == HitTestCode.None) || (ht == HitTestCode.Inside))
                return ht;
            int rotationFactor = (((rotation % 360) + 360) / 90) & 3;
            rotationFactor %= 4;
            int res = ((int)ht - (int)HitTestCode.LT) + rotationFactor;
            res = (int)HitTestCode.LT + (res % 4);
            return (HitTestCode)res;
        }
    }
}
