using PDFXEdit;

namespace CustomTool.Extensions
{
    public static class PagesViewEx
    {
        public static int CalcCtlPtSize(this IPXV_PagesView pView)
        {
            int s = pView.Obj.Px96toPx(8);
            s += (s % 2);
            return s;
        }
    }
}
