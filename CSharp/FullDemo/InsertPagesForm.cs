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
	public partial class InsertPagesForm : Form, IFormHelper
	{
		private MainFrm mainFrm = null;

		public InsertPagesForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();
		}

		private void tPages_TextChanged(object sender, EventArgs e)
		{
			rbPages.Checked = true;
			mainFrm.AllowRunOper(IsValid());
		}

		/////////////////////////////////////////////////////////////////
		// IFormHelper
		/////////////////////////////////////////////////////////////////

		public void Update()
		{
			Enabled = mainFrm.pdfCtl.HasDoc;
			if (Enabled)
				lbNumPages.Text = String.Format("(total {0} pages)", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);
			else
				lbNumPages.Text = "";
		}

		public bool IsValid()
		{
			return mainFrm.pdfCtl.HasDoc && (tSrcToOpen.Text.Length != 0);
		}

		public void Serialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;
			
			PDFXEdit.ICabNode opts = op.Params.Root["Options"];

			// src
			opts["Src"].v = mainFrm.fsInst.DefaultFileSys.StringToName(tSrcToOpen.Text);

			// src pages range
			PDFXEdit.ICabNode pagesRange = opts["PagesRange"];
			PDFXEdit.RangeType rangeType = PDFXEdit.RangeType.RangeType_All;
			if (rbPages.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;

			// dest
			opts["Location"].v = "Before";
			opts["Position"].v = (int)tDestPos.Value - 1;
		}

		private void btnBrowseForOpen_Click(object sender, EventArgs e)
		{
			PDFXEdit.IAFS_NamesCollection openFiles = mainFrm.ShowOpenFilesDlg(false, "PDF Documents (*.pdf)|*.pdf|All Files (*.*)|*.*");
			if (openFiles == null)
				return;
			PDFXEdit.IAFS_Name fileName = openFiles[0];
			tSrcToOpen.Text = fileName.FileSys.NameToString(fileName);
			mainFrm.AllowRunOper(IsValid());
		}
	}
}
