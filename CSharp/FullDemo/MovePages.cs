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
		string[] m_Location = new string[] {"Before", "After"};
		public MovePages(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			
			cbPagesSubset.SelectedIndex = 0;
			cbLocation.Items.AddRange(m_Location);
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
			if (cbLocation.SelectedIndex == 0)
			{
				if (rbFirst.Checked)
					nNumberPage = 0;
				if (rbLast.Checked)
					nNumberPage = (int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count - 1;
				if (rbPage.Checked)
					nNumberPage = (int)tNumPage.Value;
			}
			else 
			{
				if (rbFirst.Checked)
					nNumberPage = 2;
				if (rbLast.Checked)
					nNumberPage = (int)mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count;
				if (rbPage.Checked)
					nNumberPage = (int)tNumPage.Value+1;
			}
			opts["InsertBefore"].v = nNumberPage;
		}

		private void rbPage_CheckedChanged_1(object sender, EventArgs e)
		{
			tNumPage.Focus();
		}

		private void rbPages_CheckedChanged(object sender, EventArgs e)
		{
			tPages.Focus();
		}
	}
}
