using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFXEdit;

namespace PreviewCtrl
{
	public partial class Form1 : Form
	{
		public IPXV_Inst inst = new PXV_Inst();

		List<PDFXEditCtrl.PreviewCtrl> previewCtrl = new List<PDFXEditCtrl.PreviewCtrl>();
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			inst.Init(null, "Key");
			previewCtrl1.LoadInst(inst);
			// 			UIX_CreateObjParams par = new UIX_CreateObjParams();
			// 			par.nCreateFlags |= (Int64)UIX_CreateObjFlags.UIX_CreateObj_Windowed;
			// 			par.nWndStyle = 0x40000000 | 0x02000000;//WS_CHILD | WS_CLIPCHILDREN;
			// 			par.rc = rc;
			// 			par.hWndParent = (uint)this.Handle.ToInt32();
			// 			IUIX_Obj parent = uiInst.CreateObj(ref par);
			//			pagesPreviewCtl = inst.CreatePagesPreviewCtl(parent, rc, "ctrl_01");
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			previewCtrl1.ReleaseInst();
			for (int i = 0; i < previewCtrl.Count; i++)
			{
				previewCtrl[i].ReleaseInst();
			}
			inst.Shutdown(0);
		}

		private void fileToolOpenFile_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				TabPage tabPage = new TabPage();
				tabPage.Location = new System.Drawing.Point(4, 29);
				tabPage.Name = "tabPage" + tabControl1.Controls.Count.ToString();
				tabPage.Padding = new System.Windows.Forms.Padding(3);
				tabPage.Size = new System.Drawing.Size(1140, 558);
				tabPage.TabIndex = 1;
				tabPage.Text = Path.GetFileName(openFileDialog1.FileName);
				tabPage.UseVisualStyleBackColor = true;

				PDFXEditCtrl.PreviewCtrl previewCtrl2 = new PDFXEditCtrl.PreviewCtrl();
				previewCtrl2.LoadInst(inst);
				previewCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
				previewCtrl2.Location = new System.Drawing.Point(3, 3);
				previewCtrl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
				previewCtrl2.Name = "previewCtrl" + tabControl1.Controls.Count.ToString();
				previewCtrl2.Size = new System.Drawing.Size(1134, 552);
				previewCtrl2.TabIndex = 1;
				previewCtrl.Add(previewCtrl2);
				previewCtrl2.OpenFile(openFileDialog1.FileName);

				tabPage.Controls.Add(previewCtrl2);
				tabControl1.Controls.Add(tabPage);
				tabControl1.SelectedTab = tabPage;

			}
		}

		private PDFXEditCtrl.PreviewCtrl GetActivePreview()
		{
			var tabPage = tabControl1.SelectedTab;
			return (PDFXEditCtrl.PreviewCtrl)tabPage.Controls[0];
		}
		private PDFXEdit.IPXV_PagesLayoutManager GetActivePreviewLayout()
		{
			PDFXEditCtrl.PreviewCtrl prev = GetActivePreview();
			if (prev.pagesPreviewCtl.Doc == null)
				throw new Exception();
			return prev.pagesPreviewCtl.Layout;
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			PDFXEditCtrl.PreviewCtrl prev = GetActivePreview();
			toolCurPage.Text = (prev.pagesPreviewCtl.Layout.CurrentPage + 1).ToString();
			toolPageCount.Text = @"\" + prev.pagesPreviewCtl.Doc?.Pages.Count.ToString();
		}

		private void toolZoomIn_Click(object sender, EventArgs e)
		{
			try
			{
				var layout = GetActivePreviewLayout();
				PXV_ZoomMode nZM;
				double nZL;
				layout.GetNextZoom(out nZM, out nZL);
				layout.SetZoom(nZM, nZL);
			}
			catch (Exception)
			{
			}
		}

		private void toolZoomOut_Click(object sender, EventArgs e)
		{
			try
			{
				var layout = GetActivePreviewLayout();
				PXV_ZoomMode nZM;
				double nZL;
				layout.GetPrevZoom(out nZM, out nZL);
				layout.SetZoom(nZM, nZL);
			}
			catch (Exception)
			{
			}
		}

		private void toolZoomFit_Click(object sender, EventArgs e)
		{
			try
			{
				var layout = GetActivePreviewLayout();
				PXV_ZoomMode nZM = PXV_ZoomMode.PXV_ZoomMode_FitPage;
				double nZL = 0;
				layout.SetZoom(nZM, nZL);
			}
			catch (Exception)
			{
			}
		}

		private void toolZoomWidth_Click(object sender, EventArgs e)
		{
			try
			{
				var layout = GetActivePreviewLayout();
				PXV_ZoomMode nZM = PXV_ZoomMode.PXV_ZoomMode_FitWidth;
				double nZL = 0;
				layout.SetZoom(nZM, nZL);
			}
			catch (Exception)
			{
			}
		}

		private void toolPageNext_Click(object sender, EventArgs e)
		{
			try
			{
				var layout = GetActivePreviewLayout();
				layout.Navigate(PXV_PagesLayoutNavigateMode.PLNavigate_NextPage);
				toolCurPage.Text = (layout.CurrentPage + 1).ToString();
			}
			catch (Exception)
			{
			}

		}

		private void toolPagePrev_Click(object sender, EventArgs e)
		{
			try
			{
				var layout = GetActivePreviewLayout();
				layout.Navigate(PXV_PagesLayoutNavigateMode.PLNavigate_PrevPage);
				toolCurPage.Text = (layout.CurrentPage + 1).ToString();
			}
			catch (Exception)
			{
			}

		}
	}
}
