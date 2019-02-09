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
			Trim				= 0x004,
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

		public void OnSerialize(IOperation op)
		{
			if (op == null)
				return;			
			ICabNode opts = op.Params.Root["Options"];
			int flags = (int)eOperaionFlags.None;
			List<string> nameBoxes = new List<string>();
			List<PXC_Rect> rectBoxes = new List<PXC_Rect>();

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
					nameBoxes.Add("CropBox");
					rectBoxes.Add(m_rcCropBox);
					flags += (int)eOperaionFlags.Crop;

					if (ckAdjustMedia.Checked)
					{
						nameBoxes.Add("MediaBox");
						rectBoxes.Add(m_rcCropBox);
						flags += (int)eOperaionFlags.Media;
					}
				}				
				else if (ckArt.Checked)
				{
					nameBoxes.Add("ArtBox");
					rectBoxes.Add(m_rcArtBox);
					flags += (int)eOperaionFlags.Art;					
				}								
				else if (CkTrim.Checked)
				{
					nameBoxes.Add("TrimBox");
					rectBoxes.Add(m_rcTrimBox);
					flags += (int)eOperaionFlags.Trim;					
				}
				else
				{
					nameBoxes.Add("BleedBox");
					rectBoxes.Add(m_rcBleedBox);
					flags += (int)eOperaionFlags.Bleed;					
				}
			}
			SetValueOptions(opts, nameBoxes, rectBoxes);
			opts["Flags"].v = flags;
		}
		public void SetValueOptions(ICabNode opts, List<string> nNameBoxes, List<PXC_Rect> nRectBoxes)
		{
			var RectPage = mainFrm.pdfCtl.Doc.CoreDoc.Pages[0].get_Box(PXC_BoxType.PBox_PageBox);
			for (int i = 0; i < nNameBoxes.Count; i++)
			{
				ICabNode Box = opts[nNameBoxes[i]];
				Box["left"].v = RectPage.left + nRectBoxes[i].left;
				Box["top"].v = RectPage.top - nRectBoxes[i].top;
				Box["right"].v = RectPage.right - nRectBoxes[i].right;
				Box["bottom"].v = RectPage.bottom + nRectBoxes[i].bottom;
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
