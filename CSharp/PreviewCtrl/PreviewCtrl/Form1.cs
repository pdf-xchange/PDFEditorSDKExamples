using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFXEdit;

namespace PreviewCtrl
{
	public partial class Form1 : Form
	{
		public IPXV_Inst inst = new PXV_Inst();
		
		public Form1()
		{
			InitializeComponent();
		}

		private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			int nID = inst.Str2ID("op.openDoc", false);
			PDFXEdit.IOperation Op = inst.CreateOp(nID);
			PDFXEdit.IAFS_Inst fsInst = (PDFXEdit.IAFS_Inst)inst.GetExtension("AFS");
			PDFXEdit.IAFS_Name name = fsInst.DefaultFileSys.StringToName(@"D:\test.font.mapping.file.pdf");
			var input = Op.Params.Root["Input"];
			input.v = name;
			PDFXEdit.ICabNode options = Op.Params.Root["Options"];
			options["NativeOnly"].v = true;
			Op.Do();
			PDFXEdit.IPXC_Document doc = (PDFXEdit.IPXC_Document)Op.Params.Root["Output"].v;
			previewCtrl1.pagesPreviewCtl.Doc = doc;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			inst.Init(null, "Key");
			previewCtrl1.LoadInst(inst);
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			inst.Shutdown(0);
		}

	}
}
