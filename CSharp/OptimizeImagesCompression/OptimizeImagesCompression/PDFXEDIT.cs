using System;
using System.IO;


namespace OptimizeImagesCompression
{
    class Pdfxedit
    {
        public PDFXEdit.PXV_Inst MInst;
        public PDFXEdit.IPXC_Inst MPxcInst;
        public PDFXEdit.IAFS_Inst FsInst;

        public void InitPdfControl()
        {
            string pathToPdfOptimizer = Path.Combine(Environment.CurrentDirectory, "PDFOptimizer.pvp");
            MInst = new PDFXEdit.PXV_Inst();
            MInst.Init();
            MInst.StartLoadingPlugins();
            MInst.AddPluginFromFile(pathToPdfOptimizer);
            MInst.FinishLoadingPlugins();
            MPxcInst = MInst.GetExtension("PXC") as PDFXEdit.IPXC_Inst;
            if (MPxcInst != null) FsInst = (PDFXEdit.IAFS_Inst)MPxcInst.GetExtension("AFS");
            System.Diagnostics.Debug.WriteLine("InitPdfControl() succesfull");
        }

        public void OptimizeDocument(string inputFilePath, string outputFilePath, string compMode, int method, int quality, out string errCodes)
        {
            try
            {
                 int nId = MInst.Str2ID(@"op.document.optimize", false);
                 PDFXEdit.IOperation op = MInst.CreateOp(nId);
                 var input = op.Params.Root["Input"];
                 PDFXEdit.IAFS_Name impPath = FsInst.DefaultFileSys.StringToName(inputFilePath);
                 PDFXEdit.ICabNode options = op.Params.Root["Options"];
                 PDFXEdit.ICabNode images = options["Images"];
                 images["Enabled"].v = true;
                 images["ReducedOnly"].v = false;
                 PDFXEdit.ICabNode comp = images["Comp"];
                 //set all methods to retain existing
                 comp["Color.Method"].v = 0;
                 comp["Grayscale.Method"].v = 0;
                 comp["Indexed.Method"].v = 0;
                 comp["Mono.Method"].v = 0;
                 //set my params
                 string opParam = compMode + "." + "Method";
                 comp[opParam].v = method;
                 if ((compMode == "Color" | compMode == "Grayscale") && method == 1 | method == 2)
                     comp[compMode + "." + "JPEGQuality"].v = quality;
                 PDFXEdit.IPXC_Document resDoc = MPxcInst.OpenDocumentFrom(impPath, null);
                 input.Add().v = resDoc;
                 op.Do();
                 resDoc.WriteToFile(outputFilePath);
                
                errCodes = String.Empty;
                
               
            }
            catch (Exception e)
            {
                errCodes = e.Message;
                Console.WriteLine(e.Message);
            }
        }

    }
}
