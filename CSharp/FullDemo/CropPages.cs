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
	public partial class CropPages : Form, IFormHelper
	{
		private MainFrm mainFrm = null;

		enum eOperaionFlags
		{
			None				= 0,
			Media				= 0x001,
			Crop				= 0x002,
			Trip				= 0x004,
			Art					= 0x008,
			Bleed				= 0x010,

			WithRedaction		= 0x200,
			RemoveHorzWhiteSp	= 0x400,
			RemoveVertWhiteSp	= 0x800,
		}
			

		PXC_Rect m_rcCropBox, m_rcBleedBox, m_rcTrimBox, m_rcArtBox, m_rcMediaBox;
		public CropPages(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();
			m_rcMediaBox = default(PXC_Rect);
			m_rcArtBox = default(PXC_Rect);
			m_rcCropBox = default(PXC_Rect);
			m_rcBleedBox = default(PXC_Rect);
			m_rcTrimBox = default(PXC_Rect);

			cbPagesSubset.SelectedIndex = 0;
			cbCropMethod.SelectedIndex = 0;
			cbBox.SelectedIndex = 0;
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
			if (mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count == 0)
				return;
			var RectPage = mainFrm.pdfCtl.Doc.CoreDoc.Pages[0].get_Box(PDFXEdit.PXC_BoxType.PBox_PageBox);

			PDFXEdit.ICabNode opts = op.Params.Root["Options"];
			int flags = (int)eOperaionFlags.None;
			if (cbCropMethod.SelectedIndex == 1)
				flags = (int)eOperaionFlags.WithRedaction;
			else if (cbCropMethod.SelectedIndex == 2)
				flags = (int)eOperaionFlags.RemoveVertWhiteSp;
			else if (cbCropMethod.SelectedIndex == 3)
				flags = (int)eOperaionFlags.RemoveHorzWhiteSp;
			else
			{
				//if (ckCrop.Checked)
				//{
				//	flags += (int)flags_operation.Crop;
				//	PDFXEdit.ICabNode Crop = opts["MediaBox"];
				//	Crop["left"].v = RectPage.left + CropBox.left;
				//	Crop["top"].v = RectPage.top - CropBox.top;
				//	Crop["right"].v = RectPage.right - CropBox.right;
				//	Crop["bottom"].v = RectPage.bottom + CropBox.bottom;

				//	if (ckAdjustMedia.Checked)
				//	{
				//		flags += (int)flags_operation.Media;
				//		PDFXEdit.ICabNode Media = opts["MediaBox"];
				//		Media["left"].v = Crop["left"].v;
				//		Media["top"].v = Crop["top"].v;
				//		Media["right"].v = Crop["right"].v;
				//		Media["bottom"].v = Crop["bottom"].v;
				//	}
				//}
				
				//if (ckArt.Checked)
				//{
				//	flags += (int)flags_operation.Art;
				//	PDFXEdit.ICabNode Art = opts["ArtBox"];
				//	Art["left"].v = RectPage.left + ArtBox.left;
				//	Art["top"].v = RectPage.top - ArtBox.top;
				//	Art["right"].v = RectPage.right - ArtBox.right;
				//	Art["bottom"].v = RectPage.bottom + ArtBox.bottom;
				//}
				
				
				//if (CkTrim.Checked)
				//{
				//	flags += (int)flags_operation.Trip;
				//	PDFXEdit.ICabNode Trim = opts["MediaBox"];
				//	Trim["left"].v = RectPage.left + TrimBox.left;
				//	Trim["top"].v = RectPage.top - TrimBox.top;
				//	Trim["right"].v = RectPage.right - TrimBox.right;
				//	Trim["bottom"].v = RectPage.bottom + TrimBox.bottom;
				//}
				//if (ckBleed.Checked)
				//{
				//	flags += (int)flags_operation.Bleed;
				//	PDFXEdit.ICabNode Bleed = opts["MediaBox"];
				//	Bleed["left"].v = RectPage.left + BleedBox.left;
				//	Bleed["top"].v = RectPage.top - BleedBox.top;
				//	Bleed["right"].v = RectPage.right - BleedBox.right;
				//	Bleed["bottom"].v = RectPage.bottom + BleedBox.bottom;
				//}
			}
			opts["Flags"].v = flags;
		}

		private void cbCropMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			groupBox4.Enabled = (cbCropMethod.SelectedIndex == 0);
		}

		private void btnToZero_Click(object sender, EventArgs e)
		{
			tLeft.Value = 0;
			tTop.Value = 0;
			tRight.Value = 0;
			tBottom.Value = 0;
		}

		private void cbBox_DropDown(object sender, EventArgs e)
		{
			switch (cbBox.SelectedIndex)
			{
				case 0:
					UpdateValueBox(out m_rcCropBox);
					break;
				case 1:
					UpdateValueBox(out m_rcBleedBox);
					break;
				case 2:
					UpdateValueBox(out m_rcTrimBox);
					break;
				case 3:
					UpdateValueBox(out m_rcArtBox);
					break;
			}
		}

		private void cbBox_DropDownClosed(object sender, EventArgs e)
		{
			switch (cbBox.SelectedIndex)
			{
				case 0:
					UpdateValueControl(m_rcCropBox);
					break;
				case 1:
					UpdateValueControl(m_rcBleedBox);
					break;
				case 2:
					UpdateValueControl(m_rcTrimBox);
					break;
				case 3:
					UpdateValueControl(m_rcArtBox);
					break;
			}
		}
		public void UpdateValueBox(out PXC_Rect rect)
		{			
			rect.left = (double)tLeft.Value;
			rect.top = (double)tTop.Value;
			rect.right = (double)tRight.Value;
			rect.bottom = (double)tBottom.Value;
		}
		public void UpdateValueControl(PXC_Rect rect)
		{
			tLeft.Value = (decimal)rect.left;
			tTop.Value = (decimal)rect.top;
			tRight.Value = (decimal)rect.right;
			tBottom.Value = (decimal)rect.bottom;
		}
	}
}
