using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PDFXEdit;


namespace CustomPane
{
	public partial class Form1 : Form
	{
		public const int WM_SIZE = (int)0x0005;
		public const int WS_CLIPCHILDREN = (int)0x02000000L;
		public const int WS_CLIPSIBLINGS = (int)0x04000000L;
		public const string MY_PANE_ID = "myCustomPane"; // one myCustomPane per pdfCtl
		public const string MY_DOC_PANE_ID = "myCustomDocPane"; // each separate document-view(document-tab) will have own instance of myCustomDocPane (note: one pdfCtl may contain many document-views)
		const int defPaneSize = 300;
		public int nMY_PANE_ID = 0;
		public int nMY_DOC_PANE_ID = 0;
		public int e_documentView_ready = 0;
		PDFXEdit.IString settingsLocation = null;
		CustomPanesCreator myPanesCreator;

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		public Form1()
		{
			InitializeComponent();

			PDFXEdit.PXV_Inst Inst = pdfCtl.Inst;

			nMY_PANE_ID = Inst.Str2ID(MY_PANE_ID, true);
			nMY_DOC_PANE_ID = Inst.Str2ID(MY_DOC_PANE_ID, true);
			e_documentView_ready = Inst.Str2ID("e.documentView.ready", true);

			pdfCtl.EnableEventListening2(e_documentView_ready, true); // to call pdfCtl_OnEvent

			// Register a callback to create custom panes during load of panes layout (from the settings)
			myPanesCreator = new CustomPanesCreator(Inst, this);
			Inst.RegisterViewCreator(myPanesCreator);

			settingsLocation = Inst.CreateString("HKCU\\Software\\{PDFXEdit.CustomPane.tmp}");
			try
			{
				Inst.LoadUserSettings(settingsLocation); // try to load all previously saved settings (including the custom layout of panes)
			}
			catch {	};

			/////////////////////////////////////////////////////////////////////////////////////////
			// Check if our custom pane is already present in the mainView's layout, if not - add it
			/////////////////////////////////////////////////////////////////////////////////////////

			/**/
			// Method 1: use the Inst.ActiveMainView.Layout object
			PDFXEdit.IUIX_Layout layout = Inst.ActiveMainView.Panes.Layout;
			if (!HasPane(layout, nMY_PANE_ID)) // check if pane is present already in the layout
			{
				PDFXEdit.IPXV_View paneContainer;
				PDFXEdit.tagRECT rc;
				rc.left = rc.top = rc.right = rc.bottom = 0;
				myPanesCreator.CreateNewView(Inst.ActiveMainView, layout.Obj, nMY_PANE_ID, "", ref rc, out paneContainer);
				if (paneContainer != null)
				{
					PDFXEdit.tagSIZE sz;
					sz.cx = sz.cy = defPaneSize;
					layout.Insert(	paneContainer.Obj, 
									"My Custom Pane",
									layout.Root, ref sz, 
									(int)UIX_LayoutItemStyleFlags.UIX_LayoutItemStyle_FixedSize); // make pane fixed size (not proportional)
				}
			}

			/*/
			// Method 2: check and manipulate the panes layout settings
			bool paneAdded = false;
			do
			{
				// First we check whether the pane is already inside of the settings CAB
				PDFXEdit.ICabNode layout = Inst.Settings["MainView.Layout"]; // This is the layout CAB - here all of the Panes' settings are stored
																			 // Then we have docked panes and floating panes
																			 // Docked panes are stored in Root and floating panes are stored in FloatingRoots
																			 // We'll need to run recursively through the children to see whether our custom pane is inside

				// Lookup in docked panes
				if (HasPane(layout["Root"], MY_PANE_ID))
					break;
				// Lookup in floating panes
				if (HasPane(layout["FloatingRoots"], MY_PANE_ID))
					break;
				// If we don't yet have the pane added then in this sample we will have to add it as a docked pane
				ICabNode root = layout["Root"];
				// First level children of the Root node are place holders for panes
				// The root itself has a UIX_LayoutItemStyle_Splitted | UIX_LayoutItemStyle_VertSplitters | UIX_LayoutItemStyle_NoTabBar style
				// In this sample we will add panes to the rightmost splitter (where the search view and properties pane are)
				ICabNode placeHolders = root["Kids"];
				// Taking the last child for the rightmost placeholder and if it does not exist for some reason, we will add it
				// Alternatively the placeholders can be added to divide the Main View even more
				// For example, if you want your Custom view to be added before the Properties View and Search View then insert the placeholder before the placeholder that holds these views
				ICabNode placeHolder = null;
				if (placeHolders.Count == 0)
					placeHolder = placeHolders.Add();
				else
					placeHolder = placeHolders[placeHolders.Count - 1];
				// Now we have our new placeholder and we will have to add our Custom View to it
				ICabNode kid = placeHolder["Kids"].Add();
				// Now we will have to fill the newly added CAB node with needed data
				kid["ID"].v = MY_PANE_ID;
				kid["S"].v = (int)UIX_LayoutItemStyleFlags.UIX_LayoutItemStyle_FixedSize; // make pane fixed size (not proportional)
				kid["FW"].v = defPaneSize;  // fixed-width (UIX_LayoutItemStyle_FixedSize is required)
				kid["FH"].v = defPaneSize;  // fixed-height (UIX_LayoutItemStyle_FixedSize is required)
				kid["Title"].v = "My Custom Main Pane"; // Title for display
				paneAdded = true;
			} while (false);

			if (paneAdded)
				Inst.ActiveMainView.LoadPanesLayout(); // reload the mofified layout of panes
			/*/
			/**/
		}

