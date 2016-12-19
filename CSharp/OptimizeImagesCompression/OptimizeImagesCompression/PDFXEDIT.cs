using System;
using System.IO;


namespace OptimizeImagesCompression
{
    class Pdfxedit
    {
        public PDFXEdit.PXV_Inst m_Inst;
        public PDFXEdit.IPXC_Inst m_pxcInst;
        public PDFXEdit.IAFS_Inst fsInst;

        public void InitPdfControl()
        {
            string pathToPdfOptimizer = Path.Combine(Environment.CurrentDirectory, "PDFOptimizer.pvp");
            m_Inst = new PDFXEdit.PXV_Inst();
            m_Inst.Init();
            m_Inst.StartLoadingPlugins();
            m_Inst.AddPluginFromFile(pathToPdfOptimizer);
            m_Inst.FinishLoadingPlugins();
            m_pxcInst = m_Inst.GetExtension("PXC") as PDFXEdit.IPXC_Inst;
            if (m_pxcInst != null) fsInst = (PDFXEdit.IAFS_Inst)m_pxcInst.GetExtension("AFS");
            System.Diagnostics.Debug.WriteLine("InitPdfControl() succesfull");
        }

        public void OptimizeDocument(string inputFilePath, string outputFilePath, string color, int methodParam, int qualityJpeg, out string errCodes)
        {
            try
            {
                string opParam = color + "." + "Method";
                int nId = m_Inst.Str2ID("op.document.optimize", false);
                PDFXEdit.IOperation op = m_Inst.CreateOp(nId);
                var input = op.Params.Root["Input"];
                PDFXEdit.IAFS_Name impPath = fsInst.DefaultFileSys.StringToName(inputFilePath);
                PDFXEdit.ICabNode options = op.Params.Root["Options"];
                PDFXEdit.ICabNode images = options["Images"];
                images["Enabled"].v = true;
                images["ReducedOnly"].v = true;
                PDFXEdit.ICabNode comp = images["Comp"];
                comp["Color.Method"].v = 0;
                comp["Grayscale.Method"].v = 0;
                comp["Indexed.Method"].v = 0;
                comp["Mono.Method"].v = 0;
                comp[opParam].v = methodParam;
                if (qualityJpeg != 0)
                {
                    comp[color + "." + "JPEGQuality"].v = qualityJpeg - 1;
                }
                PDFXEdit.IPXC_Document resDoc = m_pxcInst.OpenDocumentFrom(impPath, null);
                input.Add().v = resDoc;
                op.Do();
                resDoc.WriteToFile(outputFilePath);
                errCodes = "0x0";
            }
            catch (Exception e)
            {
                errCodes = e.Message;
                Console.WriteLine(e.Message);
            }
        }

    }
}
