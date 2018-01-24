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
		public IPXV_PagesPreviewCtl pagesPreviewCtl = null;

		private IPXV_Inst Inst = null;
		private IUIX_Obj parentBase = null;
		private PDFXEdit.IPXC_Document m_doc = null;


		public PreviewCtrl()
		{
			InitializeComponent();
		}

		public void LoadInst(IPXV_Inst inst)
		{
			Inst = inst;

			IUIX_Inst uiInst = (IUIX_Inst)Inst.GetExtension("UIX");
			Rectangle rcCl = ClientRectangle;
			tagRECT rc;
			rc.left = rcCl.Left;
			rc.top = rcCl.Top;
			rc.right = rcCl.Right;
			rc.bottom = rcCl.Bottom;

			UIX_CreateObjParams cp = new UIX_CreateObjParams();
			cp.nStdClass = (int)UIX_StdClasses.UIX_StdClass_Blank;
			cp.hWndParent = (uint)Handle.ToInt32();
			//cp2.hWnd = (uint)Handle.ToInt32();
			cp.rc = rc;
			cp.nObjStyle = 0;// uiInst.MakeObjStyle(0, (int)UIX_ObjStyleExFlags.UIX_ObjStyleEx_SimpleWndWrapper);
			parentBase = uiInst.CreateObj(ref cp);

			pagesPreviewCtl = Inst.CreatePagesPreviewCtl(parentBase, rc, "ctrl.01",
				(long)PXV_PagesPreviewStyleFlags.PXV_PagesPreviewStyle_NoHandTool | (long)PXV_PagesPreviewStyleFlags.PXV_PagesPreviewStyle_NonInertialHand | (long)PXV_PagesPreviewStyleFlags.PXV_PagesPreviewStyle_InteractiveLayout,
				(long)UIX_ScrollStyleFlags.UIX_ScrollStyle_Horz | (long)UIX_ScrollStyleFlags.UIX_ScrollStyle_Vert);
		}
		public void ReleaseInst()
		{
			m_doc?.Close();
			pagesPreviewCtl = null;
			Inst = null;
		}

		private void PreviewCtrl_Resize(object sender, EventArgs e)
		{
			Rectangle rcCl = ClientRectangle;
			tagRECT rc;
			rc.left = rcCl.Left;
			rc.top = rcCl.Top;
			rc.right = rcCl.Right;
			rc.bottom = rcCl.Bottom;
			parentBase?.set_Rect(ref rc);
			if (pagesPreviewCtl != null)
			{
				IUIX_Obj parent = pagesPreviewCtl.Obj.Parent;
				parent?.set_Rect(ref rc);
			}
		}

		public void OpenFile(string fileName)
		{
			int nID = Inst.Str2ID("op.openDoc", false);
			PDFXEdit.IOperation Op = Inst.CreateOp(nID);
			PDFXEdit.IAFS_Inst fsInst = (PDFXEdit.IAFS_Inst)Inst.GetExtension("AFS");
			PDFXEdit.IAFS_Name name = fsInst.DefaultFileSys.StringToName(fileName);
			var input = Op.Params.Root["Input"];
			input.v = name;
			PDFXEdit.ICabNode options = Op.Params.Root["Options"];
			options["NativeOnly"].v = true;
			Op.Do();

			m_doc?.Close();
			m_doc = null;
			m_doc = (PDFXEdit.IPXC_Document)Op.Params.Root["Output"].v;
			OpenFile(m_doc);
		}

		public void OpenFile(PDFXEdit.IPXC_Document doc)
		{
			//Opening document in the given main Frame
			pagesPreviewCtl.Doc = doc;
		}
	}
}
