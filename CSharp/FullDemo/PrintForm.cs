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

		enum PrintFilters
		{	
			PrintContent_Doc				= PDFXEdit.PXC_PrintContentFlags.PrintContent_Page | PDFXEdit.PXC_PrintContentFlags.PrintContent_Media | PDFXEdit.PXC_PrintContentFlags.PrintContent_Widgets | PDFXEdit.PXC_PrintContentFlags.PrintContent_PrintMarks,
			PrintContent_DocAndMarkups		= PDFXEdit.PXC_PrintContentFlags.PrintContent_Page | PDFXEdit.PXC_PrintContentFlags.PrintContent_Media | PDFXEdit.PXC_PrintContentFlags.PrintContent_Markups | PDFXEdit.PXC_PrintContentFlags.PrintContent_Stamps | PDFXEdit.PXC_PrintContentFlags.PrintContent_Widgets | PDFXEdit.PXC_PrintContentFlags.PrintContent_PrintMarks,
			PrintContent_DocAndStamps		= PDFXEdit.PXC_PrintContentFlags.PrintContent_Page | PDFXEdit.PXC_PrintContentFlags.PrintContent_Media | PDFXEdit.PXC_PrintContentFlags.PrintContent_Stamps | PDFXEdit.PXC_PrintContentFlags.PrintContent_Widgets | PDFXEdit.PXC_PrintContentFlags.PrintContent_PrintMarks,
			PrintContent_WidgetsDataOnly	= PDFXEdit.PXC_PrintContentFlags.PrintContent_Widgets | PDFXEdit.PXC_PrintContentFlags.PrintContent_FieldsDataOnly,
			PrintContent_MarkupsOnly		= PDFXEdit.PXC_PrintContentFlags.PrintContent_Markups,
	
			PrintContent_Whole				= 	PDFXEdit.PXC_PrintContentFlags.PrintContent_Page		|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_Markups		|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_Stamps		|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_Widgets		|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_Notes		|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_NotePopups	|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_Media		|
												PDFXEdit.PXC_PrintContentFlags.PrintContent_PrintMarks,

		};


		public PrintForm(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;

			InitializeComponent();

			PDFXEdit.IUniqueStrings prnList = mainFrm.pdfCtl.Inst.GetPrinters();

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
			cbPrintDocFilter.SelectedIndex = 0; // document
			cbClrOver.SelectedIndex = 0;
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

		public void OnSerialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;
			
			PDFXEdit.ICabNode opts = op.Params.Root["Options"];

			// printer opts
			opts["PrinterName"].v = cbPrinter.Text;
			bool ok;
			opts["Copies"].v = (int)MainFrm.Str2Num(tCopies.Text, out ok, 1);
			opts["Collate"].v = ckCollate.Checked ? 1 : 0;
			opts["Duplex"].v = cbDuplex.SelectedIndex;

			opts["Collate"].v = ckCollate.Checked ? 1 : 0;

			opts["AsImages"].v = ckAsImage.Checked;

			opts["Paper.Name"].v = "A4";

			// pages range
			PDFXEdit.ICabNode pagesRange = opts["PagesRange"];
			PDFXEdit.RangeType rangeType = PDFXEdit.RangeType.RangeType_All;
			if (rbCurPage.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Current;
			else if (rbPages.Checked)
				rangeType = PDFXEdit.RangeType.RangeType_Exact;
			pagesRange["Type"].v = rangeType;
			pagesRange["Text"].v = tPages.Text;
			pagesRange["Reversed"].v = ckPagesRevOrder.Checked;
			
			rangeType = PDFXEdit.RangeType.RangeType_All;
			if (cbPagesSubset.SelectedIndex == 1)
				rangeType = PDFXEdit.RangeType.RangeType_Odd;
			else if (cbPagesSubset.SelectedIndex != 0)
				rangeType = PDFXEdit.RangeType.RangeType_Even;
			pagesRange["Filter"].v = rangeType;

			MainFrm.ComboboxItem it = (MainFrm.ComboboxItem)cbPrintDocFilter.SelectedItem;
			if (it != null)
				opts["Content"].v = it.Value;

			// page scaling and placement
			opts["ScaleType"].String = ((MainFrm.ComboboxItem2)cbPagesScale.SelectedItem).Value;
			opts["ScaleType"].v = cbPagesScale.SelectedIndex;

			opts["ColorOverride"].v = cbClrOver.Text;
//			opts["ColorOverride"].v = cbClrOver.SelectedIndex;


			if (rbSheets.Checked)
				opts["SheetsRange.Text"].v = tSheets.Text;
		}
	}
}
