using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
	class PDFXEDIT
	{
		public PDFXEdit.PXV_Inst m_Inst = null;

		public PDFXEdit.IPXC_Inst m_pxcInst = null;
		public PDFXEdit.IAFS_Inst fsInst = null;

		public void InitPDFControl()

		{

			m_Inst = new PDFXEdit.PXV_Inst();
			m_Inst.Init();
			m_Inst.StartLoadingPlugins();
			m_Inst.AddPluginFromFile(@"D:\Project\PDF5.2012\Trunk\_build\Debug.x64\Plugins.x64\PDFOptimizer.pvp");
			m_Inst.FinishLoadingPlugins();
			m_pxcInst = m_Inst.GetExtension("PXC") as PDFXEdit.IPXC_Inst;
			fsInst = (PDFXEdit.IAFS_Inst)m_pxcInst.GetExtension("AFS");

		}
	   
		public void OptimizeDocument(string InputFilePath, string OutputFilePath)

		{
			try
			{
				PDFXEdit.IAFS_Name impPath = fsInst.DefaultFileSys.StringToName(InputFilePath);
				PDFXEdit.IPXC_Document resDoc = m_pxcInst.OpenDocumentFrom(impPath, null);


				int nID = m_Inst.Str2ID("op.document.optimize", false);
				PDFXEdit.IOperation Op = m_Inst.CreateOp(nID);
				var input = Op.Params.Root["Input"];

				//Then pass it to the optimization operation
				input.Add().v = resDoc;
				PDFXEdit.ICabNode options = Op.Params.Root["Options"];
				PDFXEdit.ICabNode images = options["Images"];
				images["Enabled"].v = true;
				images["ReducedOnly"].v = true;
				PDFXEdit.ICabNode comp = images["Comp"];
				comp["Color.JPEGQuality"].v = 0;
				comp["Grayscale.JPEGQuality"].v = 0;
				Op.Do();

				var output = Op.Params.Root["Output"];
				//And save the optimized document again to the same file
				//PDFXEdit.IPXC_Document outDoc = output.v;
				resDoc.WriteToFile(OutputFilePath);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

	}
}
