using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FullDemo
{
	public enum DemoFlags
	{
		Input_Doc				= 0x00000001,
		Input_File				= 0x00000002,
		Input_PdfFile			= 0x00000004,
		Input_TxtFile			= 0x00000008,
		Input_RtfFile			= 0x00000010,
		Input_AllSupp			= 0x00000020,
		Input_AllSuppImg		= 0x00000040,
		Input_AllSuppRasterImg	= 0x00000080,
		Input_MultFiles			= 0x00008000,
		//
		Input_Mask				= 0x0000FFFF,
		//
		Output_Doc				= 0x00010000,
		//
		RunOnlyWithStdDlg		= 0x20000000,
		SyncDo					= 0x40000000,
	};

	class OperationDemo
	{
		public OperationDemo(string text, int id, Form ui, uint flags = 0)
		{
			Text = text;
			ID = id;
			UI = ui;
			Height = (ui != null) ? ui.Height : 0;
			Flags = flags;
		}

		public int ID { get; set; }
		public string Text { get; set; }
		public Form UI { get; set; }
		public int Height { get; set; }
		public uint Flags { get; set; }
		public override string ToString()
		{
			return Text;
		}

		public bool DocIsRequired()
		{
			return ((Flags & (uint)DemoFlags.Input_Doc) != 0);
		}

		public virtual bool OnBeforeRun(MainFrm mainFrm, PDFXEdit.IOperation op)
		{
			return true;
		}
	
		public virtual bool Run(MainFrm mainFrm, bool bShowOpDlg, bool bAllowOpUI)
		{
			PDFXEdit.IOperation op = null;
			try
			{
				op = mainFrm.pdfCtl.Inst.CreateOp(ID);
			}
			catch
			{
				return false;
			}

			if (op == null)
				return false;

			Form ui = UI;
			if (ui != null)
			{
				IFormHelper hlp = (IFormHelper)ui;
				if (hlp != null)
					hlp.OnSerialize(op);
			}

			uint flags = Flags;

			if ((flags & (uint)DemoFlags.Input_Doc) != 0)
			{
				PDFXEdit.IPXV_Document doc = mainFrm.pdfCtl.Doc;
				if (doc == null)
					return false;
				PDFXEdit.ICabNode input = op.Params.Root["Input"];
				if (input.Type == PDFXEdit.CabDataTypeID.dt_Array)
					input.Add().v = doc;
				else
					input.v = doc;
			}
			else if (!bShowOpDlg && ((flags & (uint)DemoFlags.Input_Mask) != 0))
			{
				string fileFilter = "";
				if ((flags & (uint)DemoFlags.Input_AllSupp) != 0)
					fileFilter = "<allSupp>";
				else if ((flags & (uint)DemoFlags.Input_AllSuppImg) != 0)
					fileFilter = "<allSuppImg>";
				else if ((flags & (uint)DemoFlags.Input_AllSuppRasterImg) != 0)
					fileFilter = "<allSuppRasterImg>";
				else if ((flags & (uint)DemoFlags.Input_PdfFile) != 0)
					fileFilter = "PDF Documents (*.pdf)|*.pdf";
				else if ((flags & (uint)DemoFlags.Input_TxtFile) != 0)
					fileFilter = "Plain Text Documents (*.txt)|*.txt";
				else if ((flags & (uint)DemoFlags.Input_RtfFile) != 0)
					fileFilter = "RTF Files (*.rtf)|*.rtf";

				PDFXEdit.IAFS_NamesCollection fileNames = mainFrm.ShowOpenFilesDlg((flags & (uint)DemoFlags.Input_MultFiles) != 0, fileFilter);
				if (fileNames == null || (fileNames.Count == 0))
					return false;

				PDFXEdit.ICabNode input = op.Params.Root["Input"];
				if (input.Type == PDFXEdit.CabDataTypeID.dt_Array)
				{
					for (uint i = 0; i < fileNames.Count; i++)
						input.Add().v = fileNames[i];
				}
				else
				{
					input.v = fileNames[0];
				}
			}

			if (bShowOpDlg)
			{
				try
				{
					op.ShowSetupUI((uint)mainFrm.Handle);
				}
				catch (Exception ex)
                {
                    int hr = Marshal.GetHRForException(ex);
					if (hr != HResults.E_NOTIMPL)
						return false;
                }
			}

			if (!OnBeforeRun(mainFrm, op))
				return false;


			int opExecFlags = 0;
			if (!bAllowOpUI)
				opExecFlags |= (int)PDFXEdit.OpExecFlags.OpExecFlag_NoUI;
			
			try
			{
				if ((flags & (int)DemoFlags.SyncDo) != 0)
					op.Do(opExecFlags);
				else
					mainFrm.pdfCtl.Inst.AsyncDoAndWaitForFinish(op, (uint)opExecFlags);
			}
			catch (Exception ex)
			{
				int hr = Marshal.GetHRForException(ex);
				mainFrm.ShowErrMsg(hr);

				return false;
			}

			if ((flags & (int)DemoFlags.Output_Doc) != 0)
			{
				PDFXEdit.ICabNode output = op.Params.Root["Output"];
				PDFXEdit.IPXC_Document newCoreDoc = null;
				try
				{
					if (output.Type == PDFXEdit.CabDataTypeID.dt_Array)
					{
						if (output.Count != 0)
							newCoreDoc = (PDFXEdit.IPXC_Document)output[0].Unknown;
					}
					else
					{
						newCoreDoc = (PDFXEdit.IPXC_Document)output.Unknown;
					}

					if (newCoreDoc != null)
						mainFrm.pdfCtl.OpenDocFrom(newCoreDoc);
				}
				catch { }
			}

			return true;
		}
	}
}
