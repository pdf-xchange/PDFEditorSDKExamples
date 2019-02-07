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

		string[] ResolutionDPI = new string[] {"50", "72", "100", "150", "300", "400", "600"};

		public PrintAdvancedOptions(PrintForm frm1, int PrintFilter)
		{
			InitializeComponent();
			m_parent = frm1;

			cbTextMode.SelectedIndex = 0;

			cbBitmapDPI.Items.AddRange(ResolutionDPI);
			cbBitmapDPI.SelectedIndex = 4;
			cbGradientDPI.Items.AddRange(ResolutionDPI);
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
			PrintForm.m_nTextMode = cbTextMode.SelectedIndex;//don`t correct
			PrintForm.m_nBitmapDPI = Convert.ToInt32(ResolutionDPI[cbBitmapDPI.SelectedIndex]);
			PrintForm.m_nGradientDPI = Convert.ToInt32(ResolutionDPI[cbGradientDPI.SelectedIndex]);
			
			//value Line Mode don`t use
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
