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
		PDFXEdit.PXC_Rect m_rcCropBox, m_rcBleedBox, m_rcTrimBox, m_rcArtBox, m_rcMediaBox;

		public CropPages(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();


			m_rcMediaBox = default(PDFXEdit.PXC_Rect);
			m_rcArtBox = default(PDFXEdit.PXC_Rect);
			m_rcCropBox = default(PDFXEdit.PXC_Rect);
			m_rcBleedBox = default(PDFXEdit.PXC_Rect);
			m_rcTrimBox = default(PDFXEdit.PXC_Rect);

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
			PDFXEdit.ICabNode opts = op.Params.Root["Options"];
			int flags = (int)eOperaionFlags.None;
			List<string> nameBoxs = new List<string>();
			List<PDFXEdit.PXC_Rect> rectBoxs = new List<PDFXEdit.PXC_Rect>();

			if (cbCropMethod.SelectedIndex == 1)
				flags = (int)eOperaionFlags.WithRedaction;
			else if (cbCropMethod.SelectedIndex == 2)
				flags = (int)eOperaionFlags.RemoveVertWhiteSp;
			else if (cbCropMethod.SelectedIndex == 3)
				flags = (int)eOperaionFlags.RemoveHorzWhiteSp;
			else
			{
				if (ckCrop.Checked)
				{
					nameBoxs.Add("CropBox");
					rectBoxs.Add(m_rcCropBox);
					flags += (int)eOperaionFlags.Crop;

					if (ckAdjustMedia.Checked)
					{
						nameBoxs.Add("MediaBox");
						rectBoxs.Add(m_rcCropBox);
						flags += (int)eOperaionFlags.Media;
					}
				}				
				if (ckArt.Checked)
				{
					nameBoxs.Add("ArtBox");
					rectBoxs.Add(m_rcArtBox);
					flags += (int)eOperaionFlags.Art;					
				}								
				if (CkTrim.Checked)
				{
					nameBoxs.Add("TrimBox");
					rectBoxs.Add(m_rcTrimBox);
					flags += (int)eOperaionFlags.Trip;					
				}
				if (ckBleed.Checked)
				{
					nameBoxs.Add("BleedBox");
					rectBoxs.Add(m_rcBleedBox);
					flags += (int)eOperaionFlags.Bleed;					
				}
			}
			SetValueOptions(opts, nameBoxs, rectBoxs);
			opts["Flags"].v = flags;
		}
		public void SetValueOptions(PDFXEdit.ICabNode opts, List<string> nNameBoxs, List<PDFXEdit.PXC_Rect> nRectBoxs)
		{
			var RectPage = mainFrm.pdfCtl.Doc.CoreDoc.Pages[0].get_Box(PDFXEdit.PXC_BoxType.PBox_PageBox);
			for (int i = 0; i < nNameBoxs.Count; i++)
			{
				PDFXEdit.ICabNode Box = opts[nNameBoxs[i]];
				Box["left"].v = RectPage.left + nRectBoxs[i].left;
				Box["top"].v = RectPage.top - nRectBoxs[i].top;
				Box["right"].v = RectPage.right - nRectBoxs[i].right;
				Box["bottom"].v = RectPage.bottom + nRectBoxs[i].bottom;
			}
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
		public void UpdateValueBox(out PDFXEdit.PXC_Rect rect)
		{			
			rect.left = (double)tLeft.Value;
			rect.top = (double)tTop.Value;
			rect.right = (double)tRight.Value;
			rect.bottom = (double)tBottom.Value;
		}
		public void UpdateValueControl(PDFXEdit.PXC_Rect rect)
		{
			tLeft.Value = (decimal)rect.left;
			tTop.Value = (decimal)rect.top;
			tRight.Value = (decimal)rect.right;
			tBottom.Value = (decimal)rect.bottom;
		}
	}
}
