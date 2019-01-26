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
	public partial class Rename : Form, IFormHelper
	{
		private MainFrm mainFrm = null;
		public Rename(MainFrm mainFrm)
		{
			this.mainFrm = mainFrm;
			InitializeComponent();
		}

		public bool IsValid()
		{
			return mainFrm.pdfCtl.HasDoc;
		}

		public void OnUpdate()
		{
			Enabled = IsValid();
		}

		public void OnSerialize(PDFXEdit.IOperation op)
		{
			if (op == null)
				return;

			PDFXEdit.ICabNode opts = op.Params.Root["Options"];
		}
	}
}
