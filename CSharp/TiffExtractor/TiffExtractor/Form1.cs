using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Threading;

namespace TiffExtractor
{
	public partial class Form1 : Form
	{
		List<string> m_aFiles = new List<string>();
		PDFXEdit.PXV_Inst m_Inst = null;
		PDFXEdit.IPXC_Inst m_pxcInst = null;
		int m_nID = 0;
		int m_nSavedFilesCount = 0;

		public Form1()
		{
			InitializeComponent();
			InitPDFControl();
		}

		private void InitPDFControl()
		{
			m_Inst = new PDFXEdit.PXV_Inst();
			m_Inst.Init();
			m_pxcInst = (PDFXEdit.IPXC_Inst)m_Inst.GetExtension("PXC");
			m_nID = m_Inst.Str2ID("op.document.exportToImages", false);
		}

		private void FillFilesArray()
		{
			// Create an instance of the open file dialog box.
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			// Set filter options and filter index.
			openFileDialog1.Filter = "PDF (.pdf)|*.pdf|All Files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;

			openFileDialog1.Multiselect = true;

			// Call the ShowDialog method to show the dialog box.
			DialogResult userClickedOK = openFileDialog1.ShowDialog();

			// Process input if the user clicked OK.
			if (userClickedOK == DialogResult.OK)
			{
				m_aFiles.Clear();
				// Read the files
				foreach (String file in openFileDialog1.FileNames)
				{
					m_aFiles.Add(file);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Thread th = new Thread(FillFilesArray);
			th.SetApartmentState(ApartmentState.STA);
			th.Start();
		}

		public struct stData
		{
			public string sFolder;
			public string sDoc;
			public bool bLast;
		}

		public void BrowseForFolder()
		{
			FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
			// Show the FolderBrowserDialog.
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				foreach (string doc in m_aFiles)
				{
					Thread th = new Thread(ExtractDocToTiff);
					th.SetApartmentState(ApartmentState.MTA);
					th.IsBackground = true;
					stData data = new stData();
					data.sFolder = folderBrowserDialog1.SelectedPath;
					data.sDoc = doc;
					data.bLast = doc.Equals(m_aFiles[m_aFiles.Count - 1]);
					th.Start(data);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Thread th = new Thread(BrowseForFolder);
			th.SetApartmentState(ApartmentState.STA);
			th.Start();
		}

		public void ExtractDocToTiff(object obj)
		{
			try
			{
				stData data = (stData)obj;
				PDFXEdit.IPXC_Document Doc = m_pxcInst.OpenDocumentFromFile(data.sDoc, null);
				PDFXEdit.IOperation Op = m_Inst.CreateOp(m_nID);
				PDFXEdit.ICabNode input = Op.Params.Root["Input"];
				input.Add().v = Doc;
				PDFXEdit.ICabNode options = Op.Params.Root["Options"];
				options["PagesRange.Type"].v = "All";
				options["DestFolder"].v = data.sFolder; //Output folder
				options["ExportMode"].v = "AllToMutliPage";
				options["Zoom"].v = 150;
				options["ShowResultFolder"].v = data.bLast; //We'll show the result folder only when we'll work with last doc
				//Saving as tiff
				PDFXEdit.ICabNode fmtParams = options["FormatParams"];
				//Compression type
				fmtParams["COMP"].v = 5; //LZW compression
				//X DPI
				fmtParams["DPIX"].v = 150;
				//Y DPI
				fmtParams["DPIY"].v = 150;
				//Image format
				fmtParams["FMT"].v = 1414088262; //TIFF
				//Image type
				fmtParams["ITYP"].v = 16; //24 TrueColor
				//Use Predictor
				fmtParams["PRED"].v = 1; //Yes
				//Thumbnail
				fmtParams["ITYP"].v = 0; //No
				Op.Do();
				Doc.Close();
				m_nSavedFilesCount++;
				if (m_nSavedFilesCount == m_aFiles.Count)
					MessageBox.Show("Export completed");
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_Inst.Shutdown();
		}
	}
}