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

namespace CustomPane
{


	public partial class Form1 : Form
	{
		public string m_sCustomPaneID = "myCustomPane";
		public Form1()
		{
			//Custom Instance initialization
			PDFXEdit.PXV_Inst Inst = new PDFXEdit.PXV_Inst();
			Inst.Init(null, "", "", "", "", (int)PDFXEdit.PXV_AppTypeFlags.PXV_AppType_SDK);

			InitializeComponent();

			//Creating Custom Pane's ID
			int nViewID = Inst.Str2ID(m_sCustomPaneID, true);
			//This part is necessary for correct pane loading from settings CAB - without this it won't show
			do
			{
				//First we check whether the pane is already inside of the settings CAB
				PDFXEdit.ICabNode layout = Inst.Settings["MainView.Layout"]; //This is the layout CAB - here all of the Panes' settings are stored
																			 //Then we have docked panes and floating panes
																			 //Docked panes are stored in Root and floating panes are stored in FloatingRoots
																			 //We'll need to run recursively through the children to see whether our custom pane is inside
				bool bHasPane = HasPane(layout["Root"]);
				if (bHasPane)
					break;
				bHasPane = HasPane(layout["FloatingRoots"]);
				if (bHasPane)
					break;
				//If we don't yet have the pane added then in this sample we will have to add it as a docked pane
				ICabNode root = layout["Root"];
				//First level children of the Root node are place holders for panes
				//The root itself has a UIX_LayoutItemStyle_Splitted | UIX_LayoutItemStyle_VertSplitters | UIX_LayoutItemStyle_NoTabBar style
				//In this sample we will add panes to the rightmost splitter (where the search view and properties pane are)
				ICabNode placeHolders = root["Kids"];
				//Taking the last child for the rightmost placeholder and if it does not exist for some reason, we will add it
				//Alternatively the placeholders can be added to divide the Main View even more
				//For example, if you want your Custom view to be added before the Properties View and Search View then insert the placeholder before the placeholder that holds these views
				ICabNode placeHolder = null;
				if (placeHolders.Count == 0)
					placeHolder = placeHolders.Add();
				else
					placeHolder = placeHolders[placeHolders.Count - 1];
				//Now we have our new placeholder and we will have to add our Custom View to it
				ICabNode kid = placeHolder["Kids"].Add();
				//Now we will have to fill the newly added CAB node with needed data
				kid["ID"].v = m_sCustomPaneID;
				kid["S"].v = 0; //UIX_LayoutItemStyleFlags
				kid["FW"].v = 200; //width
								   //Flags
								   //UIX_LayoutItemFlag_Hidden = 0x1,
								   //UIX_LayoutItemFlag_Client = 0x4,
								   //UIX_LayoutItemFlag_Minimized = 0x8,
				kid["F"].v = 0;
				//This will be displayed in the pane's title
				kid["Title"].v = "My Custom View";
			} while (false);

			//Creating a view creator so that the control will know how to initialize our Custom pane
			CustomViewCreator myViewCreator = new CustomViewCreator(Inst, m_sCustomPaneID, this);
			Inst.RegisterViewCreator(myViewCreator);
			//Loading panes layout
			Inst.ActiveMainView.LoadPanesLayout();

			//Showing our pane when the Control is initialized
			for (uint i = 0; i < Inst.ActiveMainView.Panes.Count; i++)
			{
				IPXV_View view = Inst.ActiveMainView.Panes[i];
				if (view?.ID == nViewID)
				{
					Inst.ActiveMainView.Panes.Show(view);
					break;
				}
			}
		}


		public bool HasPane(ICabNode root)
		{
			//Getting children of the current root to see whether they have the ID equal to m_sCustomPaneID
			ICabNode kids = root["Kids"];
			for (uint i = 0; i < kids.Count; i++)
			{
				ICabNode kid = kids[i];
				if ((kid == null) || (!kid.Valid))
					continue;
				if (kid["ID"].String == m_sCustomPaneID)
					return true;
				if (HasPane(kid))
					return true;
			}
			return false;
		}


