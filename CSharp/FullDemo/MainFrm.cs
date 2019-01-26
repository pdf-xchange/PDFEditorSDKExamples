using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace FullDemo
{
	public enum IDS
	{
		// cmdbars
		cmdbar_menubar,
		cmdbar_standard,
		cmdbar_file,
		cmdbar_view,
		cmdbar_pageZoom,
		cmdbar_pageNav,
		cmdbar_contentEditing,
		cmdbar_pageLayout,
		cmdbar_docOptions,
		cmdbar_commenting,
		cmdbar_measurement,
		cmdbar_properties,
		cmdbar_launchApp,
		cmdbar_addon,
		cmdbar_form,

		// panes/views
		pageThumbnailsView,
		bookmarksView,
		contentsView,
		attachmentsView,
		signaturesView,
		commentsView,
		layersView,
		pdfNamedDestsView,
		propertiesView,
		searchView,
		stampsView,
		commentStylesView,
		panzoomView,

		_op_begin_,

		// print
		op_document_printPages,

		// new doc
		op_newBlankDoc,
		op_imagesToDoc,
		op_textToDoc,
		op_combineDocs,

		// pages
		op_document_insertPages,
		op_document_insertEmptyPages,
		op_document_deletePages,
		op_document_extractPages,
		op_document_replacePages,
		op_document_cropPages,
		op_document_resizePages,
		op_document_addWatermarks,

		// export comments & fields
		op_document_summarizeAnnots,
		op_document_exportCommentsAndFields,

		// import comments & fields
		op_document_importCommentsAndFields,

		// export
		op_document_exportToImages,

		_op_end_,

		_e_begin_,

		// events
		e_activeDocChanged,
		e_document_modStateChanged,
		e_document_sourceChanged,
		e_pagesView_endLayoutChanging,
		e_uiLanguageChanged,

		_e_end_,

		_last_,
	};

	public partial class MainFrm : Form
	{
		public int[] nIDS;
		private int fUpdateControls = 0;
		private bool fNeedLoadAllCommands = true;
		private bool fNeedLoadUILangs = true;
		private bool fNeedLoadAllOpers = true;
		private Font FontDefault = null;
		private Font FontMenu = null;

		public PDFXEdit.IPXS_Inst pxsInst = null;
		public PDFXEdit.IPXC_Inst pxcInst = null;
		public PDFXEdit.IUIX_Inst uiInst = null;
		public PDFXEdit.IAFS_Inst fsInst = null;
		public PDFXEdit.IAUX_Inst auxInst = null;
		private bool fCustomInitSDK = false;

		public partial class UIEventDemoMon : PDFXEdit.IUIX_EventMonitor
		{
			public void OnEventMonitor(PDFXEdit.IUIX_Obj pTarget, PDFXEdit.IUIX_Event pEvent)
			{
			// Debug.WriteLine("OnEventMonitor(code={0})", pEvent.Code);
			// pEvent.Code; - code of standard system’s message like: WM_CHAR, WM_KEYDOWN, WM_KEYUP, ... WM_MOUSEMOVE
			// and parameters of standard system’s message
			// pEvent.Param1; == wParam
			// pEvent.Param2; == lParam
			//	bool bEndModal = false;
			//	if ((pEvent.Code == (int)PDFXEdit.UIX_EventCodes.e_BeginModal) || (bEndModal = (pEvent.Code == (int)PDFXEdit.UIX_EventCodes.e_EndModal)))
			//	{
			//		if (pTarget.get_ID() == pTarget.ThreadCtx.Inst.Str2ID("DlgScanProfile"))
			//		{
			//			if (bEndModal)
			//			{
			//				bool bScanBtnClicked = ((int)pEvent.Param1 == pTarget.ThreadCtx.Inst.Str2ID("btn.scan"));
			//			}
			//		}
			//	}
			}
		}

		public UIEventDemoMon uiEventMon = null;

		public static string FixupWord(string w)
		{
			if (w == "Doc")
				return "Document";
			else if (w == "Docs")
				return "Documents";
			else if (w == "Annot")
				return "Annotation";
			else if (w == "Annots")
				return "Annotations";
			return w;
		}

		public static string clr2str(Color c)
		{
			return "rgbd(" + c.R + "," + c.G + "," + c.B + ")";
		}

		public static Color rgb2clr(int c)
		{
			int r = c & 0x000000FF;
			int g = (c & 0x0000FF00) >> 8;
			int b = (c & 0x00FF0000) >> 16;
			return Color.FromArgb(r, g, b);
		}

		public static string SID2DispName(string id)
		{
			int last = id.LastIndexOf(".");
			if (last < 0)
				last = id.LastIndexOf("_");
			string t;
			if (last >= 0)
				t = id.Substring(last + 1);
			else
				t = id;
			if (t.Length == 0)
				return id;
			t = Char.ToUpper(t[0]) + t.Substring(1); // first char uppercase
			string res = "";
			int k = 0;
			int i = 1; // skip first char
			for (; i < t.Length; i++)
			{
				if ((t[i] - Char.ToUpper(t[i])) == 0) // big letter == new word
				{
					string w = FixupWord(t.Substring(k, i - k));
					res += w;
					k = i;
					res += ' ';
				}
			}
			if (k < i)
				res += FixupWord(t.Substring(k));
			return res;
		}

		public class ComboboxItem
		{
			public ComboboxItem(string t, int v)
			{
				Text = t;
				Value = v;
			}
			public string Text { get; set; }
			public int Value { get; set; }
			public override string ToString()
			{
				return Text;
			}
		};

		public class ComboboxItem2
		{
			public ComboboxItem2(string t, string v)
			{
				Text = t;
				Value = v;
			}
			public string Text { get; set; }
			public string Value { get; set; }
			public override string ToString()
			{
				return Text;
			}
		};

		public bool IsErrCode(int nCode)
		{
			return (nCode < 0);
		}

		public void ShowErrMsg(int nErr)
		{
			if (!IsErrCode(nErr) || (auxInst == null) || auxInst.IsUserBreak(nErr))
				return;

			string err = auxInst.FormatHRESULT(nErr);
			if (err.Length == 0)
				return;

			int flags = (int)(	PDFXEdit.UIX_MsgBoxStyleFlags.UIX_MsgBox_IconError |
								PDFXEdit.UIX_MsgBoxStyleFlags.UIX_MsgBox_Close |
								PDFXEdit.UIX_MsgBoxStyleFlags.UIX_MsgBox_AppModal);

			pdfCtl.Inst.ShowMsgBox(err, "", "", (uint)Handle, flags);
		}

		private void SetCustColor(PDFXEdit.ICabNode clrArr, string clrID, string clrVal)
		{
			int cnt = clrArr.Count;
			PDFXEdit.ICabNode clr = null;
			for (int i = 0; i < cnt; i++)
			{
				PDFXEdit.ICabNode it = clrArr[i];
				string id = it["ID"].String;
				if (clrID == id)
				{
					clr = it;
					break;
				}
			}
			if (clr == null)
			{
				clr = clrArr.Add();
				if (clr == null)
					return;
			}
			clr["ID"].v = clrID;
			clr["Value"].v = clrVal;
		}

		private void SetCustFont(PDFXEdit.ICabNode fntArr, string fntID, string fntName, double fntSize)
		{
			int cnt = fntArr.Count;
			PDFXEdit.ICabNode fnt = null;
			for (int i = 0; i < cnt; i++)
			{
				PDFXEdit.ICabNode it = fntArr[i];
				string id = it["ID"].String;
				if (fntID == id)
				{
					fnt = it;
					break;
				}
			}
			if (fnt == null)
			{
				fnt = fntArr.Add();
				if (fnt == null)
					return;
			}
			fnt["ID"].v = fntID;
			if (fntName != "")
				fnt["Name"].v = fntName;
			if (fntSize > 0.0)
				fnt["Size"].v = fntSize;
		}

		public static string GetOptStr(string valName, string keyName = "", string defVal = "")
		{
			string path = "Software\\Tracker Software\\PDFEditorSDKExamples";
			if (keyName != "")
			{
				path += "\\";
				path += keyName;
			}
			string res = "";
			try
			{
				RegistryKey rk = Registry.CurrentUser.OpenSubKey(path);
				RegistryValueKind vk = rk.GetValueKind(valName);
				if (vk == RegistryValueKind.String)
				{
					res = (string)rk.GetValue(valName, defVal);
				}
				else if (vk == RegistryValueKind.MultiString || vk == RegistryValueKind.MultiString)
				{
					string[] str_arr = (string[])rk.GetValue(valName, defVal); // type is REG_MULTI_SZ
					foreach (string s in str_arr)
					{
						if (res.Length != 0)
							res += "\r\n";
						res += s;
					}
				}
			}
			catch
			{
				res = "";
			}

			if (res.Length == 0)
				res = defVal;

			return res;
		}

		public static int GetOptInt(string valName, string keyName = "", int defVal = 0)
		{
			string path = "Software\\Tracker Software\\PDFEditorSDKExamples";
			if (keyName != "")
			{
				path += "\\";
				path += keyName;
			}
			int res = defVal;
			try
			{
				RegistryKey rk = Registry.CurrentUser.OpenSubKey(path);
				res = (int)rk.GetValue(valName, defVal);
			}
			catch { }
			return res;
		}

		public static void SetOptStr(string valName, string val, string keyName = "")
		{
			string path = "Software\\Tracker Software\\PDFEditorSDKExamples";
			if (keyName != "")
			{
				path += "\\";
				path += keyName;
			}
			try
			{
				RegistryKey rk = Registry.CurrentUser.CreateSubKey(path);
				rk.SetValue(valName, val);
			}
			catch { }
		}

		public static void SetOptInt(string valName, int val, string keyName = "")
		{
			string path = "Software\\Tracker Software\\PDFEditorSDKExamples";
			if (keyName != "")
			{
				path += "\\";
				path += keyName;
			}
			try
			{
				RegistryKey rk = Registry.CurrentUser.CreateSubKey(path);
				rk.SetValue(valName, val);
			}
			catch { }
		}

		public static void SetOptBool(string valName, bool val, string keyName = "")
		{
			string path = "Software\\Tracker Software\\PDFEditorSDKExamples";
			if (keyName != "")
			{
				path += "\\";
				path += keyName;
			}
			try
			{
				RegistryKey rk = Registry.CurrentUser.CreateSubKey(path);
				int v = val ? 1 : 0;
				rk.SetValue(valName, v);
			}
			catch { }
		}

		private void BuildHistFilesNames(string histDir, out string histFile, out string histThumbsFile)
		{
			histFile = "";
			histThumbsFile = "";
			if (histDir.Length == 0)
				return;
			histFile = histDir;
			if (histFile[histFile.Length - 1] != '\\')
				histFile += '\\';
			histThumbsFile = histFile;
			histFile += "History.dat";
			histThumbsFile += "HistoryThumbs.dat";
		}

		public bool HasIntersect(ref PDFXEdit.PXC_Rect r1, ref PDFXEdit.PXC_Rect r2)
		{
			if ((r1.left >= r2.right) || (r1.right <= r2.left))
				return false;
			if ((r1.top <= r2.bottom) || (r1.bottom >= r2.top))
				return false;
			return true;
		}

		public MainFrm()
		{
			//////////////////////////////////////////////////////////////////////////////////
			// Setup SDK-license key
			//////////////////////////////////////////////////////////////////////////////////

			string licKeyDEMO =
"dEmOk4WZ3uxwI/9oEZODemogFi61n61nNVt6UTzu16hUPvDEmots7yE5IUcd4Z+NvMgQzdQ1" +
"7lAG3IrDeMogTpzOfxzKsRfNQRD9UqkyyZx6sYwPrDtnWzndqSV/zSl+0QpJ5b8QtdemOBsq" +
"8511v3l+sgec6JExR944vi35DEMOGC1GOsXDd9LzSU/Eg9TY/Y3yctxyh5UA9ljIWviQ9W4T" +
"OzDmaiyv5giyCPYwO2HyZdemoa3fi8zpvOy2EeYgWvfPSGjRqxlCT1a0wBxpNe4QB5R6tr+X" +
"qR9JPV/p8DJ4vRqDDsDEMOX4xm/iXP3fdz/1KQs/elwMqwtUUrJYjzvDu7AwBpWEQ9so04ZO" +
"baGYL3C6N/oaKioFL+0d7cyEA+2+/CdEMoelQKDEVqvEUxatrMJsD6yald01Cd1DA1eq7Tt1" +
"b3vn58E2dEMobiBmg4qkdOpLtjcYxh69t3BVtKxmu6uyXZd+gO0NZxHkQT+6/U1334DEMO+H" +
"oou1/TmICS9GS6p+nfTQLZpButSOkGfaT7V17n6NkTvSKwLtrwDEMO==";

			string licKey = licKeyDEMO; // use here your private license key that was bought on tracker's official site...

			////////////////////////////////////////////////////////////////////
			// >>>>>
			// The code below is used only to simplify our development and testing
			// of this Example for different modes: Licensed and DEMO.
			// NOTE: it is not recommended to place and keep your private license
			// key in public system's registry because it might be stolen by other people.
			{
				string pubLicKey = GetOptStr("LicKey");
				if (pubLicKey.Length != 0)
					licKey = pubLicKey;
			}
			// <<<<<
			////////////////////////////////////////////////////////////////////

			////////////////////////////////////////////////////////////////////
			// >>>> Customization of SDK initialization process (OPTIONAL)
			bool fLoadPrefs = GetOptInt("KeepPrefs") != 0;
			bool fUseRegPrefs = GetOptInt("UsePrefsReg", "", 1) != 0;
			string prefsRegPath = GetOptStr("PrefsRegPath", "", "HKCU\\Software\\MyApp\\PDFXEdit");
			string prefsFilePath = GetOptStr("PrefsFilePath", "", "C:\\MyApp\\PDFXEdit\\Settings.dat");

			bool fLoadHist = GetOptInt("KeepHist") != 0;
			string histDir = GetOptStr("HistDir", "", "C:\\MyApp\\PDFXEdit");

			if (fLoadPrefs || fLoadHist)
			{
				string prefsPath = "";
				string histFile = "";
				string histThumbsFile = "";
				if (fLoadPrefs)
					prefsPath = fUseRegPrefs ? prefsRegPath : prefsFilePath;
				if (fLoadHist)
					BuildHistFilesNames(histDir, out histFile, out histThumbsFile);

				if (prefsPath.Length != 0 || histFile.Length != 0)
				{
					// firstly you must get access to main object of SDK, BEFORE of instantiation of first PXV_Control object (i.e. before call of InitializeComponent())
					PDFXEdit.PXV_Inst Inst = new PDFXEdit.PXV_Inst();

					// now you may customize initialization of SDK
					PDFXEdit.IString prefsPathStr = null;
					PDFXEdit.IString histFileStr = null;
					PDFXEdit.IString histThumbsFileStr = null;
					if (prefsPath.Length != 0)
						prefsPathStr = Inst.CreateString(prefsPath);
					if (histFile.Length != 0)
					{
						histFileStr = Inst.CreateString(histFile);
						histThumbsFileStr = Inst.CreateString(histThumbsFile);
					}

					Inst.Init(null, licKey, prefsPathStr, histFileStr, histThumbsFileStr);
					Inst = null;

					fCustomInitSDK = true;
				}
			}
			// <<<<<
			////////////////////////////////////////////////////////////////////

			InitializeComponent();

			InitIDS();

			if (!fCustomInitSDK)
				pdfCtl.SetLicKey(licKey);

			cbPagesLayout.Items.Add(new ComboboxItem("Single Page", (int)PDFXEdit.PXC_PagesLayout.PageLayout_SinglePage));
			cbPagesLayout.Items.Add(new ComboboxItem("One Column", (int)PDFXEdit.PXC_PagesLayout.PageLayout_OneColumn));
			cbPagesLayout.Items.Add(new ComboboxItem("Two-Columns Left", (int)PDFXEdit.PXC_PagesLayout.PageLayout_TwoColumns_Left));
			cbPagesLayout.Items.Add(new ComboboxItem("Two-Columns Right", (int)PDFXEdit.PXC_PagesLayout.PageLayout_TwoColumns_Right));
			cbPagesLayout.Items.Add(new ComboboxItem("Two-Pages Left", (int)PDFXEdit.PXC_PagesLayout.PageLayout_TwoPages_Left));
			cbPagesLayout.Items.Add(new ComboboxItem("Two-Pages Right", (int)PDFXEdit.PXC_PagesLayout.PageLayout_TwoPages_Right));

			cbPagesZoom.Items.Add(new ComboboxItem("75%", 0));
			cbPagesZoom.Items.Add(new ComboboxItem("100%", (int)PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_Actual));
			cbPagesZoom.Items.Add(new ComboboxItem("200%", 0));
			cbPagesZoom.Items.Add(new ComboboxItem("300%", 0));
			cbPagesZoom.Items.Add(new ComboboxItem("500%", 0));
			cbPagesZoom.Items.Add(new ComboboxItem("800%", 0));
			cbPagesZoom.Items.Add(new ComboboxItem("Fit Height", (int)PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_FitHeight));
			cbPagesZoom.Items.Add(new ComboboxItem("Fit Width", (int)PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_FitWidth));
			cbPagesZoom.Items.Add(new ComboboxItem("Fit Page", (int)PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_FitPage));
			cbPagesZoom.Items.Add(new ComboboxItem("Fit Visible", (int)PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_FitVisible));

			uiInst = (PDFXEdit.IUIX_Inst)pdfCtl.Inst.GetExtension("UIX");
			fsInst = (PDFXEdit.IAFS_Inst)pdfCtl.Inst.GetExtension("AFS");
			auxInst = (PDFXEdit.IAUX_Inst)pdfCtl.Inst.GetExtension("AUX");
			pxsInst = (PDFXEdit.IPXS_Inst)pdfCtl.Inst.GetExtension("PXS");
			pxcInst = (PDFXEdit.IPXC_Inst)pdfCtl.Inst.GetExtension("PXC");

			// load 'Program Preferences' opts
			ckKeepPrefs.Checked = fLoadPrefs;

			if (fUseRegPrefs)
				rbPrefs_reg.Checked = true;
			else
				rbPrefs_file.Checked = true;

			tPrefs_reg.Text = prefsRegPath;
			tPrefs_file.Text = prefsFilePath;

			// load 'Import/Export Settings' opts
			tSettFile.Text = GetOptStr("SettFilePath", "", "C:\\MyApp\\PDFXEditSettings.xcs");
			ckSettIncHist.Checked = GetOptInt("SettIncHist") != 0;

			ckKeepHist.Checked = fLoadHist;
			tHistDir.Text = histDir;

			pdfCtl.Inst.Settings["General.AppTitle"].v = "My App";

			UpdateSettingsIoTab();

//			// install UI-events demo-monitor
//  		uiEventMon = new UIEventDemoMon();
//  		uiInst.CurrentThreadCtx.RegisterEventMonitor(uiEventMon);

			UpdateDocTab();

			RegisterEvents(true);
		}


		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			RegisterEvents(false);

			// unregister UI-events demo-monitor
			if (uiEventMon != null)
			{
				uiInst.CurrentThreadCtx.UnregisterEventMonitor(uiEventMon);
				uiEventMon = null;
			}

			uiInst = null;
			fsInst = null;
			auxInst = null;
			pxsInst = null;
			pxcInst = null;

			/////////////////////////////////////////////////////////
			// >>>> Save all user preferences / save history of documents opening
			/////////////////////////////////////////////////////////

			bool fKeepPrefs = ckKeepPrefs.Checked;
			bool fUseRegPrefs = rbPrefs_reg.Checked;
			string prefsRegPath = tPrefs_reg.Text;
			string prefsFilePath = tPrefs_file.Text;

			bool fKeepHist = ckKeepHist.Checked;
			string histDir = tHistDir.Text;

			// user prefs
			SetOptBool("KeepPrefs", fKeepPrefs);
			SetOptBool("UsePrefsReg", fUseRegPrefs);
			SetOptStr("PrefsRegPath", prefsRegPath);
			SetOptStr("PrefsFilePath", prefsFilePath);

			// history
			SetOptBool("KeepHist", fKeepHist);
			SetOptStr("HistDir", histDir);

			// import/export settings
			SetOptStr("SettFilePath", tSettFile.Text);
			SetOptBool("SettIncHist", ckSettIncHist.Checked);

			if (fKeepPrefs)
			{
				string path = fUseRegPrefs ? prefsRegPath : prefsFilePath;
				if (path.Length != 0)
				{
					try
					{
						pdfCtl.Inst.SaveUserSettings(pdfCtl.Inst.CreateString(path));
					}
					catch { }
				}
			}

			if (fKeepHist && (histDir.Length != 0))
			{
				string histFile = "";
				string histThumbsFile = "";
				BuildHistFilesNames(histDir, out histFile, out histThumbsFile);
				try
				{
					pdfCtl.Inst.SaveHistory(pdfCtl.Inst.CreateString(histFile), pdfCtl.Inst.CreateString(histThumbsFile));
				}
				catch { }
			}
			// <<<<
			/////////////////////////////////////////////////////////

			if (fCustomInitSDK)
			{
				// It is critical to call Inst.Shutdown() directly because we already called Inst.Init() in MainFrm() constructor
				pdfCtl.Inst.Shutdown();
			}

			/////////////////////////////////////////////////////////////////////////////////////
			// Forced release of all COM-objects that may still captured by Garbage Collector. //
			// It is critical to release them before destroying of pdfCtl!                     //
			/////////////////////////////////////////////////////////////////////////////////////

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		private void UpdateZoomCombo(double zl, PDFXEdit.PXV_ZoomMode zm)
		{
			fUpdateControls++;

			if (zm != PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_Percent)
			{
				foreach (ComboboxItem i in cbPagesZoom.Items)
				{
					if (i.Value == (int)zm)
					{
						cbPagesZoom.SelectedItem = i;
						fUpdateControls--;
						return;
					}
				}
			}

			if (zm == PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_Percent)
			{
				string s = FormatNum(zl) + "%";
				cbPagesZoom.SelectedIndex = (int)cbPagesZoom.FindString(s);
				cbPagesZoom.Text = s;
			}

			fUpdateControls--;
		}


		public static string GetPDFStandard(PDFXEdit.PXC_PDFStandard pds)
		{
			string res = "";
			switch (pds)
			{
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_Unknown:
					res = "PDF/A";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_1a:
					res = "PDF/A-1a";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_1b:
					res = "PDF/A-1b";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_2a:
					res = "PDF/A-2a";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_2b:
					res = "PDF/A-2b";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_2u:
					res = "PDF/A-2u";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_3a:
					res = "PDF/A-3a";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_3b:
					res = "PDF/A-3b";
					break;
				case PDFXEdit.PXC_PDFStandard.PDFS_PDFA_3u:
					res = "PDF/A-3u";
					break;
			}
			return res;
		}

		public static string GetPDFFormType(PDFXEdit.PXC_PDFFormType pdft)
		{
			string res = "None";
			switch (pdft)
			{
				case PDFXEdit.PXC_PDFFormType.PDFForm_AcroForm:
					res = "Acro-Form";
					break;
				case PDFXEdit.PXC_PDFFormType.PDFForm_StaticXFA:
					res = "Static XFA";
					break;
				case PDFXEdit.PXC_PDFFormType.PDFForm_DynamicXFA:
					res = "Dynamic XFA";
					break;
			}
			return res;
		}

		public static string FormatNum(double num)
		{
			string s = String.Format("{0:0.00}", num);
			s = s.TrimEnd('0');
			s = s.TrimEnd('.');
			return s;
		}

		public static double Str2Num(string s, out bool ok, double defval = 0.0)
		{
			ok = false;
			char[] charsToTrim = { ' ', '%', '.', ',' };
			s = s.Trim(charsToTrim);
			if (s == "")
				return defval;
			ok = true;
			double v = 0.0;
			try
			{
				v = Convert.ToDouble(s);
			}
			catch (FormatException)
			{
				ok = false;
				v = defval;
			}
			return v;
		}


		private void InitIDS()
		{
			nIDS = new int[(int)IDS._last_];
			for (IDS i = 0; i < IDS._last_; i++)
			{
				string sid = Enum.GetName(typeof(IDS), i);
				if (sid[0] == '_') // skip all like '_op_first_', '_op_last_', '_e_first_', etc..
				{
					nIDS[(int)i] = 0;
					continue;
				}
				sid = sid.Replace('_', '.');
				nIDS[(int)i] = pdfCtl.Inst.Str2ID(sid);
			}
		}

		private void RegisterEvents(bool bRegister)
		{
			for (IDS i = IDS._e_begin_ + 1; i < IDS._e_end_; i++)
				pdfCtl.EnableEventListening2(nIDS[(int)i], bRegister);
		}

		private void UpdateCommandsTab()
		{
			fUpdateControls++;

			ckAllowShortcuts.Checked = pdfCtl.AllowedShortcuts;

			if (fNeedLoadAllCommands)
			{
				fNeedLoadAllCommands = false;
				PDFXEdit.IUIX_CmdCollection cmds = uiInst.CmdManager.Cmds;
				uint cnt = cmds.Count;
				for (uint i = 0; i < cnt; i++)
				{
					PDFXEdit.IUIX_Cmd cmd = cmds[i];
					ListViewItem it = new ListViewItem(new[] { pdfCtl.Inst.ID2Str(cmd.ID), cmd.Title, (cmd.Offline ? "Yes" : "No"), (cmd.Hidden ? "Yes" : "No"), cmd.Alias, cmd.Tip });
					lvCmds.Items.Add(it);
				}

				lvCmds.Sort();
			}

			UpdateCmdButtons();

			fUpdateControls--;
		}

		private void UpdateUILangTab()
		{
			fUpdateControls++;

			if (fNeedLoadUILangs)
			{
				fNeedLoadUILangs = false;

				cbUILangs.Items.Add(new ComboboxItem2("Built-in (English US)", "-"));

				string langCode = pdfCtl.Inst.GetCurrentUILang();

				PDFXEdit.IPXV_UILanguages langs = pdfCtl.Inst.GetUILanguages();
				uint cnt = langs.Count;
				int selIdx = -1;
				for (uint i = 0; i < cnt; i++)
				{
					string code;
					string eName;
					string lName;
					langs.GetItem(i, out code, out eName, out lName);
					int idx = cbUILangs.Items.Add(new ComboboxItem2(eName, code));
					if ((selIdx < 0) && (langCode == code))
						selIdx = idx;
				}

				if (selIdx < 0)
					selIdx = 0;

				cbUILangs.SelectedIndex = selIdx;
			}

			UpdateCmdButtons();

			fUpdateControls--;
		}

		private void UpdatePagesView()
		{
			fUpdateControls++;

			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;

			bool bHasDoc = doc != null;

			uint cp = 0;
			PDFXEdit.PXC_PagesLayout lm = PDFXEdit.PXC_PagesLayout.PageLayout_SinglePage;
			double zl = 100;
			PDFXEdit.PXV_ZoomMode zm = PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_Percent;
			string sPageSize = "";
			string sPageRot = "";

			if (bHasDoc)
			{
				PDFXEdit.IPXV_PagesLayoutManager pl = doc.ActiveView.PagesView.Layout;
				cp = pl.CurrentPage;
				lm = pl.LayoutMode;
				zl = pl.ZoomLevel;
				zm = pl.ZoomMode;

				double pw, ph;
				PDFXEdit.IPXC_Page curPage = doc.CoreDoc.Pages[cp];
				curPage.GetDimension(out pw, out ph);

				sPageSize = "W=" + FormatNum(pw) + "pt, H=" + FormatNum(ph) + "pt";
				sPageRot = curPage.Rotation.ToString() + "°";
			}

			tCurPage.Text = (cp + 1).ToString();
			cbPagesLayout.SelectedIndex = (int)lm;
			lbPageSize.Text = sPageSize;
			lbPageRotation.Text = sPageRot;

			UpdateZoomCombo(zl, zm);

			if (bHasDoc)
				System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);

			fUpdateControls--;
		}

		public string OpId2DispName(IDS id)
		{
			string sid = pdfCtl.Inst.ID2Str(nIDS[(int)id]);
			return SID2DispName(sid);
		}

		public Form OpId2Form(IDS id)
		{
			switch (id)
			{
				case IDS.op_document_addWatermarks:
					return new AddWatermarkForm(this);
				case IDS.op_document_deletePages:
					return new DeletePages(this);
				case IDS.op_document_printPages:
					return new PrintForm(this);
				case IDS.op_document_insertPages:
					return new InsertPagesForm(this);
				case IDS.op_document_extractPages:
					return new ExtractPagesForm(this);
			}

			return null;
		}

		private void UpdateOpersTab()
		{
			fUpdateControls++;

			if (fNeedLoadAllOpers)
			{
				fNeedLoadAllOpers = false;

				{
					IDS id = IDS.op_document_printPages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc));
				}

				{
					IDS id = IDS.op_newBlankDoc;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Output_Doc));
				}

				{
					IDS id = IDS.op_imagesToDoc;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_AllSuppRasterImg | (uint)DemoFlags.Input_MultFiles | (uint)DemoFlags.Output_Doc));
				}

				{
					IDS id = IDS.op_textToDoc;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_TxtFile | (uint)DemoFlags.Input_MultFiles | (uint)DemoFlags.Output_Doc));
				}

				{
					IDS id = IDS.op_combineDocs;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_AllSupp | (uint)DemoFlags.Input_MultFiles | (uint)DemoFlags.Output_Doc));
				}

				{
					IDS id = IDS.op_document_insertPages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc));
				}

				{
					IDS id = IDS.op_document_insertEmptyPages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc));
				}

				{
					IDS id = IDS.op_document_deletePages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc));
				}

				{
					IDS id = IDS.op_document_extractPages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc | (uint)DemoFlags.Output_Doc));
				}

				{
					IDS id = IDS.op_document_replacePages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc | (uint)DemoFlags.RunOnlyWithStdDlg));
				}

				{
					IDS id = IDS.op_document_resizePages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc | (uint)DemoFlags.RunOnlyWithStdDlg));
				}

				{
					IDS id = IDS.op_document_addWatermarks;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc));
				}

				{
					IDS id = IDS.op_document_summarizeAnnots;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc | (uint)DemoFlags.Output_Doc));
				}

				{
					IDS id = IDS.op_document_exportCommentsAndFields;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc | (uint)DemoFlags.RunOnlyWithStdDlg));
				}

				{
					IDS id = IDS.op_document_importCommentsAndFields;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc | (uint)DemoFlags.RunOnlyWithStdDlg));
				}

				{
					IDS id = IDS.op_document_exportToImages;
					cbOpers.Items.Add(new OperationDemo(OpId2DispName(id), nIDS[(int)id], OpId2Form(id), (uint)DemoFlags.Input_Doc));
				}

				object sel = null;

				foreach (OperationDemo it in cbOpers.Items)
				{
					if (it.ID == nIDS[(int)IDS.op_document_printPages])
					{
						//sel = it; це обирає завжди прінт
						break;
					}
				}

				if (sel != null)
					cbOpers.SelectedItem = sel;
				else
					cbOpers.SelectedIndex = 0;
			}

			OnOperSelChanged();

			fUpdateControls--;
		}

		private void UpdateDocTab()
		{
			fUpdateControls++;

			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;

			lbSrc.Text = pdfCtl.Src; // == ((pdfCtl.Doc != null) ? pdfCtl.Doc.CoreDoc.SrcInfo.FileName : "")

			string sSpecVer = "";
			string sPDFStd = "";
			string sTitle = "";
			string sSubj = "";
			string sAuthor = "";
			string sKeyw = "";
			string sCreator = "";
			string sProducer = "";
			string sPDFForm = "";
			string sCreatDate = "";
			string sModDate = "";
			uint nPagesCnt = 0;
			bool bHasDoc = doc != null;

			if (bHasDoc)
			{
				try
				{
					uint id = doc.CoreDoc.ID;
					uint sv = doc.CoreDoc.Props.SpecVersion;
					uint sv_mj = sv / 65536;
					uint sv_mn = sv % 65536;
					sSpecVer = String.Format("{0}.{1}", sv_mj, sv_mn);
					sPDFStd = GetPDFStandard(doc.CoreDoc.Props.PDFStandard);
					sPDFForm = GetPDFFormType(doc.CoreDoc.AcroForm.Type);
					nPagesCnt = doc.CoreDoc.Pages.Count;
					sCreatDate = doc.CoreDoc.Info.CreationDate.ToShortDateString() + ". " + doc.CoreDoc.Info.CreationDate.ToShortTimeString();
					sModDate = doc.CoreDoc.Info.ModificationDate.ToShortDateString() + ". " + doc.CoreDoc.Info.ModificationDate.ToShortTimeString();

					sTitle		= doc.CoreDoc.Info[PDFXEdit.PXC_DocumentInfoKey.DocInfo_Title];
					sAuthor		= doc.CoreDoc.Info[PDFXEdit.PXC_DocumentInfoKey.DocInfo_Author];
					sProducer	= doc.CoreDoc.Info[PDFXEdit.PXC_DocumentInfoKey.DocInfo_Producer];
					sCreator	= doc.CoreDoc.Info[PDFXEdit.PXC_DocumentInfoKey.DocInfo_Creator];
					sSubj		= doc.CoreDoc.Info[PDFXEdit.PXC_DocumentInfoKey.DocInfo_Subject];
					sKeyw		= doc.CoreDoc.Info[PDFXEdit.PXC_DocumentInfoKey.DocInfo_Keywords];

					ckModified.Checked = doc.Modified;
				}
				catch {	}
			}

			ckModified.Checked = bHasDoc && doc.Modified;

			lbPDFSpecVer.Text = sSpecVer;
			lbPDFA.Text = sPDFStd;
			lbPDFForm.Text = sPDFForm;
			lbPagesCnt.Text = nPagesCnt.ToString();

			lbCreatDate.Text = sCreatDate;
			lbModDate.Text = sModDate;

			tTitle.Text = sTitle;
			tSubj.Text = sSubj;
			tAuthor.Text = sAuthor;
			tKeyw.Text = sKeyw;
			tProducer.Text = sProducer;
			tCreator.Text = sCreator;

			UpdatePagesView();

			btnCloseDoc.Enabled = bHasDoc;
			ckAllowAskForSave.Enabled = bHasDoc;
			ckModified.Enabled = bHasDoc;

			cbPagesLayout.Enabled = bHasDoc;
			cbPagesZoom.Enabled = bHasDoc;
			tCurPage.Enabled = bHasDoc;

			btnShowSaveAsDlg.Enabled = bHasDoc;
			btnSimpleSave.Enabled = bHasDoc;
			tDestToSave.Enabled = bHasDoc;
			btnBrowseForSaveAs.Enabled = bHasDoc;
			btnSaveToCustDest.Enabled = bHasDoc;
			ckIStreamDestDemo.Enabled = bHasDoc;
			ckSwitchToDest.Enabled = bHasDoc;
			btnZoomIn.Enabled = bHasDoc;
			btnZoomOut.Enabled = bHasDoc;

			UpdateDocumentsOpts();

			fUpdateControls--;
		}

		private void UpdateDocumentsOpts()
		{
			ckMultDocs.Checked = !(bool)pdfCtl.Inst.Settings["Docs.SingleWnd"].v;
			ckHideSingleTab.Checked = (bool)pdfCtl.Inst.Settings["Docs.HideSingleTab"].v;
		}

		private void UpdateCmdBarsTree()
		{
			CmdBarTree Tree = new CmdBarTree(pdfCtl.Inst, ref cmdBarsTree);
			this.cmdBarsTree.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.cmdBarsTree_AfterCheck);
			Tree.Load();
			cmdBarsTree.ExpandAll();
			this.cmdBarsTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.cmdBarsTree_AfterCheck);
		}

		private void UpdateViewTab(bool bUpdateTree = true)
		{
			fUpdateControls++;

			ckShowCmdPanes.Checked = pdfCtl.VisibleCmdPanes != 0;
			ckLockCmdPanes.Checked = pdfCtl.LockedCmdPanes;
			ckUnlockCmdBars.Checked = !pdfCtl.LockedCmdBars;
			ckHideSb.Checked = !pdfCtl.VisibleScrollbars;
			if (bUpdateTree)
				UpdateCmdBarsTree();

			ckRibbonUI.CheckState = pdfCtl.Frame.View.IsRibbonMode ? CheckState.Checked : CheckState.Unchecked;

			// main bars
			ckShowMenu.Checked = IsCmdBarVisible(IDS.cmdbar_menubar);
			ckShowFileBar.Checked = IsCmdBarVisible(IDS.cmdbar_file);
			ckShowStdBar.Checked = IsCmdBarVisible(IDS.cmdbar_standard);
			ckShowPropBar.Checked = IsCmdBarVisible(IDS.cmdbar_properties);
			ckShowCommentBar.Checked = IsCmdBarVisible(IDS.cmdbar_commenting);
			ckShowMeasureBar.Checked = IsCmdBarVisible(IDS.cmdbar_measurement);
			ckShowContentEdtBar.Checked = IsCmdBarVisible(IDS.cmdbar_contentEditing);
			ckShowRotateViewBar.Checked = IsCmdBarVisible(IDS.cmdbar_view);
			ckShowFormViewBar.Checked = IsCmdBarVisible(IDS.cmdbar_form);

			bool bHasDoc = pdfCtl.HasDoc;
			bool bClassic = !pdfCtl.Frame.View.IsRibbonMode;

			// document's bars
			ckShowPagesLayoutBar.Checked = IsCmdBarVisible(IDS.cmdbar_pageLayout);
			ckShowPagesNavBar.Checked = IsCmdBarVisible(IDS.cmdbar_pageNav);
			ckShowPageZoomBar.Checked = IsCmdBarVisible(IDS.cmdbar_pageZoom);
			ckShowDocLaunchBar.Checked = IsCmdBarVisible(IDS.cmdbar_launchApp);
			ckShowDocOptsBar.Checked = IsCmdBarVisible(IDS.cmdbar_docOptions);

			ckShowPagesLayoutBar.Enabled = bHasDoc | bClassic;
			ckShowPagesNavBar.Enabled = bHasDoc | bClassic;
			ckShowPageZoomBar.Enabled = bHasDoc | bClassic;
			ckShowDocLaunchBar.Enabled = bHasDoc | bClassic;
			ckShowDocOptsBar.Enabled = bHasDoc | bClassic;

			ckShowMenu.Enabled = bClassic;
			ckShowFileBar.Enabled = bClassic;
			ckShowStdBar.Enabled = bClassic;
			ckShowPropBar.Enabled = bClassic;
			ckShowCommentBar.Enabled = bClassic;
			ckShowMeasureBar.Enabled = bClassic;
			ckShowContentEdtBar.Enabled = bClassic;
			ckShowRotateViewBar.Enabled = bClassic;
			ckShowFormViewBar.Enabled = bClassic;

			// main panes
			ckShowPanZoom.Checked = IsPaneVisible(IDS.panzoomView);
			ckShowStampsPalette.Checked = IsPaneVisible(IDS.stampsView);
			ckShowCommentStyles.Checked = IsPaneVisible(IDS.commentStylesView);
			ckShowSearchPane.Checked = IsPaneVisible(IDS.searchView);

			// document's panes
			ckShowAttachments.Checked = IsPaneVisible(IDS.attachmentsView);
			ckShowSignatures.Checked = IsPaneVisible(IDS.signaturesView);
			ckShowLayers.Checked = IsPaneVisible(IDS.layersView);
			ckShowComments.Checked = IsPaneVisible(IDS.commentsView);
			ckShowBookm.Checked = IsPaneVisible(IDS.bookmarksView);
			ckShowThumbs.Checked = IsPaneVisible(IDS.pageThumbnailsView);

			ckShowAttachments.Enabled = bHasDoc;
			ckShowSignatures.Enabled = bHasDoc;
			ckShowLayers.Enabled = bHasDoc;
			ckShowComments.Enabled = bHasDoc;
			ckShowBookm.Enabled = bHasDoc;
			ckShowThumbs.Enabled = bHasDoc;

			ckSyncDocPanesLayout.Checked = (bool)pdfCtl.Inst.Settings["Docs.AutoSyncDocPanesLayouts"].v;

			fUpdateControls--;
		}

		private void ShowCmdBar(IDS barID, bool bShow)
		{
			pdfCtl.Inst.ShowCmdBar2(nIDS[(int)barID], bShow);
		}

		private bool IsCmdBarVisible(IDS barID)
		{
			return pdfCtl.Inst.IsCmdBarVisible2(nIDS[(int)barID]);
		}

		private void ShowPane(IDS paneID, bool bShow)
		{
			pdfCtl.ShowPane2(nIDS[(int)paneID], bShow);
		}

		private bool IsPaneVisible(IDS paneID)
		{
			int nVis = pdfCtl.GetPaneVisibility2(nIDS[(int)paneID]);
			return (nVis > 0);
		}

		private void ckShowCmdPanes_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			pdfCtl.VisibleCmdPanes = ckShowCmdPanes.Checked ? (uint)PDFXEdit.PXV_VisibleCmdPanes.PXV_VisibleCmdPanes_All : 0;

			UpdateViewTab();
		}

		private void ckUnlockCmdBars_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			pdfCtl.LockedCmdBars = !ckUnlockCmdBars.Checked;
		}

		private void ckLockCmdPanes_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			pdfCtl.LockedCmdPanes = ckLockCmdPanes.Checked;
		}

		private void ckHideSb_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			pdfCtl.VisibleScrollbars = !ckHideSb.Checked;
		}

		private void ckShowMenu_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_menubar, (ckShowMenu.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowFileBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_file, (ckShowFileBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowStdBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_standard, (ckShowStdBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowPropBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_properties, (ckShowPropBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowZoomBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_pageZoom, (ckShowPageZoomBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowCommentBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_commenting, (ckShowCommentBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowContentEdtBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_contentEditing, (ckShowContentEdtBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowMeasureBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_measurement, (ckShowMeasureBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowPagesNavBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_pageNav, (ckShowPagesNavBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowPagesLayoutBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_pageLayout, (ckShowPagesLayoutBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowDocLaunchBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_launchApp, (ckShowDocLaunchBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowDocOptsBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_docOptions, (ckShowDocOptsBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowRotateViewBar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_view, (ckShowRotateViewBar.Checked));
			UpdateCmdBarsTree();
		}

		private void cbShowFormViewbar_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowCmdBar(IDS.cmdbar_form, (ckShowFormViewBar.Checked));
			UpdateCmdBarsTree();
		}

		private void ckShowCommentStyles_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.commentStylesView, (ckShowCommentStyles.Checked));
		}

		private void ckSyncDocPanesLayout_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			pdfCtl.Inst.Settings["Docs.AutoSyncDocPanesLayouts"].v = ckSyncDocPanesLayout.Checked;
			pdfCtl.Inst.FireAppPrefsChanged(PDFXEdit.PXV_AppPrefsChanges.PXV_AppPrefsChange_Documents);
		}

		private void ckShowComments_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.commentsView, (ckShowComments.Checked));
		}

		private void ckShowBookm_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.bookmarksView, (ckShowBookm.Checked));
		}

		private void ckShowLayers_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.layersView, (ckShowLayers.Checked));
		}

		private void ckShowSignatures_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.signaturesView, (ckShowSignatures.Checked));
		}

		private void ckShowAttachments_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.attachmentsView, (ckShowAttachments.Checked));
		}

		private void ckShowThumbs_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.pageThumbnailsView, (ckShowThumbs.Checked));
		}

		private void ckShowSearchPane_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.searchView, (ckShowSearchPane.Checked));
		}

		private void ckShowStampsPalette_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.stampsView, (ckShowStampsPalette.Checked));
		}

		private void ckShowPanZoom_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			ShowPane(IDS.panzoomView, (ckShowPanZoom.Checked));
		}

		private void pdfCtl_OnEvent(object sender, AxPDFXEdit._IPXV_ControlEvents_OnEventEvent e)
		{
			Debug.WriteLine("pdfCtl.OnEvent: e.nEventID=={0}", e.nEventID);

// 			PDFXEdit.IPXV_AnnotsEvent annotsEvent = (PDFXEdit.IPXV_AnnotsEvent)e.pEvent;
// 			if (annotsEvent != null)
// 			{
// 				uint squareAnnotType = pxsInst.StrToAtom("Square");
// 				// Other types:
// 				//	Link,
// 				//	Popup,
// 				//	Movie,
// 				//	Widget,
// 				//	Screen,
// 				//	PrinterMark,
// 				//	TrapNet,
// 				//	Watermark,
// 				//	3D,
// 				//	RichMedia,
// 				//	Text,
// 				//	FreeText,
// 				//	Line,
// 				//	Square,
// 				//	Circle,
// 				//	Polygon,
// 				//	PolyLine,
// 				//	Highlight,
// 				//	Underline,
// 				//	Squiggly,
// 				//	StrikeOut,
// 				//	Stamp,
// 				//	Caret,
// 				//	Ink,
// 				//	FileAttachment,
// 				//	Sound,
// 				//	Redact,
// 				//	Projection,
//
// 				uint annotsCnt = annotsEvent.Items.Count;
// 				for (uint i = 0; i < annotsCnt; i++)
// 				{
// 					PDFXEdit.IPXC_Annotation annot = annotsEvent.Items[i];
// 					if (squareAnnotType == annot.Type)
// 					{
// 						uint pageIndex = annot.Page.Number;
// 					}
// 				}
// 			}
//
			if (e.nEventID == nIDS[(int)IDS.e_activeDocChanged])
			{
				UpdateDocTab();
			}
			else if (e.nEventID == nIDS[(int)IDS.e_document_sourceChanged])
			{
				lbSrc.Text = pdfCtl.Src;
			}
			else if (e.nEventID == nIDS[(int)IDS.e_document_modStateChanged])
			{
				fUpdateControls++;

				PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
				ckModified.Checked  = (doc != null) && doc.Modified;

				fUpdateControls--;
			}
			else if (e.nEventID == nIDS[(int)IDS.e_pagesView_endLayoutChanging])
			{
				UpdatePagesView();
			}
			else if (e.nEventID == nIDS[(int)IDS.e_uiLanguageChanged])
			{
				string langCode = pdfCtl.Inst.GetCurrentUILang();
				foreach (ComboboxItem2 i in cbUILangs.Items)
				{
					if (i.Value == langCode)
					{
						cbUILangs.SelectedItem = i;
						break;
					}
				}
			}
		}

		private void tabCtl_Selected(object sender, TabControlEventArgs e)
		{
			if (tabCtl.SelectedTab == tabCmds)
			{
				UpdateCommandsTab();
			}
			else if (tabCtl.SelectedTab == tabView)
			{
				UpdateViewTab();
			}
			else if (tabCtl.SelectedTab == tabUILang)
			{
				UpdateUILangTab();
			}
			else if (tabCtl.SelectedTab == tabOpers)
			{
				UpdateOpersTab();
			}
			else if (tabCtl.SelectedTab == tabCustomUI)
			{
				UpdateCustomUITab();
			}
		}

		private PDFXEdit.IUIX_Cmd GetSelCmd()
		{
			if (lvCmds.SelectedItems.Count == 0)
			{
				btnCmdExec.Enabled = false;
				btnCmdOnOff.Enabled = false;
				btnCmdShowHide.Enabled = false;
				return null;
			}
			return uiInst.CmdManager.Cmds.Find(lvCmds.SelectedItems[0].SubItems[0].Text);
		}

		private void UpdateCmdItem(PDFXEdit.IUIX_Cmd cmd)
		{
			if (cmd == null)
				return;
			string cmdID = pdfCtl.Inst.ID2Str(cmd.ID);
			ListViewItem it = lvCmds.FindItemWithText(cmdID, false, 0);
			if (it == null)
				return;
			it.SubItems[1].Text = cmd.Title;
			it.SubItems[2].Text = (cmd.Offline ? "Yes" : "No");
			it.SubItems[3].Text = (cmd.Hidden ? "Yes" : "No");
			it.SubItems[4].Text = cmd.Alias;
			it.SubItems[5].Text = cmd.Tip;
		}

		private void UpdateCmdButtons()
		{
			PDFXEdit.IUIX_Cmd cmd = GetSelCmd();
			bool bEnabled = (cmd != null);

			btnCmdExec.Enabled = bEnabled;
			btnCmdOnOff.Enabled = bEnabled;
			btnCmdShowHide.Enabled = bEnabled;

			if (!bEnabled)
				return;

			btnCmdOnOff.Text = cmd.Offline ? "Turn ON" : "Turn OFF";
			btnCmdShowHide.Text = cmd.Hidden ? "Show" : "Hide";
		}

		private void lvCmds_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (fUpdateControls != 0)
				return;

			UpdateCmdButtons();
		}

		private void btnCmdOnOff_Click(object sender, EventArgs e)
		{
			PDFXEdit.IUIX_Cmd cmd = GetSelCmd();
			if (cmd == null)
				return;
			cmd.Offline = !cmd.Offline;
			UpdateCmdItem(cmd);
			UpdateCmdButtons();
		}

		private void btnCmdShowHide_Click(object sender, EventArgs e)
		{
			PDFXEdit.IUIX_Cmd cmd = GetSelCmd();
			if (cmd == null)
				return;
			cmd.Hidden = !cmd.Hidden;
			UpdateCmdItem(cmd);
			UpdateCmdButtons();
		}

		private void btnCmdExec_Click(object sender, EventArgs e)
		{
			PDFXEdit.IUIX_Cmd cmd = GetSelCmd();
			if (cmd == null)
				return;
			pdfCtl.Inst.ExecUICmd2(cmd.ID);
		}

		private void lvCmds_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo info = lvCmds.HitTest(e.X, e.Y);
			ListViewItem item = info.Item;
			if (item == null)
				return;
			PDFXEdit.IUIX_Cmd cmd = uiInst.CmdManager.Cmds.Find(item.SubItems[0].Text);
			if (cmd == null)
				return;
			pdfCtl.Inst.ExecUICmd2(cmd.ID);
		}

		private void ckAllowShortcuts_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			pdfCtl.AllowedShortcuts = ckAllowShortcuts.Checked; // pdfCtl.AllowedShortcuts == uiInst.CmdManager.AccelsAllowed
		}

		private void ckModified_CheckedChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;

			if (doc != null)
				doc.Modified = ckModified.Checked;
		}

		private void tabView_Click(object sender, EventArgs e)
		{

		}

		private void btnRunJS_Click(object sender, EventArgs e)
		{
			PDFXEdit.IString res = pdfCtl.Inst.CreateString();
			try
			{
				pdfCtl.Inst.ExecuteJS(pdfCtl.Doc, tInputJS.Text, PDFXEdit.PXV_ActionTriggerClass.PAEC_External, PDFXEdit.PXV_ActionTriggerSubclass.PAESC_Exec, null, res);
			}
			catch {	}
			tOutputJS.Text = res.Value;
		}

		private void btnShowOpenDlg_Click(object sender, EventArgs e)
		{
			try
			{
				pdfCtl.OpenDocWithDlg();
				UpdateDocTab();
			}
			catch { }
		}

		public PDFXEdit.IAFS_NamesCollection ShowOpenFilesDlg(bool bAllowMult, string sFilter)
		{
			PDFXEdit.IPXV_OpenFilesDlgRes openFilesRes = null;
			try
			{
				openFilesRes = pdfCtl.Inst.ShowOpenFilesDlg(sFilter, "", bAllowMult);
			}
			catch { openFilesRes = null; }

			if (openFilesRes == null)
				return null;

			return openFilesRes.Names;
		}

		private void btnBrowseForOpen_Click(object sender, EventArgs e)
		{
			PDFXEdit.IAFS_NamesCollection namesToOpen = ShowOpenFilesDlg(false, "<allSupp>");
			if (namesToOpen == null)
				return;
			PDFXEdit.IAFS_Name fileName = namesToOpen[0];
			tSrcToOpen.Text = fileName.FileSys.NameToString(fileName);
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			bool bIStreamDemo = ckIStreamSrcDemo.Checked;
			try
			{
				if (!bIStreamDemo)
				{
					pdfCtl.OpenDocFromPath(tSrcToOpen.Text);
				}
				else
				{
					FileStream srcStream = new FileStream(tSrcToOpen.Text, FileMode.Open);
					if (srcStream != null)
					{
						IStreamWrapper srcIStream = new IStreamWrapper(srcStream);
						pdfCtl.OpenDocFrom(srcIStream);
					}
				}
			}
			catch { }
		}

		private void btnCloseDoc_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			try
			{
				int closeFlags = ckAllowAskForSave.Checked ? (int)PDFXEdit.PXV_DocCloseFlags.PXV_DocClose_AllowUI : 0;
				doc.Close(closeFlags);
			}
			catch { }
		}

		private void tCurPage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				bool ok;
				uint cp = (uint)Str2Num(tCurPage.Text, out ok);
				if (ok && (cp != 0))
				{
					try
					{
						pdfCtl.Doc.ActiveView.PagesView.Layout.CurrentPage = cp - 1;
					}
					catch { }
				}
				UpdatePagesView();

				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void tCurPage_Leave(object sender, EventArgs e)
		{
			UpdatePagesView();
		}

		private void cbPagesZoom_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				bool ok;
				double zl = Str2Num(cbPagesZoom.Text, out ok);
				if (ok && (zl > 0.0))
				{
					try
					{
						pdfCtl.Doc.ActiveView.PagesView.Layout.SetZoom(PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_Percent, zl);
					}
					catch { }
				}
				UpdatePagesView();

				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void cbPagesZoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			ComboboxItem it = (ComboboxItem)cbPagesZoom.SelectedItem;
			if (it == null)
				return;

			PDFXEdit.PXV_ZoomMode zm = PDFXEdit.PXV_ZoomMode.PXV_ZoomMode_Percent;
			double zl = 100.0;
			if (it.Value != 0)
			{
				zm = (PDFXEdit.PXV_ZoomMode)it.Value;
			}
			else
			{
				bool ok;
				zl = Str2Num(it.Text, out ok);
				if (!ok || (zl <= 0.0))
					return;
			}

			try
			{
				doc.ActiveView.PagesView.Layout.SetZoom(zm, zl);
			}
			catch { }
		}

		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			try
			{
				doc.ActiveView.PagesView.ZoomInOut(true);
			}
			catch { }
		}

		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			try
			{
				doc.ActiveView.PagesView.ZoomInOut(false);
			}
			catch { }
		}

		private void btnShowSaveAsDlg_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			try
			{
				doc.Save(null, (int)(PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_AllowUI | PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_Copy | PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_SwitchToDest));
			}
			catch { }
		}

		private void btnSimpleSave_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			try
			{
				doc.Save(null, (int)PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_AllowUI);
			}
			catch { }
		}

		private void btnBrowseForSaveAs_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_SaveFileDlgRes saveFilesRes = null;
			try
			{
				saveFilesRes = pdfCtl.Inst.ShowSaveFileDlg("PDF Documents (*.pdf)|*.pdf|All Files (*.*)|*.*");
			}
			catch { saveFilesRes = null; };
			if (saveFilesRes != null)
				tDestToSave.Text = saveFilesRes.Name.FileSys.NameToString(saveFilesRes.Name);
		}

		private void custSaveToStrDest(PDFXEdit.IPXV_Document doc)
		{
			if (doc == null)
				return;
			try
			{
				PDFXEdit.IString destPath = pdfCtl.Inst.CreateString(tDestToSave.Text);
				doc.Save(destPath, GetSaveDocFlags());
			}
			catch { }
		}

		private void custSaveToNameDest(PDFXEdit.IPXV_Document doc)
		{
			if (doc == null)
				return;
			try
			{
				PDFXEdit.IAFS_Name destPath = fsInst.DefaultFileSys.StringToName(tDestToSave.Text); // only local file name
				doc.Save(destPath, GetSaveDocFlags());
			}
			catch { }
		}

		private void custSaveToNameDestEx(PDFXEdit.IPXV_Document doc)
		{
			if (doc == null)
				return;
			try
			{
				PDFXEdit.IAFS_Name destPath = pdfCtl.Inst.PathToName(tDestToSave.Text); // all supported types of URL's
				doc.Save(destPath, GetSaveDocFlags());
			}
			catch { }
		}

		private int GetSaveDocFlags()
		{
			int res = (int)PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_AllowUI;

			if (ckSwitchToDest.Checked)
				res |= (int)PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_SwitchToDest;

			return res;
		}

		private void custSaveToFileDest(PDFXEdit.IPXV_Document doc)
		{
			if (doc == null)
				return;
			try
			{
				PDFXEdit.IAFS_Name destPath = fsInst.DefaultFileSys.StringToName(tDestToSave.Text); // only local file name

				int openFileFlags = (int)(PDFXEdit.AFS_OpenFileFlags.AFS_OpenFile_CreateAlways | PDFXEdit.AFS_OpenFileFlags.AFS_OpenFile_Read | PDFXEdit.AFS_OpenFileFlags.AFS_OpenFile_Write | PDFXEdit.AFS_OpenFileFlags.AFS_OpenFile_FullCache);
				PDFXEdit.IAFS_File destFile = destPath.FileSys.OpenFile(destPath, openFileFlags);
				if (destFile != null)
				{
					doc.Save(destFile, GetSaveDocFlags());
					// flush file data
					destFile.Close();
					destFile = null;
				}
			}
			catch { }
		}

		private void custSaveToIStreamDest(PDFXEdit.IPXV_Document doc)
		{
			if (doc == null)
				return;

			try
			{
				FileStream destStream = new FileStream(tDestToSave.Text, FileMode.Create, FileAccess.ReadWrite);

				int saveDocFlags = GetSaveDocFlags();

				if (destStream != null)
				{
					IStreamWrapper destIStream = new IStreamWrapper(destStream);

					if (destIStream != null)
						doc.Save(destIStream, saveDocFlags);

					destIStream = null;
				}

				if ((saveDocFlags & (int)PDFXEdit.PXV_DocSaveFlags.PXV_DocSave_SwitchToDest) == 0)
					destStream.Close();

				destStream = null;
			}
			catch { }
		}


		private void btnSaveToCustDest_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_Document doc = pdfCtl.Doc;
			if (doc == null)
				return;

			if (!ckIStreamDestDemo.Checked)
			{
				// custSaveToStrDest(doc);

				// or
				custSaveToNameDest(doc);

				// or
				// custSaveToNameDestEx(doc);

				// or
				// custSaveToFileDest(doc);
			}
			else
			{
				custSaveToIStreamDest(doc);
			}
		}

		private void btnSetUILang_Click(object sender, EventArgs e)
		{
			ComboboxItem2 it = (ComboboxItem2)cbUILangs.SelectedItem;
			if (it == null)
				return;

			pdfCtl.Inst.SetCurrentUILang(it.Value);
		}

		private void gboxPrintOpts_Enter(object sender, EventArgs e)
		{

		}

		public void OnOperSelChanged()
		{
			int ctlSpace = btnRunOp.Height;
			ctlSpace += ctlSpace / 2;
			int maxOptsHeight = tabCtl.DisplayRectangle.Height - (pnOpOpts.Top + ctlSpace);

			Form opOpts = null;
			OperationDemo opDemo = (OperationDemo)cbOpers.SelectedItem;
			bool bCanRun = false;
			bool bShowDocReqWarn = false;
			if (opDemo != null)
			{
				opOpts = opDemo.UI;
				bShowDocReqWarn = opDemo.DocIsRequired() && (pdfCtl.Doc == null);
				bCanRun = !opDemo.DocIsRequired() || (pdfCtl.Doc != null);
			}

			int y = pnOpOpts.Top;
			if (opOpts == null)
			{
				pnOpOpts.Hide();
				pnOpOpts.Controls.Clear();
			}
			else
			{
				foreach (Control ctl in pnOpOpts.Controls)
					ctl.Hide();
				pnOpOpts.Controls.Clear();

				int optsHeight = opDemo.Height;

				if (optsHeight > maxOptsHeight)
					optsHeight = maxOptsHeight;
				pnOpOpts.Height = optsHeight;

				y = pnOpOpts.Bottom + ctlSpace / 4;

				opOpts.TopLevel = false;
				opOpts.AutoScroll = true;
				opOpts.Dock = DockStyle.Left;
				opOpts.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

				pnOpOpts.Controls.Add(opOpts);

				{
					IFormHelper hlp = (IFormHelper)opOpts;
					if (hlp != null)
					{
						hlp.OnUpdate();
						bCanRun = bCanRun && hlp.IsValid();
					}
				}

				pnOpOpts.Show();
				opOpts.Show();
			}

			btnRunOp.Location = new Point(btnRunOp.Left, y);
			ckShowOpDlg.Location = new Point(ckShowOpDlg.Left, y);
			lbDocReq.Location = new Point(lbDocReq.Left, y);
			picDocReq.Location = new Point(picDocReq.Left, y);
			lbDocReq.Visible = bShowDocReqWarn;
			picDocReq.Visible = bShowDocReqWarn;

			AllowRunOper(bCanRun);
		}

		public void AllowRunOper(bool bAllow)
		{
			btnRunOp.Enabled = bAllow;

			bool bRunOnlyWithStdDlg = true;

			OperationDemo opDemo = (OperationDemo)cbOpers.SelectedItem;
			if (opDemo != null)
				bRunOnlyWithStdDlg = (opDemo.Flags & (uint)DemoFlags.RunOnlyWithStdDlg) != 0;

			ckShowOpDlg.Enabled = bAllow && !bRunOnlyWithStdDlg;

			if (bRunOnlyWithStdDlg)
				ckShowOpDlg.Checked = true;
		}

		private void cbOpers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fUpdateControls != 0) return;

			OnOperSelChanged();
		}

		private void btnRunOp_Click(object sender, EventArgs e)
		{
			OperationDemo it = (OperationDemo)cbOpers.SelectedItem;
			if (it == null)
				return;
			if (!it.Run(this, ckShowOpDlg.Checked, true))
				return;
			Form opOpts = it.UI;
			if (opOpts != null)
			{
				IFormHelper hlp = (IFormHelper)opOpts;
				if (hlp != null)
					hlp.OnUpdate();
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://sdkhelp.tracker-software.com/view/Main_Page");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/tracker-software/PDFEditorSDKExamples/tree/master/CSharp/FullDemo");
		}

		public static string fnt2str(Font f)
		{
			return f.Name + ", " + FormatNum(f.SizeInPoints) + " pt";
		}

		void UpdateCustomUITab()
		{
			fUpdateControls++;

			PDFXEdit.IUIX_Theme th = uiInst.Theme;

			// update colors
			btnFaceClr.BackColor = rgb2clr(th.StdColor[PDFXEdit.UIX_StdColor.UIX_StdColor_Base]);
			btnWndClr.BackColor = rgb2clr(th.StdColor[PDFXEdit.UIX_StdColor.UIX_StdColor_Window]);
			btnTextClr.BackColor = rgb2clr(th.StdColor[PDFXEdit.UIX_StdColor.UIX_StdColor_Text]);
			btnSelClr.BackColor = rgb2clr(th.StdColor[PDFXEdit.UIX_StdColor.UIX_StdColor_CtlSel]);

			// update fonts
			PDFXEdit.IUIX_Font fnt = th.StdFont[PDFXEdit.UIX_StdFont.UIX_StdFont_Default];
			FontDefault = new Font(fnt.FaceName, (float)fnt.Size);
			fnt = th.StdFont[PDFXEdit.UIX_StdFont.UIX_StdFont_Command];
			FontMenu = new Font(fnt.FaceName, (float)fnt.Size);

			lbDefaultFnt.Text = fnt2str(FontDefault);
			lbMenuFnt.Text = fnt2str(FontMenu);

			fUpdateControls--;
		}

		void UpdateSettingsIoTab()
		{
			bool fKeep = ckKeepPrefs.Checked;
			rbPrefs_file.Enabled = fKeep;
			rbPrefs_reg.Enabled = fKeep;

			bool fUseReg = rbPrefs_reg.Checked;
			tPrefs_reg.Enabled = fKeep;

			tPrefs_file.Enabled = fKeep && !fUseReg;
			btnBrowseForPrefsFile.Enabled = fKeep && !fUseReg;

			tHistDir.Enabled = ckKeepHist.Checked;
			btnBrowseForHistDir.Enabled = ckKeepHist.Checked;
		}

		void ApplyCustomUI()
		{
			if (fUpdateControls != 0)
				return;

			PDFXEdit.ICabNode pr = pdfCtl.Inst.Settings["CustomUI"];

			// setup colors
			{
				PDFXEdit.ICabNode clrArr = pr["Colors"];
				SetCustColor(clrArr, "base",		clr2str(btnFaceClr.BackColor));
				SetCustColor(clrArr, "window",		clr2str(btnWndClr.BackColor));
				SetCustColor(clrArr, "text",		clr2str(btnTextClr.BackColor));
				SetCustColor(clrArr, "selection",	clr2str(btnSelClr.BackColor));
			}

			// setup fonts
			{
				PDFXEdit.ICabNode fntArr = pr["Fonts"];
				SetCustFont(fntArr,	"default",	FontDefault.Name,	FontDefault.SizeInPoints);
				SetCustFont(fntArr,	"menu",		FontMenu.Name,		FontMenu.SizeInPoints);
			}

			// {
			// 	pdfCtl.Inst.Settings["CustomUI.Backgrounds.Main.Style"].v = "S"; // solid
			// 	pdfCtl.Inst.Settings["CustomUI.Backgrounds.Main.ShowOverlay"].v = false; // no tob/bottom shadows
			// }
			//
			// {
			// 	pdfCtl.Inst.Settings["CustomUI.Backgrounds.Dialog.Style"].v = "S"; // solid
			// 	pdfCtl.Inst.Settings["CustomUI.Backgrounds.Dialog.ShowOverlay"].v = false; // no tob/bottom shadows
			// }

			pdfCtl.Inst.FireAppPrefsChanged(PDFXEdit.PXV_AppPrefsChanges.PXV_AppPrefsChange_CustomUI);

			UpdateCustomUITab();
		}

		private void btnFaceClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnFaceClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				btnFaceClr.BackColor = colorDialog1.Color;
				ApplyCustomUI();
			}
		}

		private void btnTextClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnTextClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				btnTextClr.BackColor = colorDialog1.Color;
				ApplyCustomUI();
			}
		}

		private void btnWndClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnWndClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				btnWndClr.BackColor = colorDialog1.Color;
				ApplyCustomUI();
			}
		}

		private void btnSelClr_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = btnSelClr.BackColor;
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				btnSelClr.BackColor = colorDialog1.Color;
				ApplyCustomUI();
			}
		}

		private void btnResetUI_Click(object sender, EventArgs e)
		{
			PDFXEdit.ICabNode pr = pdfCtl.Inst.Settings["CustomUI"];
			pr.Clear();
			pdfCtl.Inst.FireAppPrefsChanged(PDFXEdit.PXV_AppPrefsChanges.PXV_AppPrefsChange_CustomUI);
			UpdateCustomUITab();
		}

		private void btnMenuFnt_Click(object sender, EventArgs e)
		{
			fontDialog1.Font = FontMenu;
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				FontMenu = fontDialog1.Font;
				ApplyCustomUI();
			}
		}

		private void btnDefaultFnt_Click(object sender, EventArgs e)
		{
			fontDialog1.Font = FontDefault;
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				FontDefault = fontDialog1.Font;
				ApplyCustomUI();
			}
		}

		private void ckKeepPrefs_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSettingsIoTab();
		}

		private void rbPrefs_file_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSettingsIoTab();
		}

		private void rbPrefs_reg_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSettingsIoTab();
		}

		private void btnBrowseForPrefsFile_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_SaveFileDlgRes saveFilesRes = null;
			try
			{
				saveFilesRes = pdfCtl.Inst.ShowSaveFileDlg("PDF-XChange Editor Preferences (*.dat)|*.dat|All Files (*.*)|*.*");
			}
			catch { saveFilesRes = null; };
			if (saveFilesRes != null)
				tPrefs_file.Text = saveFilesRes.Name.FileSys.NameToString(saveFilesRes.Name);
		}

		private void btnBrowseForSettFile_Click(object sender, EventArgs e)
		{
			PDFXEdit.IPXV_SaveFileDlgRes saveFilesRes = null;
			try
			{
				saveFilesRes = pdfCtl.Inst.ShowSaveFileDlg("PDF-XChange Editor Settings (*.xcs)|*.xcs|All Files (*.*)|*.*");
			}
			catch { saveFilesRes = null; };
			if (saveFilesRes != null)
				tSettFile.Text = saveFilesRes.Name.FileSys.NameToString(saveFilesRes.Name);
		}

		private void btnSettLoad_Click(object sender, EventArgs e)
		{
			try
			{
				PDFXEdit.IOperation op = pdfCtl.Inst.CreateOp(pdfCtl.Inst.Str2ID("op.settings.import"));
				op.Params.Root["Options.History"].v = ckSettIncHist.Checked;
				op.Params.Root["Input"].v = fsInst.DefaultFileSys.StringToName(tSettFile.Text);
				op.Do();

				UpdateDocumentsOpts();
			}
			catch { }
		}

		private void btnSettSave_Click(object sender, EventArgs e)
		{
			try
			{
				PDFXEdit.IOperation op = pdfCtl.Inst.CreateOp(pdfCtl.Inst.Str2ID("op.settings.export"));
				op.Params.Root["Options.History"].v = ckSettIncHist.Checked;
				op.Params.Root["Input"].v = fsInst.DefaultFileSys.StringToName(tSettFile.Text);
				op.Do();
			}
			catch { }
		}

		private void ckKeepHist_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSettingsIoTab();
		}

		private void btnBrowseForHistDir_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = tHistDir.Text;
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
				tHistDir.Text = folderBrowserDialog1.SelectedPath;
		}

		private void ckMultDocs_CheckedChanged(object sender, EventArgs e)
		{
			pdfCtl.Inst.Settings["Docs.SingleWnd"].v = !ckMultDocs.Checked;
			pdfCtl.Inst.FireAppPrefsChanged(PDFXEdit.PXV_AppPrefsChanges.PXV_AppPrefsChange_Documents);

			// disable 'dock/undock/reorder' feature for main panes:
			pdfCtl.Inst.ActiveMainView.Panes.Layout.Obj.SetStyle((Int64)PDFXEdit.UIX_LayoutStyleFlags.UIX_LayoutStyle_PanesNoReorder, (Int64)PDFXEdit.UIX_LayoutStyleFlags.UIX_LayoutStyle_PanesNoReorder);
			pdfCtl.Inst.ActiveMainView.DocViewsArea.Panes.Layout.Obj.SetStyle((Int64)PDFXEdit.UIX_LayoutStyleFlags.UIX_LayoutStyle_PanesNoReorder, (Int64)PDFXEdit.UIX_LayoutStyleFlags.UIX_LayoutStyle_PanesNoReorder);
		}

		private void ckHideSingleTab_CheckedChanged(object sender, EventArgs e)
		{
			pdfCtl.Inst.Settings["Docs.HideSingleTab"].v = ckHideSingleTab.Checked;
			pdfCtl.Inst.FireAppPrefsChanged(PDFXEdit.PXV_AppPrefsChanges.PXV_AppPrefsChange_Documents);
		}

		
		private void ckRibbonUI_CheckedChanged(object sender, EventArgs e)
		{
			if (pdfCtl == null || pdfCtl.Frame == null)
				return;
			if (fUpdateControls != 0) return;

			pdfCtl.Inst.EnableRibbonUI(!pdfCtl.Frame.View.IsRibbonMode);

			bool bClassic = !pdfCtl.Frame.View.IsRibbonMode;
			ckShowPagesLayoutBar.Enabled = bClassic;
			ckShowPagesNavBar.Enabled = bClassic;
			ckShowPageZoomBar.Enabled = bClassic;
			ckShowDocLaunchBar.Enabled = bClassic;
			ckShowDocOptsBar.Enabled = bClassic;
			ckShowMenu.Enabled = bClassic;
			ckShowFileBar.Enabled = bClassic;
			ckShowStdBar.Enabled = bClassic;
			ckShowPropBar.Enabled = bClassic;
			ckShowCommentBar.Enabled = bClassic;
			ckShowMeasureBar.Enabled = bClassic;
			ckShowContentEdtBar.Enabled = bClassic;
			ckShowRotateViewBar.Enabled = bClassic;
			ckShowFormViewBar.Enabled = bClassic;

			UpdateViewTab();
		}

		private void cmdBarsTree_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (fUpdateControls != 0) return;

			ToolbarInfo TI = (ToolbarInfo)e.Node.Tag;
			if (TI.IsGroup())
				return;

			TI.m_bHidden = !e.Node.Checked;

			if (TI.IsTab())
			{
				pdfCtl.Inst.ShowRibbonTab2(TI.m_nID, !TI.m_bHidden);
			}
			else
			{
				pdfCtl.Inst.ShowCmdBar2(TI.m_nID, !TI.m_bHidden);
			}

			UpdateViewTab(false);
		}

		private void cmdBarsTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			//if (e.Node.IsVisible && e.Bounds.Location.X >= 0 && e.Bounds.Location.Y >= 0)
			//{
			//	if (e.Node.Parent == null)
			//	{
			//		// draw entry without checkbox
			//		e.DrawDefault = false;
			//		Font useFont = null;
			//		Brush useBrush = null;
			//		useFont = e.Node.TreeView.Font;
			//		useBrush = SystemBrushes.WindowText;
			//		e.Graphics.DrawString(e.Node.Text, useFont, useBrush, e.Bounds.Location);
			//		return;
			//	}
			//}

			//e.DrawDefault = true;
			//return;
		}
	}
}
