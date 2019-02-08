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
	public partial class ResizePagesForm : Form, IFormHelper
	{
		private MainFrm mainFrm = null;
		string[] m_HAlign = { "Left", "Center", "Right" };
		string[] m_VAlign = { "Top", "Center", "Bottom" };
		List<DocumentSize> m_DocSizes = new List<DocumentSize>();

		struct DocumentSize
		{
			public string sType;
			public double nWidth;
			public double nHeight;
		}

		public ResizePagesForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			//Papers` name to combocox
			StdPaperGroupID groupID;
			StdPaperID paperID;
			string sNamePaper;
			DocumentSize document = new DocumentSize();
			for (StdPaperID i = 0; i < StdPaperID.StdPaper_30x42; i++)
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
			cbOrientation.SelectedIndex = 0;

			if (mainFrm.pdfCtl.Doc == null)
				return;
			var RectPage = mainFrm.pdfCtl.Doc.CoreDoc.Pages[0].get_Box(PXC_BoxType.PBox_PageBox);
			tWidth.Value = (decimal)RectPage.right;
			tHeight.Value = (decimal)RectPage.top;
			//lbDocumentSize.Text = String.Format("( {0} x {1} )", RectPage.right, RectPage.top);

			rbStandard.Checked = true;
			cbPaperName.SelectedIndex = 4;
			cbHOffsetFrom.Items.AddRange(m_HAlign);
			cbHOffsetFrom.SelectedIndex = 1;

			cbVOffsetFrom.Items.AddRange(m_VAlign);
			cbVOffsetFrom.SelectedIndex = 1;
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

			opts["HOffset"].v = tHOffset.Value;
			opts["VOffset"].v = tVOffset.Value;
			opts["VOffsetFrom"].v = cbVOffsetFrom.SelectedIndex;
			opts["HOffsetFrom"].v = cbHOffsetFrom.SelectedIndex;
			opts["ScalePage"].v = ckScalePage.Checked;
			if (ckScalePage.Checked)
			{
				opts["ConstraintProportions"].v = ckConstraintProportions.Checked;
				opts["ScaleAnnotations"].v = ckScaleAnnotations.Checked;
				if (ckScaleAnnotations.Checked)
					opts["ScaleText"].v = ckScaleText.Checked;
			}

			opts["PaperType"].v = rbStandard.Checked ? 1 : 2;			
			opts["Landscape"].v = cbOrientation.SelectedIndex != 0;
			opts["StdPaperIndex"].v = cbPaperName.SelectedIndex;
			opts["Width"].v = tWidth.Value;
			opts["Height"].v = tHeight.Value;

		}

		private void rbPages_CheckedChanged(object sender, EventArgs e)
		{
			tPages.Focus();
		}

		private void ckScalePage_CheckedChanged(object sender, EventArgs e)
		{
			ckConstraintProportions.Enabled = ckScalePage.Checked;
			ckScaleAnnotations.Enabled = ckScalePage.Checked;
			ckScaleText.Enabled = ckScaleAnnotations.Enabled && ckScaleAnnotations.Checked;
		}

		private void ckScaleAnnotations_CheckedChanged(object sender, EventArgs e)
		{
			ckScaleText.Enabled = ckScaleAnnotations.Checked;
		}

		private void rbStandard_CheckedChanged(object sender, EventArgs e)
		{
			StandardORCustom(rbCustom.Checked);
		}

		private void rbCustom_CheckedChanged(object sender, EventArgs e)
		{
			StandardORCustom(rbCustom.Checked);
		}

		public void StandardORCustom(bool bCustom)
		{
			cbOrientation.Enabled = !bCustom;
			cbPaperName.Enabled = !bCustom;
			tWidth.Enabled = bCustom;
			tHeight.Enabled = bCustom;
		}

		private void tWidth_ValueChanged(object sender, EventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void tWidth_Click(object sender, EventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void tHeight_ValueChanged(object sender, EventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void tHeight_Click(object sender, EventArgs e)
		{
			rbCustom.Checked = true;
		}

		private void cbPaperName_SelectedIndexChanged(object sender, EventArgs e)
		{
			tWidth.Value = (decimal)m_DocSizes[cbPaperName.SelectedIndex].nWidth;
			tHeight.Value = (decimal)m_DocSizes[cbPaperName.SelectedIndex].nHeight;
			rbStandard.Checked = true;
		}
	}
}
