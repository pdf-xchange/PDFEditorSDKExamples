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
	public partial class ExtractPagesForm : Form, IFormHelper
	{
		private MainFrm mainFrm = null;

		public ExtractPagesForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			cbExportMode.SelectedIndex = 0;
		}

		private void tPages_TextChanged(object sender, EventArgs e)
		{
			mainFrm.AllowRunOper(IsValid());
		}

		/////////////////////////////////////////////////////////////////
		// IFormHelper
		/////////////////////////////////////////////////////////////////

		public bool IsValid()
		{
			return mainFrm.pdfCtl.HasDoc && (tPages.Text.Length != 0);
		}

		public void OnUpdate()
		{
			Enabled = mainFrm.pdfCtl.HasDoc;
			if (Enabled)
				lbNumPages.Text = String.Format("(total {0} pages)", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);
			else
				lbNumPages.Text = "";
		}

		public void OnSerialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;
			
			PDFXEdit.ICabNode opts = op.Params.Root["Options"];

			PDFXEdit.ICabNode pagesRange = opts["PagesRange"];
			pagesRange["Type"].v = PDFXEdit.RangeType.RangeType_Exact;
			pagesRange["Text"].v = tPages.Text;

			opts["OpenFolder"].v = ckOpenFolder.Checked;

			string action = "AllToOneFile";
			if (cbExportMode.SelectedIndex == 1)
				action = "EachToFile";
			else if (cbExportMode.SelectedIndex == 2)
				action = "EachRangeToFile";
			opts["ExtractPagesAction"].v = action;
		}
	}
}
