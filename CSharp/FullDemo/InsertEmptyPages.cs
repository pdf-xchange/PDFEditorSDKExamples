using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullDemo
{
	public partial class InsertEmptyPages : Form, IFormHelper
	{
		private MainFrm mainFrm = null;
		public PDFXEdit.IPXC_Inst m_pxcInst = null;
		List<DocumentSize> m_DocSizes = new List<DocumentSize>();

		struct DocumentSize
		{
			public string sType;
			public double nWidth;
			public double nHeight;
		}

		public InsertEmptyPages(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;
	
			InitializeComponent();
			//Papers` name to combocox
			PDFXEdit.StdPaperGroupID groupID;
			PDFXEdit.StdPaperID paperID;
			string sNamePaper;
			DocumentSize document = new DocumentSize();
			for (PDFXEdit.StdPaperID i = 0; i < PDFXEdit.StdPaperID.StdPaper_30x42; i++)
			{
				paperID = i;
				sNamePaper = paperID.ToString();
				sNamePaper = sNamePaper.Replace('_', ' ');
				sNamePaper = sNamePaper.Remove(0, 9);
				cbPaperName.Items.Add(sNamePaper);
				mainFrm.auxInst.GetStdPaperInfo(paperID, out groupID, out document.nWidth, out document.nHeight);
				document.sType = sNamePaper;
				m_DocSizes.Add(document);

			}
			if (mainFrm.pdfCtl.Doc == null)
				return;
			//Maximum value = maximum count pages
			tNumPage.Maximum = (int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count;
			cbOrientation.SelectedIndex = 0;
			cbLocation.SelectedIndex = 0;
			cbPaperName.SelectedIndex = 4;
			//Size document to control
			var RectPage = mainFrm.pdfCtl.Doc.CoreDoc.Pages[0].get_Box(PDFXEdit.PXC_BoxType.PBox_PageBox);
			tWidth.Value = (decimal)RectPage.right;
			tHeight.Value = (decimal)RectPage.top;
			lbDocumentSize.Text = String.Format("( {0} x {1} )", RectPage.right, RectPage.top);
			rbDocument.Checked = true;
		}

		public bool IsValid()
		{
			return mainFrm.pdfCtl.HasDoc;
		}

		public void OnUpdate()
		{
			Enabled = IsValid();
			if (Enabled)						
				lbNumPage.Text = String.Format("total {0} pages", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);		
			else						
				lbNumPage.Text = "";			
		}
		public void OnSerialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;

			PDFXEdit.ICabNode opts = op.Params.Root["Options"];
			//Pages
			int nPaperType = 0;
			if (rbStandard.Checked)
				nPaperType = 1;
			if (rbCustom.Checked)
				nPaperType = 2;
			opts["PaperType"].v = nPaperType;
			opts["Landscape"].v = cbOrientation.SelectedIndex != 0;
			opts["StdPaperIndex"].v = cbPaperName.SelectedIndex;
			opts["Width"].v = tWidth.Value;
			opts["Height"].v = tHeight.Value;
			opts["Count"].v = tCountPages.Value;
			//Destination
			int nLocation = cbLocation.SelectedIndex == 0 ? 0 : 1;
			opts["Location"].v = nLocation;
			int nNumberPage = 0;
			if (rbFirst.Checked)
				nNumberPage = 1;
			if (rbLast.Checked)
				nNumberPage = (int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count;
			if (rbPage.Checked)
				nNumberPage = (int)tNumPage.Value;
			opts["Position"].v = nNumberPage-1;

		}

		private void cbPaperName_DropDown(object sender, EventArgs e)
		{
			rbStandard.Checked = true;
		}

		private void tHeight_MouseClick(object sender, MouseEventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void tWidth_MouseClick(object sender, MouseEventArgs e)
		{
			rbCustom.Checked = true;
		}
		private void tWidth_ValueChanged(object sender, EventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void tHeight_ValueChanged(object sender, EventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void cbPaperName_SelectedIndexChanged(object sender, EventArgs e)
		{
			tWidth.Value = (decimal)m_DocSizes[cbPaperName.SelectedIndex].nWidth;
			tHeight.Value = (decimal)m_DocSizes[cbPaperName.SelectedIndex].nHeight;
			rbStandard.Checked = true;
		}

		private void rbDocument_Click(object sender, EventArgs e)
		{
			var RectPage = mainFrm.pdfCtl.Doc.CoreDoc.Pages[0].get_Box(PDFXEdit.PXC_BoxType.PBox_PageBox);
			tWidth.Value = (decimal)RectPage.right;
			tHeight.Value = (decimal)RectPage.top;
			rbDocument.Checked = true;
		}		

		private void tNumPage_ValueChanged(object sender, EventArgs e)
		{
			rbPage.Checked = true;
		}

		private void tNumPage_Click(object sender, EventArgs e)
		{
			rbPage.Checked = true;
		}

		private void rbFirst_Click(object sender, EventArgs e)
		{
			tNumPage.Value = 1;
			rbFirst.Checked = true;
		}

		private void rbLast_Click(object sender, EventArgs e)
		{
			tNumPage.Value = (int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count;
			rbLast.Checked = true;
		}
	}
}