		private void pdfCtl_OnEvent(object sender, AxPDFXEdit._IPXV_ControlEvents_OnEventEvent e)
		{
			if (e.nEventID == e_documentView_ready)
			{
				// Add new document-pane to the new document-view
				PDFXEdit.IPXV_DocumentView docView = e.pFrom as PDFXEdit.IPXV_DocumentView;
				if (docView != null)
				{
					PDFXEdit.IUIX_Layout layout = docView.Panes.Layout;
					if (!HasPane(layout, nMY_DOC_PANE_ID)) // check if our pane isn't exist already (might be loaded from the settings)
					{
						// Add our custom pane to the document view
						PDFXEdit.IPXV_View paneContainer;
						PDFXEdit.tagRECT rc;
						rc.left = rc.top = rc.right = rc.bottom = 0;
						myPanesCreator.CreateNewView(docView, layout.Obj, nMY_DOC_PANE_ID, "", ref rc, out paneContainer);
						if (paneContainer != null)
						{
							PDFXEdit.tagSIZE sz;
							sz.cx = sz.cy = defPaneSize;
							layout.Insert(paneContainer.Obj,
											"Document: My Custom Pane",
											layout.Root, ref sz,
											(int)UIX_LayoutItemStyleFlags.UIX_LayoutItemStyle_FixedSize,  // make pane fixed size (not proportional)
											0); // put it to the left edge of document view
						}
					}
				}
			}
		}


		class CustomPanesCreator : PDFXEdit.IPXV_ViewCreator
		{
			PDFXEdit.IPXV_Inst Inst = null;
			private Form1 m_frm;
			public CustomPanesCreator(PDFXEdit.IPXV_Inst vInst, Form1 frm)
			{
				Inst = vInst;
				m_frm = frm;
			}
			public void CreateNewView(PDFXEdit.IPXV_View pParentView, PDFXEdit.IUIX_Obj pParentObj, int nViewID, string sCustomTag, ref PDFXEdit.tagRECT stPos, out PDFXEdit.IPXV_View pNewView)
			{
				pNewView = null;
				if ((pParentView == null) || (pParentObj == null) || (nViewID == 0))
					throw new System.ArgumentException();
				
				PDFXEdit.IPXV_DocumentView docView = null;
				PDFXEdit.IPXV_MainView mainView = null;
				if (nViewID == m_frm.nMY_PANE_ID)
				{
					mainView = pParentView as PDFXEdit.IPXV_MainView;
					if (mainView == null)
						throw new System.ArgumentException();
				}
				else if (nViewID == m_frm.nMY_DOC_PANE_ID)
				{
					docView = pParentView as PDFXEdit.IPXV_DocumentView;
					if (docView == null)
						throw new System.ArgumentException();
				}
				else
				{
					throw new System.ArgumentException();
				}

				UserControl1 userCtrl = new UserControl1();
				CustomPaneContainer container = new CustomPaneContainer(pParentView, nViewID, userCtrl);

				PDFXEdit.IUIX_Inst uiInst = (PDFXEdit.IUIX_Inst)Inst.GetExtension("UIX");

				PDFXEdit.UIX_CreateObjParams cp = new PDFXEdit.UIX_CreateObjParams();
				cp.pImpl = container as PDFXEdit.IUIX_ObjImpl;
				cp.pParent = pParentObj;
				cp.nCreateFlags = (int)PDFXEdit.UIX_CreateObjFlags.UIX_CreateObj_Windowed;
				cp.pID = Inst.ID2Str(nViewID);
				cp.nStdClass = (int)PDFXEdit.UIX_StdClasses.UIX_StdClass_Blank;
				cp.nObjStyle = 0;
				cp.nWndStyle = WS_CLIPCHILDREN | WS_CLIPSIBLINGS;
				cp.rc = stPos;
				
				// Create the UI-container and put the user-control inside it
				uiInst.CreateObj(cp);
				pNewView = container;
			}
		}

		public class CustomPaneContainer : PDFXEdit.IPXV_View
		{
			int m_nID = 0;
			PDFXEdit.IUIX_Obj m_Obj = null;
			PDFXEdit.IPXV_View m_Parent = null;

			public UserControl1 m_UserCtrl = null;

			public CustomPaneContainer(PDFXEdit.IPXV_View parent, int id, UserControl1 userCtrl)
			{
				m_nID = id;
				m_Parent = parent;
				m_UserCtrl = userCtrl;
			}

			public PDFXEdit.IPXV_View Focus
			{
				get { return null; }
			}

			public int ID
			{
				get { return m_nID; }
			}

