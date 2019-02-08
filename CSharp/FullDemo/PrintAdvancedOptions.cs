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
	public partial class PrintAdvancedOptions : Form
	{
		private PrintForm m_parent;


		int[] ResolutionDPI = new int[] {50, 72, 100, 150, 300, 400, 600};

		public PrintAdvancedOptions(PrintForm frm1, int PrintFilter)
		{
			InitializeComponent();
			m_parent = frm1;

			Array arr = Enum.GetValues(typeof(PXC_PrintColorOverrideMode));
			for (int i = arr.GetLowerBound(0); i < arr.GetUpperBound(0); i++)
			{ 
				string s = Enum.GetName(typeof(PXC_PrintColorOverrideMode), arr.GetValue(i));
				cbClrOver.Items.Add(new MainFrm.ComboboxItem(MainFrm.SID2DispName(s), (int)arr.GetValue(i)));
			}

			for (int i = ResolutionDPI.GetLowerBound(0); i <= ResolutionDPI.GetUpperBound(0); i++)
			{
				cbBitmapDPI.Items.Add(new MainFrm.ComboboxItem(ResolutionDPI[i]+" dpi", ResolutionDPI[i]));
			}
			for (int i = ResolutionDPI.GetLowerBound(0); i <= ResolutionDPI.GetUpperBound(0); i++)
			{
				cbGradientDPI.Items.Add(new MainFrm.ComboboxItem(ResolutionDPI[i] + " dpi", ResolutionDPI[i]));
			}

			arr = Enum.GetValues(typeof(PXC_PrintTextModes));
			for (int i = arr.GetLowerBound(0); i < arr.GetUpperBound(0); i++)
			{
				string s = Enum.GetName(typeof(PXC_PrintTextModes), arr.GetValue(i));
				cbTextMode.Items.Add(new MainFrm.ComboboxItem(MainFrm.SID2DispName(s), (int)arr.GetValue(i)));
			}
			cbTextMode.SelectedIndex = 0;
			cbLineMode.SelectedIndex = 0;
			cbBitmapDPI.SelectedIndex = 4;
			cbGradientDPI.SelectedIndex = 3;

			PXC_PrintContentFlags flags = (PXC_PrintContentFlags)PrintFilter;
			ckPageContent.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_Page);
			ckMarkups.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_Markups);
			ckStamps.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_Stamps);
			ckFormFields.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_Widgets);
			ckDataOnly.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_FieldsDataOnly);
			ckMediaAnnot.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_Media);
			ckMarksAnnot.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_PrintMarks);
			ckNotes.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_Notes);
			ckNotePop_Up.Checked = flags.HasFlag(PXC_PrintContentFlags.PrintContent_NotePopups);
			cbClrOver.SelectedIndex = 0;
		}

		private void ckFormFields_CheckedChanged(object sender, EventArgs e)
		{
			ckDataOnly.Enabled = ckFormFields.Checked;
		}

		private void ckNotes_CheckedChanged(object sender, EventArgs e)
		{
			ckNotePop_Up.Enabled = ckNotes.Checked;
		}

		private void ckNotePop_Up_CheckedChanged(object sender, EventArgs e)
		{
			tOpacity.Enabled = ckNotePop_Up.Checked;
		}
		private void btnOk_Click(object sender, EventArgs e)
		{
			int flags = 0;
			if (ckPageContent.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_Page;
			if (ckMarkups.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_Markups;
			if (ckStamps.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_Stamps;
			if (ckFormFields.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_Widgets;
			if (ckDataOnly.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_FieldsDataOnly;
			if (ckMediaAnnot.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_Media;
			if (ckMarksAnnot.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_PrintMarks;
			if (ckNotes.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_Notes;
			if (ckNotePop_Up.Checked)
				flags += (int)PXC_PrintContentFlags.PrintContent_NotePopups;
			PrintForm.m_nPrinterFlags = flags;
			PrintForm.m_bIgnoreDocClrOverrides = ckIgnoreDocClrOverrides.Checked;
			PrintForm.m_bIgnoreCropClip = ckIgnoreCropClip.Checked;
			PrintForm.m_nTextMode = ((MainFrm.ComboboxItem)cbTextMode.SelectedItem).Value;
			PrintForm.m_nBitmapDPI = ((MainFrm.ComboboxItem)cbBitmapDPI.SelectedItem).Value;
			PrintForm.m_nGradientDPI = ((MainFrm.ComboboxItem)cbGradientDPI.SelectedItem).Value;
			PrintForm.m_nColorOverride = ((MainFrm.ComboboxItem)cbClrOver.SelectedItem).Value;				
			//value Line Mode don`t use
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
