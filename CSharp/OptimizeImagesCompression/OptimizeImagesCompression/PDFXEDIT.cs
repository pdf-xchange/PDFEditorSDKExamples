using System;
using System.Diagnostics;
using System.IO;
using PDFXEdit;

namespace OptimizeImagesCompression
{
    internal class Pdfxedit
    {
        public PXV_Inst MInst;
        public IPXC_Inst MPxcInst;
        public IAFS_Inst FsInst;

        public void InitPdfControl()
        {
            var pathToPdfOptimizer = Path.Combine(Environment.CurrentDirectory, "PDFOptimizer.pvp");
            MInst = new PXV_Inst();
            MInst.Init();
            MInst.StartLoadingPlugins();
            MInst.AddPluginFromFile(pathToPdfOptimizer);
            MInst.FinishLoadingPlugins();
            MPxcInst = MInst.GetExtension("PXC") as IPXC_Inst;
            if (MPxcInst != null) FsInst = (IAFS_Inst) MPxcInst.GetExtension("AFS");
            Debug.WriteLine("InitPdfControl() succesfull");
        }

        public void OptimizeDocument(OperationParameters operation)
        {
            try
            {
                var nId = MInst.Str2ID(@"op.document.optimize", false);
                var op = MInst.CreateOp(nId);
                var input = op.Params.Root["Input"];
                var impPath = FsInst.DefaultFileSys.StringToName(operation.FilePath);
                ICabNode options = op.Params.Root["Options"];
                ICabNode images = options["Images"];
                images["Enabled"].v = true;
                images["ReducedOnly"].v = false;
                ICabNode comp = images["Comp"];
                //set all methods to retain existing
                comp["Color.Method"].v = 0;
                comp["Grayscale.Method"].v = 0;
                comp["Indexed.Method"].v = 0;
                comp["Mono.Method"].v = 0;
                //set my params
                var opParam = operation.CompMode + "." + "Method";
                comp[opParam].v = operation.Method;
                if ((operation.CompMode == "Color") | (operation.CompMode == "Grayscale") &&
                    (operation.Method == 1) | (operation.Method == 2))
                    comp[operation.CompMode + "." + "JPEGQuality"].v = operation.Quality;
                var resDoc = MPxcInst.OpenDocumentFrom(impPath, null);
                input.Add().v = resDoc;
                op.Do();
                resDoc.WriteToFile(operation.OutputFilePath);
                operation.ErrCodes = string.Empty;
            }
            catch (Exception e)
            {
                operation.ErrCodes = e.Message;
                Console.WriteLine(e.Message);
            }
        }
    }
}
