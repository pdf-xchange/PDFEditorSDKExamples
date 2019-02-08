using PDFXEdit;
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
	public partial class RotatePagesForm : Form, IFormHelper
	{
		private MainFrm mainFrm = null;
		

		public RotatePagesForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			cbDirection.SelectedIndex = 0;
			cbOrientation.SelectedIndex = 0;
			cbPagesSubset.SelectedIndex = 0;
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
			}
			else
			{
				lbNumPages.Text = "";				
			}
		}

		public void OnSerialize(IOperation op)
		{
			if (op == null)
				return;

			ICabNode opts = op.Params.Root["Options"];

			// pages range
			ICabNode pagesRange = opts["PagesRange"];
			RangeType rangeType = RangeType.RangeType_All;
			if (rbCurPage.Checked)
				rangeType = RangeType.RangeType_Current;
			else if (rbPages.Checked)
				rangeType = RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;

			rangeType = RangeType.RangeType_All;
			if (cbPagesSubset.SelectedIndex == 1)
				rangeType = RangeType.RangeType_Odd;
			else if (cbPagesSubset.SelectedIndex != 0)
				rangeType = RangeType.RangeType_Even;
			pagesRange["Filter"].v = rangeType;

			opts["Direction"].v = cbDirection.SelectedIndex + 1; // 0 = 0 degrees 
			opts["PagesOrientation"].v = cbOrientation.SelectedIndex; // selectedindex = value
		}

		private void rbPages_CheckedChanged(object sender, EventArgs e)
		{
			tPages.Focus();
		}
	}
}
