using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
	class PDFXEDIT
	{
		public PDFXEdit.PXV_Inst m_Inst ;

		public PDFXEdit.IPXC_Inst m_pxcInst ;
		public PDFXEdit.IAFS_Inst fsInst ;
        public PDFXEdit.IAFS_Name impPath ;
        public PDFXEdit.IPXC_Document resDoc ;
        public PDFXEdit.IOperation Op;



        public void InitPDFControl()

		{
            string   path_to_PDFOptimizer = Path.Combine(Environment.CurrentDirectory, "PDFOptimizer.pvp");

            m_Inst = new PDFXEdit.PXV_Inst();
			m_Inst.Init();
			m_Inst.StartLoadingPlugins();
			m_Inst.AddPluginFromFile(path_to_PDFOptimizer);
			m_Inst.FinishLoadingPlugins();
			m_pxcInst = m_Inst.GetExtension("PXC") as PDFXEdit.IPXC_Inst;
			fsInst = (PDFXEdit.IAFS_Inst)m_pxcInst.GetExtension("AFS");
            System.Diagnostics.Debug.WriteLine("InitPDFControl() succesfull");
		}

        public void SetOptParams(string Color, int Method_param)
        {
            string OpParam = Color + "." + "Method";

            int nID = m_Inst.Str2ID("op.document.optimize", false);
            Op = m_Inst.CreateOp(nID);
            var input = Op.Params.Root["Input"];
            input.Add().v = resDoc;
            PDFXEdit.ICabNode options = Op.Params.Root["Options"];
            PDFXEdit.ICabNode images = options["Images"];
            images["Enabled"].v = true;
            images["ReducedOnly"].v = true;
            PDFXEdit.ICabNode comp = images["Comp"];
            comp[OpParam].v = Method_param;
           




            System.Diagnostics.Debug.WriteLine("Optimize begin");
        }
        public void OptimizeDocument(string InputFilePath, string OutputFilePath, out string ErrCodes)
		{
            try
			{
                impPath = fsInst.DefaultFileSys.StringToName(InputFilePath);
				resDoc = m_pxcInst.OpenDocumentFrom(impPath, null);
                Op.Do();
                System.Diagnostics.Debug.WriteLine("Optimize end");
                var output = Op.Params.Root["Output"];
				resDoc.WriteToFile(OutputFilePath);
                System.Diagnostics.Debug.WriteLine("Write File ended");
                ErrCodes = "";
			}
			catch (Exception e)
			{
               ErrCodes = "";
               ErrCodes = e.Message;
               Console.WriteLine(e.Message);
			}
		}
        public string GetParamsForOperation()
        {
            string[] all_params = { };

        return "";
        }


    }
}
