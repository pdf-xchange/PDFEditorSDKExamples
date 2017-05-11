using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFXEdit;

namespace PDFXEditCtrl
{
	public partial class PreviewCtrl: UserControl
	{
		private IPXV_Inst Inst = null;
		public IPXV_PagesPreviewCtl pagesPreviewCtl = null;
		private IUIX_Obj parentBase = null;
		private IUIX_Obj spScrollContainerObj = null;

		public PreviewCtrl()
		{
			InitializeComponent();
		}

		public void LoadInst(IPXV_Inst inst)
		{
			Inst = inst;
			IUIX_Inst uiInst = (IUIX_Inst)Inst.GetExtension("UIX");
			{
				Rectangle rcCl = ClientRectangle;
				tagRECT rc;
				rc.left = rcCl.Left;
				rc.top = rcCl.Top;
				rc.right = rcCl.Right;
				rc.bottom = rcCl.Bottom;

				UIX_CreateObjParams cp2 = new UIX_CreateObjParams();
				cp2.nStdClass = (int)UIX_StdClasses.UIX_StdClass_Blank;
				cp2.hWndParent = (uint)Handle.ToInt32();
				cp2.rc = rc;
				parentBase = uiInst.CreateObj(ref cp2);
			}

			{
				Rectangle rcCl = ClientRectangle;
				tagRECT rc;
				rc.left = rcCl.Left;
				rc.top = rcCl.Top;
				rc.right = rcCl.Right;
				rc.bottom = rcCl.Bottom;

				UIX_CreateObjParams cp = new UIX_CreateObjParams();
				cp.nStdClass = (int)UIX_StdClasses.UIX_StdClass_Layout;
				cp.pParent = parentBase;
				cp.rc = rc;
				IUIX_Obj obj = null;
				spScrollContainerObj = uiInst.CreateScrollableObj(ref cp, (long)UIX_ScrollStyleFlags.UIX_ScrollStyle_Horz | (long)UIX_ScrollStyleFlags.UIX_ScrollStyle_Vert, out obj);

				IntPtr outPtr;
				obj.QueryImpl(typeof(PDFXEdit.IUIX_ScrollContainer).GUID, null, out outPtr);
				PDFXEdit.IUIX_ScrollContainer spScrollContainer = (PDFXEdit.IUIX_ScrollContainer)System.Runtime.InteropServices.Marshal.GetObjectForIUnknown(outPtr);
				spScrollContainer.Client = spScrollContainerObj;
			}

			{
				Rectangle rcCl = ClientRectangle;
				tagRECT rc;
				rc.left = rcCl.Left;
				rc.top = rcCl.Top;
				rc.right = rcCl.Right;
				rc.bottom = rcCl.Bottom;

				pagesPreviewCtl = Inst.CreatePagesPreviewCtl(spScrollContainerObj, rc, "ctrl.01",
					(long)PXV_PagesPreviewStyleFlags.PXV_PagesPreviewStyle_InteractiveLayout,
					(long)UIX_ScrollStyleFlags.UIX_ScrollStyle_Horz | (long)UIX_ScrollStyleFlags.UIX_ScrollStyle_Vert, true);
			}
		}

		private void PreviewCtrl_Resize(object sender, EventArgs e)
		{
/*
			if (parentBase != null)
			{
				Rectangle rcCl = ClientRectangle;
				tagRECT rc;
				rc.left = rcCl.Left;
				rc.top = rcCl.Top;
				rc.right = rcCl.Right;
				rc.bottom = rcCl.Bottom;
				parentBase.set_Rect(ref rc);
				spScrollContainerObj.set_Rect(ref rc);
				pagesPreviewCtl.Obj.set_Rect(ref rc);
				pagesPreviewCtl.Obj.Redraw(true);
			}
*/
		}
	}
}