		class CustomViewCreator : PDFXEdit.IPXV_ViewCreator
		{
			PDFXEdit.IPXV_Inst Inst = null;
			public string m_sCustomPaneID;
			private Form1 m_frm;
			public CustomViewCreator(PDFXEdit.IPXV_Inst vInst, string sID, Form1 frm)
			{
				Inst = vInst;
				m_sCustomPaneID = sID;
				m_frm = frm;
			}
			public void CreateNewView(PDFXEdit.IPXV_View pParentView, PDFXEdit.IUIX_Obj pParentObj, int nViewID, string sCustomTag, ref PDFXEdit.tagRECT stPos, out PDFXEdit.IPXV_View pNewView)
			{
				pNewView = null;
				if ((pParentView == null) || (pParentObj == null) || (nViewID == 0))
					throw new System.ArgumentException();
				string sID = Inst.ID2Str(nViewID);
				if (sID.Length == 0)
					throw new System.ArgumentException();
				PDFXEdit.IPXV_DocumentView docView = pParentView as PDFXEdit.IPXV_DocumentView;
				PDFXEdit.IPXV_MainView mainView;
				if (docView == null)
					mainView = pParentView as PDFXEdit.IPXV_MainView;
				if (sID == m_sCustomPaneID)
				{
					PDFXEdit.IUIX_Inst uiInst = (PDFXEdit.IUIX_Inst)Inst.GetExtension("UIX");

					CustomView CV = new CustomView(nViewID, m_frm.userControl11);

					PDFXEdit.UIX_CreateObjParams cp = new PDFXEdit.UIX_CreateObjParams();
					cp.pImpl = CV as PDFXEdit.IUIX_ObjImpl;
					cp.pParent = pParentObj;
					cp.nCreateFlags = (int)PDFXEdit.UIX_CreateObjFlags.UIX_CreateObj_Windowed | (int)PDFXEdit.UIX_CreateObjFlags.UIX_CreateObj_TouchWindow;
					cp.pID = sID;
					cp.nStdClass = (int)PDFXEdit.UIX_StdClasses.UIX_StdClass_Blank; //For this sample we will create a Property Pane class View
					cp.nObjStyle = uiInst.MakeObjStyle((int)PDFXEdit.UIX_ObjStyleFlags.UIX_ObjStyle_NoBorder);
					cp.rc = stPos;
					// create UI-object
					PDFXEdit.IUIX_Obj newView = null;
					uiInst.CreateScrollableObj(cp, (long)PDFXEdit.UIX_ScrollStyleFlags.UIX_ScrollStyle_Vert, out newView);

					UIX_CreateObjParams cp2 = new PDFXEdit.UIX_CreateObjParams();
					cp2.nStdClass = (int)PDFXEdit.UIX_StdClasses.UIX_StdClass_Blank;
					cp2.hWndParent = CV.Obj.WndHandle;
					cp2.hWnd = Convert.ToUInt32(CV.userControl.Handle.ToInt64());
					cp2.nObjStyle = uiInst.MakeObjStyle(0, (int)PDFXEdit.UIX_ObjStyleExFlags.UIX_ObjStyleEx_SimpleWndWrapper);
					cp2.rc = stPos;
					IUIX_Obj parentBase = uiInst.CreateObj(ref cp2);

					pNewView = CV;

					//long idHwnd = Convert.ToInt64(parentBase.WndHandle);
					//long idHwnd = Convert.ToInt64(pParentView.Obj.WndHandle);
					//IntPtr ptr = new IntPtr(idHwnd);
					//long idTest = ptr.ToInt64();
					//Control cls1 = Control.FromChildHandle(ptr);
					//Control cls2 = Control.FromHandle(ptr);
				}
			}
		}

		public class CustomView : PDFXEdit.IPXV_View
		{
			int m_nID = 0;
			PDFXEdit.IUIX_Obj m_Obj = null;
			PDFXEdit.IPXV_View m_Focus = null;
			PDFXEdit.IPXV_View m_Parent = null;
			PDFXEdit.IPXV_ViewPanesCollection m_Panes = null;

			public UserControl1 userControl = null;

			public CustomView(int nID, UserControl1 userCtrl)
			{
				m_nID = nID;
				userControl = userCtrl;
			}

			public PDFXEdit.IPXV_View Focus
			{
				get { return m_Focus; }
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
				}
				else if (pEvent.Code == (int)PDFXEdit.UIX_EventCodes.e_Last)
				{
					m_Obj = null;
				}
				else if (pEvent.Code == (int)PDFXEdit.UIX_EventCodes.e_PositionChanged)
				{
					var rc = m_Obj.get_Rect();
					userControl.Left = rc.left;
					userControl.Top = rc.top;
					userControl.Width = rc.right - rc.left;
					userControl.Height = rc.bottom - rc.top;
				}
			}

			public void OnPostEvent(PDFXEdit.IUIX_Obj pSender, PDFXEdit.IUIX_Event pEvent)
			{

			}

			public void OnPreEvent(PDFXEdit.IUIX_Obj pSender, PDFXEdit.IUIX_Event pEvent)
			{

			}

			public void InsertCmdItems(INumArray pCmds, INumArray pInsertPos, int nFlags = 0, IUIX_CmdMenu pSubMenu = null)
			{
				throw new NotImplementedException();
			}

			public void InsertCmdItems2(ref int nCmdsArr, int nCmdsArrLen, ref int nInsertPosArr, int nInsertPosArrLen, int nFlags = 0, IUIX_CmdMenu pSubMenu = null)
			{
				throw new NotImplementedException();
			}

			public IUIX_CmdPane get_CmdPane(UIX_CmdPaneSides nSide)
			{
				throw new NotImplementedException();
			}

			public IUIX_CmdBar get_CmdBar(string sCmdBarID)
			{
				throw new NotImplementedException();
			}

			public IUIX_CmdBar get_CmdBar2(int nCmdBarID)
			{
				throw new NotImplementedException();
			}

			public PDFXEdit.IPXV_ViewPanesCollection Panes
			{
				get { return m_Panes; }
			}

			public PDFXEdit.IPXV_View Parent
			{
				get { return m_Parent; }
			}

			public IUIX_CmdPane CmdPaneTop
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public IUIX_CmdPane CmdPaneBottom
			{
				get
				{
					throw new NotImplementedException();
				}
			}

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
