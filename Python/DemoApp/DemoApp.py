import os
import sys
import comtypes
from ctypes import c_ulong, byref
from comtypes.client import GetModule, CreateObject
path = os.environ['PXCE_BIN32D_PATH']
# pathDLL = path + "\\PDFXEditCore.x86.dll"
# generate wrapper code for the type library, this needs
# to be done only once (but also each time the IDL file changes)
GetModule(path + "\\PDFXEditCore.x86.dll");

import comtypes.gen.PDFXEdit as PDFXEdit

g_Inst = CreateObject("PDFXEdit.PXV_Inst", None, None, PDFXEdit.IPXV_Inst)
g_Inst.Init(None, "Key", None, None, None, 0, None);
g_Inst.StartLoadingPlugins();
g_Inst.AddPluginFromFile(path + "\\Plugins.x86\\ConvertPDF.pvp");
g_Inst.FinishLoadingPlugins();

pxcInst = g_Inst.GetExtension("PXC").QueryInterface(PDFXEdit.IPXC_Inst);
afsInst = g_Inst.GetExtension("AFS").QueryInterface(PDFXEdit.IAFS_Inst);
pDoc = None;
try:
    cnv = None;
    for i in range(0, g_Inst.ExportConvertersCount):
        if (g_Inst.ExportConverter[i].ID == "conv.exp.office.docx"):
            cnv = g_Inst.ExportConverter[i];

    pDoc = pxcInst.OpenDocumentFromFile ("D:\\README11.pdf", None, None, 0, 0);

    fs = afsInst.DefaultFileSys;
    pName = fs.StringToName("D:\\TestFile_res.docx", 0, None);
    fileNew = fs.OpenFile(pName, PDFXEdit.AFS_OpenFile_CreateAlways| PDFXEdit.AFS_OpenFile_Read | PDFXEdit.AFS_OpenFile_ShareRead, None, None);
    cabNew = g_Inst.GetFormatConverterParams(False, u"conv.exp.office.docx");
    cnv.Convert(g_Inst, pDoc, fileNew, 0, cabNew, None, 0, None, None);
except comtypes.COMError as e:
    print(e.text)
pDoc.Close()
g_Inst.Shutdown(0)
