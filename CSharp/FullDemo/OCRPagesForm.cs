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
	public partial class OCRPagesForm : Form, IFormHelper
	{
		

		private MainFrm mainFrm = null;
		public OCRPagesForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			cbPagesSubset.SelectedIndex = 0;
			cbOutputType.SelectedIndex = 1;
			cbQuality.SelectedIndex = 3;
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

			//Output 
			opts["OutputType"].v = cbOutputType.SelectedIndex;
			opts["OutputDPI"].v = (cbQuality.SelectedIndex != 0) ? Convert.ToInt32(cbQuality.Text) : 0 ;
			//opts["AutoDeskew"].v = ckAutoDeskew.Checked;
		}

		private void cbOutputType_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbQuality.Enabled = cbOutputType.SelectedIndex == 0;
			ckAutoDeskew.Enabled = cbOutputType.SelectedIndex == 0;
		}
	}
}
