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
		string[] m_Type		= { "Text", "File" };
		string[] m_HAlign	= { "Left", "Center", "Right" };
		string[] m_VAlign	= { "Top", "Center", "Bottom" };

		public AddWatermarkForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			cbPagesSubset.SelectedIndex = 0;
			ckScaleRelative.Checked = true;

			cbType.Items.AddRange(m_Type);
			cbType.SelectedIndex = 0;

			cbAlign.Items.AddRange(m_HAlign);
			cbAlign.SelectedIndex = 0;

			cbHOffsetFrom.Items.AddRange(m_HAlign);
			cbHOffsetFrom.SelectedIndex = 1;

			cbVOffsetFrom.Items.AddRange(m_VAlign);
			cbVOffsetFrom.SelectedIndex = 1;

			ckAsBackground.Checked = false;

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

			opts["Type"].v = cbType.SelectedIndex;
			if (cbType.SelectedIndex == 0)
			{
				opts["Text"].v = tText.Text;
				//font
				PDFXEdit.ICabNode font = opts["Font"];

				font["Name"].v = btnFontName.Font.Name;
				font["Size"].v = btnFontName.Font.Size;
				font["Underline"].v = btnFontName.Font.Underline;
				font["StrikeOut"].v = btnFontName.Font.Strikeout;
				Color clrText = btnFillClr.BackColor;
				font["FColor"].v = String.Format("rgbd({0},{1},{2})", clrText.R, clrText.G, clrText.B);
				clrText = btnStrokeClr.BackColor;
				font["SColor"].v = String.Format("rgbd({0},{1},{2})", clrText.R, clrText.G, clrText.B);
				font["StrokeWidth"].v = tStrokeWidth.Value;

				opts["TextAlign"].v = cbAlign.SelectedIndex;
			}
			else
			{
				opts["FileName"].v = tPath.Text;
				opts["ImagePage"].v = tNumPage.Value;
			}
			opts["Rotation"].v = tRotation.Value;
			opts["Opacity"].v = (double)tOpacity.Value;					
			opts["UseRelativeScale"].v = ckScaleRelative.Checked;
			opts["RelativeScale"].v = tScale.Value;

			opts["HOffset"].v = tHOffset.Value;
			opts["VOffset"].v = tVOffset.Value;
			opts["VOffsetFrom"].v = cbVOffsetFrom.SelectedIndex;
			opts["HOffsetFrom"].v = cbHOffsetFrom.SelectedIndex;
			opts["AsBackground"].v = ckAsBackground.Checked;
			

			// pages range
			PDFXEdit.ICabNode pagesRange = opts["PagesRange"];
			PDFXEdit.RangeType rangeType = PDFXEdit.RangeType.RangeType_All;
			if (rbCurPage.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Current;
			else if (rbPages.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;

			rangeType = PDFXEdit.RangeType.RangeType_All;
			if (cbPagesSubset.SelectedIndex == 1)
				rangeType = PDFXEdit.RangeType.RangeType_Odd;
			else if (cbPagesSubset.SelectedIndex != 0)
				rangeType = PDFXEdit.RangeType.RangeType_Even;
			pagesRange["Filter"].v = rangeType;
		}

		private void btnTextClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnFillClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
				btnFillClr.BackColor = colorDialog1.Color;
		}

		private void btnStrokeClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnStrokeClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
				btnStrokeClr.BackColor = colorDialog1.Color;
		}

		private void btnFontName_Click(object sender, EventArgs e)
		{
			fontDialog1.Font = btnFontName.Font;
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				btnFontName.Font = fontDialog1.Font;
				btnFontName.Text = fontDialog1.Font.Name;
			}
		}

		private void cbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbType.SelectedIndex == 0)
			{
				groupBox5.Visible = false;
				groupBox4.Visible = true;
			}
			else
			{
				groupBox4.Visible = false;
				groupBox5.Visible = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
			openFileDialog1.FilterIndex = 1;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				tPath.Text = openFileDialog1.FileName;
			/*
				PDFXEdit.IAUX_Inst inst = null;
				inst = new PDFXEdit.IAUX_Inst();
				inst.Init("");
				PDFXEdit.IPXV_Document doc =
				lbNumPgs.Text = String.Format("total {0} pages", doc.Pages.Count);
				*/
			}
		}

		private void rbPages_CheckedChanged(object sender, EventArgs e)
		{
			tPages.Focus();
		}
	}
}
