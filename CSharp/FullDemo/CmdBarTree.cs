using PDFXEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullDemo
{
	class ToolbarInfo 
	{
		virtual public bool IsGroup() { return m_bIsGroup; }
		virtual public bool IsTab() { return m_bIsTab; }
		virtual public bool IsSpecial() { return m_bSpecial; }
		virtual public bool IsDoc() { return m_bDoc; }

		public int m_nID = 0;
		public int m_nTabID = 0;
		public string m_sTitle;
		public bool m_bHidden = false;
		public bool m_bVisible = true; // includes parent's state
		public bool m_bStd = false;
		public bool m_bSpecial = false;
		public bool m_bTemp = false;
		public bool m_bDoc = false;
		public bool m_bIsGroup = false;
		public bool m_bIsTab = false;
		public List<ToolbarInfo> m_Bars = new List<ToolbarInfo>();
	};

	enum eGI
	{
		Group_MainTabs,
		Group_MainBars,
		Group_DocBars,
		//
		Group_Max,
	};

	class ItemID
	{
		public int v0 = 0;
		public int v1 = 0;
		public bool IsValid() { return (v0 != 0); }
		public void Clear() { v0 = v1 = 0; }
	};

class CmdBarTree
	{
		public IPXV_Inst m_Inst = null;
		public IUIX_Inst m_uiInst = null;
		public MyTreeView m_Tree;
		public List<ToolbarInfo> m_MainTabs = new List<ToolbarInfo>();
		public List<ToolbarInfo> m_MainBars = new List<ToolbarInfo>();
		public List<ToolbarInfo> m_DocBars = new List<ToolbarInfo>();
		ToolbarInfo[] m_Groups = new ToolbarInfo[(int)eGI.Group_Max];
		bool m_bRibbonUI = false;
		int m_nActiveTabID = 0;
		bool m_bEnabled = true;

		public CmdBarTree(IPXV_Inst Inst, ref MyTreeView Tree)
		{
			m_Inst = Inst;
			m_uiInst = (IUIX_Inst)Inst.GetExtension("UIX");
			m_Tree = Tree;
		}
		
		public void Load()
		{
			m_Tree.Nodes.Clear();
			m_bEnabled = m_uiInst.get_CmdManager().LockedToolbars;
			CollectAllTabsAndBars();
			IPXV_MainView MainView = m_Inst.ActiveMainView;
			m_nActiveTabID = 0;

			if (m_bRibbonUI)
			{
				if (MainView != null)
				{
					IUIX_CmdPane ICPane = MainView.CmdPaneTop;
					IUIX_CmdRibbonTabs Tabs = ICPane.Tabs;
					IUIX_CmdRibbonTab Tab = Tabs.Active;
					if (Tab != null)
						m_nActiveTabID = Tab.ID;
				}
			}

			{
				ToolbarInfo groupInfo = new ToolbarInfo();
				groupInfo.m_bIsGroup = true;
				groupInfo.m_nID = m_Inst.Str2ID("cmdBars.mainTabs", false);
				groupInfo.m_sTitle = m_Inst.GetLocalStr2(groupInfo.m_nID);
				m_Groups[(int)eGI.Group_MainTabs] = groupInfo;
			}
			{
				ToolbarInfo groupInfo = new ToolbarInfo();
				groupInfo.m_bIsGroup = true;
				groupInfo.m_nID = m_Inst.Str2ID(m_bRibbonUI ? "cmdBars.main2" : "cmdBars.main", false);
				groupInfo.m_sTitle = m_Inst.GetLocalStr2(groupInfo.m_nID);
				m_Groups[(int)eGI.Group_MainBars] = groupInfo;
			}
			{
				ToolbarInfo groupInfo = new ToolbarInfo();
				groupInfo.m_bIsGroup = true;
				groupInfo.m_nID = m_Inst.Str2ID("cmdBars.doc", false);
				groupInfo.m_sTitle = m_Inst.GetLocalStr2(groupInfo.m_nID);
				m_Groups[(int)eGI.Group_DocBars] = groupInfo;
			}

			if (m_bRibbonUI)
			{
				ToolbarInfo groupInfo = m_Groups[(int)eGI.Group_MainTabs];
				TreeNode TabsItem = m_Tree.Nodes.Add(groupInfo.m_nID.ToString(), groupInfo.m_sTitle);
				TabsItem.Tag = groupInfo;
				TabsItem.Expand();
				if (TabsItem != null)
				{
					foreach (ToolbarInfo Tab in m_MainTabs)
					{
						TreeNode TabItem = TabsItem.Nodes.Add(Tab.m_nID.ToString(), Tab.m_sTitle);
						TabItem.Tag = Tab;
						TabItem.Checked = Tab.m_bVisible;
						foreach (ToolbarInfo Bar in Tab.m_Bars)
						{
							TreeNode BarItem = TabItem.Nodes.Add(Bar.m_nID.ToString(), Bar.m_sTitle);
							BarItem.Tag = Bar;
							BarItem.Checked = Bar.m_bVisible;
						}

					}
				}
			}

			if (m_MainBars.Count > 0)
			{
				ToolbarInfo groupInfo = m_Groups[(int)eGI.Group_MainBars];
				TreeNode BarsItem = m_Tree.Nodes.Add(groupInfo.m_nID.ToString(), groupInfo.m_sTitle);
				BarsItem.Tag = groupInfo;
				BarsItem.Expand();

				foreach (ToolbarInfo Bar in m_MainBars)
				{
					TreeNode BarItem = BarsItem.Nodes.Add(Bar.m_nID.ToString(), Bar.m_sTitle);
					BarItem.Tag = Bar;
					BarItem.Checked = Bar.m_bVisible;
				}
			}

			if (m_DocBars.Count > 0)
			{
				ToolbarInfo groupInfo = m_Groups[(int)eGI.Group_DocBars];
				TreeNode BarsItem = m_Tree.Nodes.Add(groupInfo.m_nID.ToString(), groupInfo.m_sTitle);
				BarsItem.Tag = groupInfo;
				BarsItem.Expand();

				foreach (ToolbarInfo Bar in m_DocBars)
				{
					TreeNode BarItem = BarsItem.Nodes.Add(Bar.m_nID.ToString(), Bar.m_sTitle);
					BarItem.Tag = Bar;
					BarItem.Checked = Bar.m_bVisible;
				}
			}
		}

		public bool RemoveAllPrefixes(string StrIn, out string sStrOut, out int nLastPrefix)
		{
			nLastPrefix = -1;
			sStrOut = "";
			int nLen = StrIn.Length;
			if (nLen == 0)
			{
				return false;
			}
			else if (nLen == 1)
			{
				if (StrIn[0] == '&')
					return false;
			}

			StringBuilder strBuilder = new StringBuilder(nLen);
			strBuilder.Length = nLen;

			// &aaa&bbb&&&ccc& bbb&
			int j = 0;
			int i = 0;
			while (i < nLen)
			{
				char c = StrIn[i];
				if (c != '&')
				{

					strBuilder[j++] = c;
					i++;
					continue;
				}
				if (i + 1 == nLen)
					break;
				char cNext = StrIn[i + 1];
				switch (cNext)
				{
				case '&':
					strBuilder[j++] = c;
					i++;
					break;
				case ' ':
				case '\t':
				case '\r':
				case '\n':
					strBuilder[j++] = c;
					break;
				default:
					nLastPrefix = j;
					break;
				}
				i++;
			}

			strBuilder.Length = j;
			sStrOut = strBuilder.ToString();

			return (j < nLen);
		}

		public bool CreateNewToolbarInfo(IUIX_CmdBar Bar, out ToolbarInfo BarInfo)
		{
			BarInfo = null;
			if (Bar == null)
				return false;

			BarInfo = new ToolbarInfo();
			if (BarInfo == null)
				return false;

			BarInfo.m_nID = Bar.ID;
			int n = 0;
			string sTitle = Bar.Title;
			if (sTitle.Length == 0)
				sTitle = m_Inst.GetLocalStr2(Bar.ID);
			RemoveAllPrefixes(sTitle, out BarInfo.m_sTitle, out n);
			
			BarInfo.m_bStd = m_uiInst.get_CmdManager().IsStdBar(BarInfo.m_nID);
			BarInfo.m_bHidden = Bar.IsHidden || ((Bar.Line != null) && (Bar.Line.Pane != null) && Bar.Line.Pane.IsHidden);
			BarInfo.m_bVisible = !BarInfo.m_bHidden;
			BarInfo.m_bSpecial = Bar.IsSpecial;
			BarInfo.m_bTemp = Bar.IsTemp;


			return true;
		}

		public void CollectAllTabsAndBars()
		{
			m_MainTabs.Clear();
			m_MainBars.Clear();
			m_DocBars.Clear();
			m_bRibbonUI = false;

			IUIX_CmdManager CMan = m_uiInst.get_CmdManager();
			IPXV_MainView MainView = m_Inst.ActiveMainView;

			IUIX_CmdPane ICPane = MainView.CmdPaneTop;
			IUIX_CmdRibbonTabs Tabs = ICPane.Tabs;
			m_bRibbonUI = ICPane.IsRibbonMode;

			List<IUIX_CmdBar> mainBars = new List<IUIX_CmdBar>();
			//Getting all command bars for MainView
			for (uint i = 0; i < CMan.CmdBarsCount; i++)
			{
				IUIX_CmdBar Bar = CMan.CmdBar[(int)i];
				if ((Bar.Owner != MainView.Obj) || Bar.IsPopupBox || Bar.IsPopupMenu || Bar.IsSpecial || (Bar.AppMenuContainer != null))
					continue;
				mainBars.Add(Bar);
			}

			if (ICPane.QABar != null)
				mainBars.Add(ICPane.QABar);
			if (ICPane.QLBar != null)
				mainBars.Add(ICPane.QLBar);

			List<IUIX_CmdBar> docBars = new List<IUIX_CmdBar>();
			IPXV_DocumentView DocView = m_Inst.ActiveDocView;
			if (DocView != null)
			{
				IUIX_Layout layout = DocView.Panes.Layout;

				IPXV_PagesView PagesView = DocView.PagesView;

				HashSet<IUIX_Obj> cmdOwners = new HashSet<IUIX_Obj>();
				if (PagesView != null)
					cmdOwners.Add(PagesView.Obj);

				List<IUIX_CmdBar> viewBars = new List<IUIX_CmdBar>();
				foreach (IUIX_Obj obj in cmdOwners )
				{
					viewBars.Clear();

					//Getting all command bars 
					for (uint j = 0; j < CMan.CmdBarsCount; j++)
					{
						IUIX_CmdBar Bar = CMan.CmdBar[(int)j];
						if ((Bar.Owner != obj) || Bar.IsPopupBox || Bar.IsPopupMenu || Bar.IsSpecial || (Bar.AppMenuContainer != null))
							continue;
						viewBars.Add(Bar);
					}

					if (viewBars.Count > 0)
						docBars.InsertRange(docBars.Count, viewBars);
				}
			}

			Dictionary<IUIX_CmdBar, ToolbarInfo> bars = new Dictionary<IUIX_CmdBar, ToolbarInfo>();

			if (m_bRibbonUI)
			{
				if (Tabs != null)
				{

					for (uint i = 0; i < Tabs.Count; i++)
					{
						IUIX_CmdRibbonTab Tab = Tabs[i];

						if (Tab.ContextualGroupID != 0)
							continue;

						ToolbarInfo TI = new ToolbarInfo();

						TI.m_bIsTab = true;
						TI.m_nID = Tab.ID;
						string title = Tab.Title;

						int n = 0;
						RemoveAllPrefixes(title, out TI.m_sTitle, out n);
						TI.m_bStd = CMan.IsStdRibbonTab(TI.m_nID);
						TI.m_bHidden = Tab.Hidden || ICPane.IsHidden;
						TI.m_bVisible = !TI.m_bHidden;
						TI.m_bTemp = Tab.IsTemp;

						m_MainTabs.Add(TI);

						for (uint j = 0; j < Tab.Count; j++)
						{
							IUIX_CmdBar bar = Tab[j];

							ToolbarInfo BarInfo;
							if (!CreateNewToolbarInfo(bar, out BarInfo))
								break;

							BarInfo.m_bHidden = BarInfo.m_bHidden || Tab.IsBarHidden[(int)j] || ((bar.Line != null) && (bar.Line.Pane != null) && bar.Line.Pane.IsHidden);
							BarInfo.m_bVisible = !BarInfo.m_bHidden && TI.m_bVisible;

							ToolbarInfo it = null;
							if (!bars.TryGetValue(bar, out it))
								bars.Add(bar, BarInfo);

							BarInfo.m_nTabID = TI.m_nID;
							TI.m_Bars.Add(BarInfo);
						}
					}
				}
			}
			// check for other bars
			foreach (IUIX_CmdBar Bar in mainBars)
			{
				ToolbarInfo it = null;
				if (bars.TryGetValue(Bar, out it))
					continue;

				if (Tabs != null)
				{
					if (Tabs.IsContextualBar(Bar.ID))
						continue;
				}

				ToolbarInfo BarInfo;
				if (!CreateNewToolbarInfo(Bar, out BarInfo))
					break;

				bars.Add(Bar, BarInfo);

				m_MainBars.Add(BarInfo);
			}

			m_MainBars.Sort((a, b) => (a.m_sTitle.CompareTo(b.m_sTitle)));

			bars.Clear();

			HashSet<int> addedBars = new HashSet<int>();
			foreach (IUIX_CmdBar Bar in docBars)
			{
				int nBarID = Bar.ID;
				if (addedBars.Contains(nBarID))
					continue;

				addedBars.Add(nBarID);

				ToolbarInfo BarInfo;
				if (!CreateNewToolbarInfo(Bar, out BarInfo))
					break;

				BarInfo.m_bDoc = true;

				m_DocBars.Add(BarInfo);
			}

			m_DocBars.Sort((a, b) => (a.m_sTitle.CompareTo(b.m_sTitle)));
		}
	}

	
}
