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
	public partial class MovePages : Form, IFormHelper
	{
		private MainFrm mainFrm = null;
		public MovePages(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			
			cbPagesSubset.SelectedIndex = 0;
			cbLocation.SelectedIndex = 0;
		}

		public bool IsValid()
		{
			return mainFrm.pdfCtl.HasDoc;
		}

		public void OnUpdate()
		{
			Enabled = IsValid();
			if (Enabled)
			{
				lbNumPages.Text = String.Format("total {0} pages", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);
				lbNumPage.Text = String.Format("total {0} pages", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);
			}
			else
			{
				lbNumPages.Text = "";
				lbNumPage.Text = "";
			}
		}

		public void OnSerialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;

			PDFXEdit.ICabNode opts = op.Params.Root["Options"];

			// pages range
			PDFXEdit.ICabNode pagesRange = opts["PagesRange"];
			PDFXEdit.RangeType rangeType = PDFXEdit.RangeType.RangeType_Current;
			if (rbPages.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;

			rangeType = PDFXEdit.RangeType.RangeType_All;
			if (cbPagesSubset.SelectedIndex == 1)
				rangeType = PDFXEdit.RangeType.RangeType_Odd;
			else if (cbPagesSubset.SelectedIndex != 0)
				rangeType = PDFXEdit.RangeType.RangeType_Even;
			pagesRange["Filter"].v = rangeType;
			int nNumberPage = 1;
			bool blancase = cbLocation.SelectedIndex == 0;

			if (rbFirst.Checked)
				nNumberPage = blancase ? 0 : 2;
			if (rbLast.Checked)
				nNumberPage = blancase ?
				(int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count - 1 :
				(int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count;
			if (rbPage.Checked)
				nNumberPage = blancase ? (int)tNumPage.Value : nNumberPage = (int)tNumPage.Value + 1;
					
			opts["InsertBefore"].v = nNumberPage;
		}

		private void rbPages_CheckedChanged(object sender, EventArgs e)
		{
			tPages.Focus();
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

		private void rbPage_CheckedChanged(object sender, EventArgs e)
		{
			tNumPage.Focus();
		}
	}
}
