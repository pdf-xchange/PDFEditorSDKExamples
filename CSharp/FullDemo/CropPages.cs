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

		enum flags_operation
		{
			None				= 0,
			Media				= 1,
			Crop				= 2,
			Trip				= 4,
			Art					= 8,
			Bleed				= 16,

			WithRedaction		= 512,
			RemoveHorzWhiteSp	= 1024,
			RemoveVertWhiteSp	= 2048
		}
			

		public struct Rect
		{
			public double left;
			public double top;
			public double right;
			public double bottom;
		}
		Rect CropBox, BleedBox, TrimBox, ArtBox, MediaBox;
		public CropPages(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			MediaBox.left = 0;
			MediaBox.top = 0;
			MediaBox.right = 0;
			MediaBox.bottom = 0;

			ArtBox = MediaBox;
			CropBox = MediaBox;
			BleedBox = MediaBox;
			TrimBox = MediaBox;

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
			int flags = 0;
			if (cbCropMethod.SelectedIndex == 1)
				flags = (int)flags_operation.WithRedaction;
			else if (cbCropMethod.SelectedIndex == 2)
				flags = (int)flags_operation.RemoveVertWhiteSp;
			else if (cbCropMethod.SelectedIndex == 3)
				flags = (int)flags_operation.RemoveHorzWhiteSp;
			else
			{
				if (ckCrop.Checked)
				{
					flags += (int)flags_operation.Crop;
					PDFXEdit.ICabNode Crop = opts["MediaBox"];
					Crop["left"].v = RectPage.left + CropBox.left;
					Crop["top"].v = RectPage.top - CropBox.top;
					Crop["right"].v = RectPage.right - CropBox.right;
					Crop["bottom"].v = RectPage.bottom + CropBox.bottom;

					if (ckAdjustMedia.Checked)
					{
						flags += (int)flags_operation.Media;
						PDFXEdit.ICabNode Media = opts["MediaBox"];
						Media["left"].v = Crop["left"].v;
						Media["top"].v = Crop["top"].v;
						Media["right"].v = Crop["right"].v;
						Media["bottom"].v = Crop["bottom"].v;
					}
				}
				
				if (ckArt.Checked)
				{
					flags += (int)flags_operation.Art;
					PDFXEdit.ICabNode Art = opts["ArtBox"];
					Art["left"].v = RectPage.left + ArtBox.left;
					Art["top"].v = RectPage.top - ArtBox.top;
					Art["right"].v = RectPage.right - ArtBox.right;
					Art["bottom"].v = RectPage.bottom + ArtBox.bottom;
				}
				
				
				if (CkTrim.Checked)
				{
					flags += (int)flags_operation.Trip;
					PDFXEdit.ICabNode Trim = opts["MediaBox"];
					Trim["left"].v = RectPage.left + TrimBox.left;
					Trim["top"].v = RectPage.top - TrimBox.top;
					Trim["right"].v = RectPage.right - TrimBox.right;
					Trim["bottom"].v = RectPage.bottom + TrimBox.bottom;
				}
				if (ckBleed.Checked)
				{
					flags += (int)flags_operation.Bleed;
					PDFXEdit.ICabNode Bleed = opts["MediaBox"];
					Bleed["left"].v = RectPage.left + BleedBox.left;
					Bleed["top"].v = RectPage.top - BleedBox.top;
					Bleed["right"].v = RectPage.right - BleedBox.right;
					Bleed["bottom"].v = RectPage.bottom + BleedBox.bottom;
				}
			}
			opts["Flags"].v = flags;
		}

		private void cbCropMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool blancase = cbCropMethod.SelectedIndex == 0;
			groupBox4.Enabled = blancase;
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
					UpDateValueBox(out CropBox);
					break;
				case 1:
					UpDateValueBox(out BleedBox);
					break;
				case 2:
					UpDateValueBox(out TrimBox);
					break;
				case 3:
					UpDateValueBox(out ArtBox);
					break;
			}
		}

		private void cbBox_DropDownClosed(object sender, EventArgs e)
		{
			switch (cbBox.SelectedIndex)
			{
				case 0:
					UpDateValueControl(CropBox);
					break;
				case 1:
					UpDateValueControl(BleedBox);
					break;
				case 2:
					UpDateValueControl(TrimBox);
					break;
				case 3:
					UpDateValueControl(ArtBox);
					break;
			}
		}
		public void UpDateValueBox(out Rect rect)
		{			
			rect.left = (double)tLeft.Value;
			rect.top = (double)tTop.Value;
			rect.right = (double)tRight.Value;
			rect.bottom = (double)tBottom.Value;
		}
		public void UpDateValueControl(Rect rect)
		{
			tLeft.Value = (decimal)rect.left;
			tTop.Value = (decimal)rect.top;
			tRight.Value = (decimal)rect.right;
			tBottom.Value = (decimal)rect.bottom;
		}
	}
}
