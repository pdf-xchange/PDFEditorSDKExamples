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
	public partial class PrintForm : Form, IFormHelper
	{
		private MainFrm mainFrm = null;
		public static int m_nPrinterFlags = 0;

		public enum PrintFilters
		{	
			PrintContent_Doc				=	PXC_PrintContentFlags.PrintContent_Page			|
												PXC_PrintContentFlags.PrintContent_Media		| 
												PXC_PrintContentFlags.PrintContent_Widgets		| 
												PXC_PrintContentFlags.PrintContent_PrintMarks,
			PrintContent_DocAndMarkups		=	PXC_PrintContentFlags.PrintContent_Page			| 
												PXC_PrintContentFlags.PrintContent_Media		| 
												PXC_PrintContentFlags.PrintContent_Markups		| 
												PXC_PrintContentFlags.PrintContent_Stamps		| 
												PXC_PrintContentFlags.PrintContent_Widgets		| 
												PXC_PrintContentFlags.PrintContent_PrintMarks,
			PrintContent_DocAndStamps		=	PXC_PrintContentFlags.PrintContent_Page			| 
												PXC_PrintContentFlags.PrintContent_Media		| 
												PXC_PrintContentFlags.PrintContent_Stamps		| 
												PXC_PrintContentFlags.PrintContent_Widgets		| 
												PXC_PrintContentFlags.PrintContent_PrintMarks,
			PrintContent_WidgetsDataOnly	=	PXC_PrintContentFlags.PrintContent_Widgets		| 
												PXC_PrintContentFlags.PrintContent_FieldsDataOnly,
			PrintContent_MarkupsOnly		=	PXC_PrintContentFlags.PrintContent_Markups,	
			PrintContent_Whole				= 	PXC_PrintContentFlags.PrintContent_Page			|
												PXC_PrintContentFlags.PrintContent_Markups		|
												PXC_PrintContentFlags.PrintContent_Stamps		|
												PXC_PrintContentFlags.PrintContent_Widgets		|
												PXC_PrintContentFlags.PrintContent_Notes		|
												PXC_PrintContentFlags.PrintContent_NotePopups	|
												PXC_PrintContentFlags.PrintContent_Media		|
												PXC_PrintContentFlags.PrintContent_PrintMarks,

		};

		enum Paper_per_Sheets
		{
			_4		= 0,
			_6_V	= 1,
			_6_H	= 2,
			_9		= 3,
			_16		= 4,
			Custom	= 5,
		};
		enum ScaleTypes
		{ 
			None			= 0,
			FitToMargins	= 1,	
			ReduceToMargins = 2,	
			CustomZoom		= 3,		
			TileLarge		= 4,		
			TileAll			= 5,
			Multiple		= 6,		
			Booklet			= 7,
		};
		public PrintForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			IUniqueStrings prnList = mainFrm.pdfCtl.Inst.GetPrinters();

			foreach (string s in prnList)
				cbPrinter.Items.Add(s);

			int prnCur = cbPrinter.FindString(mainFrm.pdfCtl.Inst.GetDefaultPrinter());
			if (prnCur >= 0)
				cbPrinter.SelectedIndex = prnCur;
			cbDuplex.SelectedIndex = 0; // auto
			cbPagesSubset.SelectedIndex = 0; // all
			
			string[] scaleTypes = new string[] {
				"None",
				"FitToMargins",	
				"ReduceToMargins",	
				"CustomZoom",		
				"TileLarge",		
				"TileAll",
				"Multiple",		
				"Booklet",			
			};

			foreach (string s in scaleTypes)
				cbPagesScale.Items.Add(new MainFrm.ComboboxItem2(MainFrm.SID2DispName(s), s));

			Array arr = Enum.GetValues(typeof(PrintFilters));
			for (int i = arr.GetLowerBound(0); i < arr.GetUpperBound(0); i++)
			{
				string s = Enum.GetName(typeof(PrintFilters), arr.GetValue(i));
				cbPrintDocFilter.Items.Add(new MainFrm.ComboboxItem(MainFrm.SID2DispName(s), (int)arr.GetValue(i)));
			}
			
			cbPagesScale.SelectedIndex = 0; // none
			//Book
			cbSheetsHxV.SelectedIndex = 0;
			cbTypeBook.SelectedIndex = 0;
			cbSideBook.SelectedIndex = 0;
			//Mult
			cbOrderMult.SelectedIndex = 0;

			cbPrintDocFilter.SelectedIndex = 0; // document
			
		}

		private void tPages_TextChanged(object sender, EventArgs e)
		{
			rbPages.Checked = true;
		}

		private void tSheets_TextChanged(object sender, EventArgs e)
		{
			rbSheets.Checked = true;
		}

		/////////////////////////////////////////////////////////////////
		// IFormHelper
		/////////////////////////////////////////////////////////////////

		public bool IsValid()
		{
			bool bHasDoc = mainFrm.pdfCtl.Doc != null;
			return bHasDoc;
		}

		public void OnUpdate()
		{
			Enabled = IsValid();
			if (Enabled)
				lbNumPages.Text = String.Format("total {0} pages", mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count);
			else
				lbNumPages.Text = "";
		}

		public void OnSerialize(IOperation op)
		{
			if (op == null)
				return;
			
			ICabNode opts = op.Params.Root["Options"];

			// printer opts
			opts["PrinterName"].v = cbPrinter.Text;
			bool ok;
			opts["Copies"].v = (int)MainFrm.Str2Num(tCopies.Text, out ok, 1);
			opts["Collate"].v = ckCollate.Checked ? 1 : 0;
			opts["Duplex"].v = cbDuplex.SelectedIndex;
			opts["AsImages"].v = ckAsImage.Checked;

			opts["Paper.Name"].v = "A5";

			// pages range
			ICabNode pagesRange = opts["PagesRange"];
			RangeType rangeType = RangeType.RangeType_All;
			if (rbCurPage.Checked)
				rangeType = RangeType.RangeType_Current;
			else if (rbPages.Checked)
				rangeType = RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;
			pagesRange["Reversed"].v = ckPagesRevOrder.Checked;
			
			rangeType = RangeType.RangeType_All;
			if (cbPagesSubset.SelectedIndex == 1)
				rangeType = RangeType.RangeType_Odd;
			else if (cbPagesSubset.SelectedIndex != 0)
				rangeType = RangeType.RangeType_Even;
			pagesRange["Filter"].v = rangeType;

			MainFrm.ComboboxItem it = (MainFrm.ComboboxItem)cbPrintDocFilter.SelectedItem;
			if (it != null)
				opts["Content"].v = it.Value;

			

			// page scaling and placement
			opts["ScaleType"].String = ((MainFrm.ComboboxItem2)cbPagesScale.SelectedItem).Value;
			opts["ScaleType"].v = cbPagesScale.SelectedIndex;

			if (cbPagesScale.SelectedIndex <= (int)ScaleTypes.CustomZoom)
			{
				ICabNode ScaleSimple = opts["ScaleSimple"];
				ScaleSimple["AutoRotate"].v = ckAutoRotateSimple.Checked;
				ScaleSimple["AutoCentre"].v = ckAutoCenterSimple.Checked;
				ScaleSimple["PaperByPage"].v = ckPaperByPageSimple.Checked;
				ScaleSimple["PageZoom"].v = tPageZoomSimple.Value;
				ScaleSimple["IgnoreMargins"].v = ckIgnoreMarginsSimple.Checked;
			}
			else if (cbPagesScale.SelectedIndex >= (int)ScaleTypes.TileLarge && cbPagesScale.SelectedIndex <= (int)ScaleTypes.TileAll)
			{
				ICabNode ScaleTile = opts["ScaleTile"];
				ScaleTile["AutoRotate"].v = ckAutoRotateTile.Checked;
				ScaleTile["AutoCentre"].v = ckAutoCenterTile.Checked;
				ScaleTile["PageZoom"].v = tPageZoomTile.Value;
				ScaleTile["Overlap"].v = tOverlap.Value;
				ScaleTile["ShowCutMarks"].v = ckShowCutMarksTile.Checked;
				ScaleTile["ShowLabels"].v = ckShowLabelsTile.Checked;
				ScaleTile["IgnoreMargins"].v = ckIgnoreMarginsTile.Checked;
			}
			else if (cbPagesScale.SelectedIndex == (int)ScaleTypes.Multiple)
			{
				ICabNode ScaleMult = opts["ScaleMult"];
				ScaleMult["AutoRotate"].v = ckAutoRotateMult.Checked;
				ScaleMult["AutoCentre"].v = ckAutoCenterMult.Checked;
				ScaleMult["ShowBorder"].v = ckShowBorderMult.Checked;
				ScaleMult["IgnoreMargins"].v = ckIgnoreMarginsMult.Checked;
				ScaleMult["CountH"].v = Int32.Parse(tCountHMult.Text);
				ScaleMult["CountV"].v = Int32.Parse(tCountVMult.Text);
				ScaleMult["Order"].v = cbOrderMult.SelectedIndex;
			}
			else
			{
				ICabNode ScaleBook = opts["ScaleBook"];
				ScaleBook["Type"].v = cbTypeBook.SelectedIndex;
				ScaleBook["Side"].v = cbSideBook.SelectedIndex;
				ScaleBook["Binding"].v = ckBindingBook.Checked;
				ScaleBook["Signature"].v = tSignature.Value;
				ScaleBook["Gutter"].v = tGutter.Value;
				ScaleBook["AutoRotate"].v = ckAutoRotateBook.Checked;
				ScaleBook["AutoCentre"].v = ckAutoCenterBook.Checked;
				ScaleBook["IgnoreMargins"].v = ckIgnoreMarginsBook.Checked;
				//ScaleBook["FixBackSideRotation"].v =
			}
			//opts["ColorOverride"].v = cbClrOver.Text;
			//			opts["ColorOverride"].v = cbClrOver.SelectedIndex;


			opts["SheetsRange.Text"].v = (rbSheets.Checked) ? tSheets.Text : "1-" + mainFrm.pdfCtl.Doc.CoreDoc.Pages.Count;
			opts["SheetsRange.Reversed"].v = ckSheetsRevOrder.Checked;
		}

		private void cbPagesScale_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nIndex = cbPagesScale.SelectedIndex;
			gbSimple.Visible = (nIndex <= (int)ScaleTypes.CustomZoom);
			gbTile.Visible = (nIndex == (int)ScaleTypes.TileLarge || nIndex == (int)ScaleTypes.TileAll);
			gbMult.Visible = (nIndex == (int)ScaleTypes.Multiple);
			gbBook.Visible = (nIndex == (int)ScaleTypes.Booklet);
			//Simple
			tPageZoomSimple.Enabled = !( nIndex <= (int)ScaleTypes.FitToMargins);
			ckIgnoreMarginsSimple.Checked = (nIndex == (int)ScaleTypes.None || nIndex == (int)ScaleTypes.CustomZoom);
			ckIgnoreMarginsSimple.Enabled = !(nIndex <= (int)ScaleTypes.ReduceToMargins);
			//Tile
			//ckIgnoreMarginsTile.Checked = !(nIndex == (int)ScaleTypes.TileLarge || nIndex == (int)ScaleTypes.TileAll);
			//Book
			bool bCheckedBook = (nIndex == (int)ScaleTypes.Booklet);
			ckIgnoreMarginsBook.Checked = bCheckedBook;
			ckAutoCenterBook.Checked = bCheckedBook;
			ckAutoRotateBook.Checked = bCheckedBook;
		}

		private void cbSheetsHxV_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch ((Paper_per_Sheets)cbSheetsHxV.SelectedIndex)
			{ 
				case Paper_per_Sheets._4:
					tCountHMult.Value = 2;
					tCountVMult.Value = 2;
					break;
				case Paper_per_Sheets._6_V:	
					tCountHMult.Value = 2;
					tCountVMult.Value = 3;
					break;
				case Paper_per_Sheets._6_H:
					tCountHMult.Value = 3;
					tCountVMult.Value = 2;
					break;
				case Paper_per_Sheets._9:
					tCountHMult.Value = 3;
					tCountVMult.Value = 3;
					break;
				case Paper_per_Sheets._16:
					tCountHMult.Value = 4;
					tCountVMult.Value = 4;
					break;
				case Paper_per_Sheets.Custom:
					tCountHMult.Focus();
					break;
			}
		}

		private void tCountHMult_Click(object sender, EventArgs e)
		{
			cbSheetsHxV.SelectedIndex = (int)Paper_per_Sheets.Custom;
		}

		private void tCountVMult_Click(object sender, EventArgs e)
		{
			cbSheetsHxV.SelectedIndex = (int)Paper_per_Sheets.Custom;
		}

		private void cbTypeBook_SelectedIndexChanged(object sender, EventArgs e)
		{
			tSignature.Enabled = (cbTypeBook.SelectedIndex == 1);
		}

		private void btnMore_Click(object sender, EventArgs e)
		{
			int nPrintFilters = 0;
			MainFrm.ComboboxItem it = (MainFrm.ComboboxItem)cbPrintDocFilter.SelectedItem;
			if (it != null)
				nPrintFilters = it.Value;
			PrintAdvancedOptions tempDialog = new PrintAdvancedOptions(this, nPrintFilters);
			tempDialog.ShowDialog();
			if (nPrintFilters != m_nPrinterFlags)
			{
				bool bNeedCustomFilter = true;
				for (int i = 0; i < cbPrintDocFilter.Items.Count; i++)
				{
					MainFrm.ComboboxItem item = (MainFrm.ComboboxItem)cbPrintDocFilter.Items[i];
					if (item != null)
						if (item.Value == m_nPrinterFlags)
						{
							cbPrintDocFilter.SelectedIndex = i;
							bNeedCustomFilter = false;
							break;
						}
				}
				if (bNeedCustomFilter)
				{
					string sCustom = "Custom Content";
					if (!cbPrintDocFilter.Items.Contains(sCustom))
					{
						cbPrintDocFilter.Items.Add(new MainFrm.ComboboxItem(sCustom, m_nPrinterFlags));
						cbPrintDocFilter.SelectedIndex = 0;
						//because cbPrintDocFilter have properties Sorted
						//and this value is 0									
					}
					else
					{
						int index = cbPrintDocFilter.FindString(sCustom);
						MainFrm.ComboboxItem item = (MainFrm.ComboboxItem)cbPrintDocFilter.Items[index];
						item.Value = m_nPrinterFlags;
					}
				}
			}
		}
	}
}
