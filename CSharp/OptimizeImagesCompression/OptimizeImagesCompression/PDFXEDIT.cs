using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class PDFXEDIT
    {
        public PDFXEdit.PXV_Inst m_Inst;

        public PDFXEdit.IPXC_Inst m_pxcInst;
        public PDFXEdit.IAFS_Inst fsInst;




        public void InitPDFControl()

        {
            string path_to_PDFOptimizer = Path.Combine(Environment.CurrentDirectory, "PDFOptimizer.pvp");

            m_Inst = new PDFXEdit.PXV_Inst();
            m_Inst.Init();
            m_Inst.StartLoadingPlugins();
            m_Inst.AddPluginFromFile(path_to_PDFOptimizer);
            m_Inst.FinishLoadingPlugins();
            m_pxcInst = m_Inst.GetExtension("PXC") as PDFXEdit.IPXC_Inst;
            fsInst = (PDFXEdit.IAFS_Inst)m_pxcInst.GetExtension("AFS");
            System.Diagnostics.Debug.WriteLine("InitPDFControl() succesfull");
        }

        public void OptimizeDocument(string InputFilePath, string OutputFilePath, string Color, int Method_param, int Quality_Jpeg, out string ErrCodes)
        {
            try
            {
                string OpParam = Color + "." + "Method";
               int nID = m_Inst.Str2ID("op.document.optimize", false);
                PDFXEdit.IOperation Op = m_Inst.CreateOp(nID);

                var input = Op.Params.Root["Input"];
                PDFXEdit.IAFS_Name impPath = fsInst.DefaultFileSys.StringToName(InputFilePath);
                PDFXEdit.ICabNode options = Op.Params.Root["Options"];
                PDFXEdit.ICabNode images = options["Images"];
                images["Enabled"].v = true;
                images["ReducedOnly"].v = true;
                PDFXEdit.ICabNode comp = images["Comp"];
                comp["Color.Method"].v = 0;
                comp["Grayscale.Method"].v = 0;
                comp["Indexed.Method"].v = 0;
                comp["Mono.Method"].v = 0;
                comp[OpParam].v = Method_param;
                if (Quality_Jpeg != 0)
                {
                    comp[Color + "." + "JPEGQuality"].v = Quality_Jpeg - 1;
                }
                PDFXEdit.IPXC_Document resDoc = m_pxcInst.OpenDocumentFrom(impPath, null);
                input.Add().v = resDoc;
                Op.Do();
                resDoc.WriteToFile(OutputFilePath);
                ErrCodes = "0x0";
            }
            catch (Exception e)
            {
                ErrCodes = e.Message;
                Console.WriteLine(e.Message);
            }
        }

    }
}
