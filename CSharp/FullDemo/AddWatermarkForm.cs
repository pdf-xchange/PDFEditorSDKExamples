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
	public partial class AddWatermarkForm : Form, IFormHelper
	{
		private MainFrm mainFrm = null;

		public AddWatermarkForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();
		}

		private void tPages_TextChanged(object sender, EventArgs e)
		{
			rbPages.Checked = true;
		}

		/////////////////////////////////////////////////////////////////
		// IFormHelper
		/////////////////////////////////////////////////////////////////

		public bool IsValid()
		{
			return mainFrm.pdfCtl.HasDoc;
		}
 
		public void OnUpdate()
		{
			Enabled = IsValid();
			if (Enabled)
				lbNumPages.Text = String.Format("total {0} pages", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);
			else
				lbNumPages.Text = "";
		}

		public void OnSerialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;
			
			PDFXEdit.ICabNode opts = op.Params.Root["Options"];

			opts["Text"].v = tText.Text;

			Color clrText = btnTextClr.BackColor;
			opts["Font.FColor"].v = String.Format("rgbd({0},{1},{2})", clrText.R, clrText.G, clrText.B);
			opts["Opacity"].v = (double)tOpacity.Value;

			opts["Rotation"].v = tRotation.Value;
			opts["UseRelativeScale"].v = true;
			opts["RelativeScale"].v = 100.0;

			// pages range
			PDFXEdit.ICabNode pagesRange = opts["PagesRange"];
			PDFXEdit.RangeType rangeType = PDFXEdit.RangeType.RangeType_All;
			if (rbCurPage.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Current;
			else if (rbPages.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;
		}

		private void btnTextClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnTextClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
				btnTextClr.BackColor = colorDialog1.Color;
		}
	}
}