			public PDFXEdit.IUIX_Obj Obj
			{
				get { return m_Obj; }
			}

			public void OnEvent(PDFXEdit.IUIX_Obj pSender, PDFXEdit.IUIX_Event pEvent)
			{
				if (pEvent.Code == (int)PDFXEdit.UIX_EventCodes.e_First)
				{
					m_Obj = pSender;
					SetParent(m_UserCtrl.Handle, (IntPtr)m_Obj.WndHandle);
				}
				else if (pEvent.Code == (int)PDFXEdit.UIX_EventCodes.e_Last)
				{
					m_Obj = null;
				}
				else if (pEvent.Code == (int)WM_SIZE)
				{
					var rc = m_Obj.ClientRect;
					m_UserCtrl.Location = new Point(rc.left, rc.top);
					m_UserCtrl.Size = new Size((rc.right - rc.left), (rc.bottom - rc.top));
				}
			}

			public void OnPostEvent(PDFXEdit.IUIX_Obj pSender, PDFXEdit.IUIX_Event pEvent) { }
			public void OnPreEvent(PDFXEdit.IUIX_Obj pSender, PDFXEdit.IUIX_Event pEvent) { }
			public void InsertCmdItems(INumArray pCmds, INumArray pInsertPos, int nFlags = 0, IUIX_CmdMenu pSubMenu = null) { }
			public void InsertCmdItems2(ref int nCmdsArr, int nCmdsArrLen, ref int nInsertPosArr, int nInsertPosArrLen, int nFlags = 0, IUIX_CmdMenu pSubMenu = null) { }
			public IUIX_CmdPane get_CmdPane(UIX_CmdPaneSides nSide) { return null; }
			public IUIX_CmdBar get_CmdBar(string sCmdBarID) { return null; }
			public IUIX_CmdBar get_CmdBar2(int nCmdBarID) { return null; }
			public PDFXEdit.IPXV_ViewPanesCollection Panes { get { return null; } }
			public PDFXEdit.IPXV_View Parent { get { return m_Parent; } }
			public IUIX_CmdPane CmdPaneTop { get { return null; } }
			public IUIX_CmdPane CmdPaneBottom { get { return null; } }
			public IUIX_CmdPane CmdPaneLeft { get { return null; } }
			public IUIX_CmdPane CmdPaneRight { get { return null; } }
			public bool IsRibbonMode { get { return false; } }
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			pdfCtl.Inst.SaveUserSettings(settingsLocation); // save all user settings, including actual layout of panes
			
			// It is critical to call Inst.Shutdown() directly because we already called Inst.Init() in MainFrm() constructor
			pdfCtl.Inst.Shutdown();

			/////////////////////////////////////////////////////////////////////////////////////
			// Forced release of all COM-objects that may still captured by Garbage Collector. //
			// It is critical to release them before destroying of pdfCtl!                     //
			/////////////////////////////////////////////////////////////////////////////////////
			public bool IsDuplicate(IPXV_View pOther)
			{
				throw new NotImplementedException();
			}
			public void OnBeforeSaveSession(int nFlags = 0)
			{
					throw new NotImplementedException();
			}
			public void Close(int nFlags = 0)
			{
				throw new NotImplementedException();
			}

			public PDFXEdit.IPXV_ViewPanesCollection Panes
			{
				get { return m_Panes; }
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		static public bool HasPane(ICabNode root, string paneID)
		{
			ICabNode kids = root["Kids"];
			for (uint i = 0; i < kids.Count; i++)
			{
				ICabNode kid = kids[i];
				if ((kid == null) || (!kid.Valid))
					continue;
				if (kid["ID"].String == paneID)
					return true;
				if (HasPane(kid, paneID))
					return true;
			}
			return false;
		}
		static public bool HasPane(IUIX_LayoutItem item, int paneID)
		{
			if (item.ID == paneID)
				return true;
			uint count = item.Count;
			for (uint i = 0; i < count; i++)
			{
				IUIX_LayoutItem kid = item[i];
				if (kid.ID == paneID)
					return true;
				if (HasPane(kid, paneID))
					return true;
			}
			return false;
		}
		static public bool HasPane(IUIX_Layout layout, int paneID)
		{
			if (HasPane(layout.Root, paneID))
				return true;
			uint count = layout.FloatingRootsCount;
			for (uint i = 0; i < count; i++)
			{
				if (HasPane(layout.FloatingRoot[i], paneID))
					return true;
			}
			return false;
			public IUIX_CmdPane CmdPaneLeft
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public IUIX_CmdPane CmdPaneRight
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public bool IsRibbonMode
			{
				get
				{
					throw new NotImplementedException();
				}
			}
			public int StateFlags
			{
				get
				{
					throw new NotImplementedException();
				}
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			// It is critical to call Inst.Shutdown() directly because we already called Inst.Init() in MainFrm() constructor
			pdfCtl.Inst.Shutdown();

			/////////////////////////////////////////////////////////////////////////////////////
			// Forced release of all COM-objects that may still captured by Garbage Collector. //
			// It is critical to release them before destroying of pdfCtl!                     //
			/////////////////////////////////////////////////////////////////////////////////////

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
