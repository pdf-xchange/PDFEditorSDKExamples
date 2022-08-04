// MainFrm.cpp : implmentation of the CMainFrame class
//
/////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Ribbon.h"
#include "resource.h"

#include "aboutdlg.h"
#include "WTLSampleView.h"
#include "MainFrm.h"
#include <atltypes.h>

BOOL CMainFrame::PreTranslateMessage(MSG* pMsg)
{
	if(CRibbonFrameWindowImpl<CMainFrame>::PreTranslateMessage(pMsg))
		return TRUE;

	return m_view.PreTranslateMessage(pMsg);
}

BOOL CMainFrame::OnIdle()
{
	UIUpdateToolBar();
	return FALSE;
}

// void CMainFrame::UpdateLayout(BOOL bResizeBars /*= TRUE*/)
// {
// 	{
// 		CRect rectWnd, rectTool;
// 		GetClientRect(rectWnd);
// 
// // 		// resize title bar
// // 		if (m_view.m_TitleBar.IsWindow() && (m_view.m_TitleBar.GetStyle() & WS_VISIBLE))
// // 		{
// // 			if (bResizeBars)
// // 				m_view.m_TitleBar.SendMessage(WM_SIZE);
// // 			m_view.m_TitleBar.GetWindowRect(rectTool);
// // 			rectWnd.top += rectTool.Size().cy;
// // 		}
// 
// 		// resize view
// 		if (m_view.IsWindow())
// 		{
// 			m_view.GetWindowRect(rectTool);
// 			if (rectTool != rectWnd)
// 				m_view.SetWindowPos(NULL, rectWnd, SWP_NOZORDER | SWP_NOACTIVATE);
// 		}
// 	}
// }

LRESULT CMainFrame::OnCreate(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
{
	g_Inst.CoCreateInstance(__uuidof(PXV::PXV_Inst));
	g_Inst->Init(nullptr, L"", nullptr, nullptr, nullptr, 0, nullptr);
	CComPtr<PXV::ICabNode> pNode;
	g_Inst->get_Settings(&pNode);
	pNode;

	bool bRibbonUI = RunTimeHelper::IsRibbonUIAvailable();
	if (bRibbonUI)
		UIAddMenu(GetMenu(), true);
	else
		CMenuHandle(GetMenu()).DeleteMenu(ID_VIEW_RIBBON, MF_BYCOMMAND);
	bRibbonUI = false;

	// create command bar window
	HWND hWndCmdBar = m_CmdBar.Create(m_hWnd, rcDefault, NULL, ATL_SIMPLE_CMDBAR_PANE_STYLE);
	// attach menu
	m_CmdBar.AttachMenu(GetMenu());
	// load command bar images
	m_CmdBar.LoadImages(IDR_MAINFRAME);
	// remove old menu
	SetMenu(NULL);

	HWND hWndToolBar = CreateSimpleToolBarCtrl(m_hWnd, IDR_MAINFRAME, FALSE, ATL_SIMPLE_TOOLBAR_PANE_STYLE);

	CreateSimpleReBar(ATL_SIMPLE_REBAR_NOBORDER_STYLE);
	AddSimpleReBarBand(hWndCmdBar);
	AddSimpleReBarBand(hWndToolBar, NULL, TRUE);

	CreateSimpleStatusBar();

	m_hWndClient = m_view.Create(m_hWnd);

	UIAddToolBar(hWndToolBar);
	UISetCheck(ID_VIEW_TOOLBAR, 1);
	UISetCheck(ID_VIEW_STATUS_BAR, 1);

	// register object for message filtering and idle updates
	CMessageLoop* pLoop = _Module.GetMessageLoop();
	ATLASSERT(pLoop != NULL);
	pLoop->AddMessageFilter(this);
	pLoop->AddIdleHandler(this);

	ShowRibbonUI(bRibbonUI);
	UISetCheck(ID_VIEW_RIBBON, bRibbonUI);

	return 0;
}

LRESULT CMainFrame::OnClose(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled)
{
	bHandled = FALSE;
	m_EventTarget = nullptr;
	return 1;
}

LRESULT CMainFrame::OnDestroy(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled)
{
	g_Inst->Shutdown(0);

	// unregister message filtering and idle updates
	CMessageLoop* pLoop = _Module.GetMessageLoop();
	ATLASSERT(pLoop != NULL);
	pLoop->RemoveMessageFilter(this);
	pLoop->RemoveIdleHandler(this);

	bHandled = FALSE;
	return 1;
}

LRESULT CMainFrame::OnFileExit(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	PostMessage(WM_CLOSE);
	return 0;
}

LRESULT CMainFrame::OnFileNew(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	// TODO: add code to initialize document
	CShellFileOpenDialog dlg;

	return 0;
}

LRESULT CMainFrame::OnFileOpen(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	COMDLG_FILTERSPEC filterSpecs[] =
	{

		{ _T("PDF documents(*.pdf)"),_T("*.pdf") },
		{ _T("All documents(*.*)"),_T("*.*") }
	};
	CShellFileOpenDialog fileOpenDlg(
		NULL,
		FOS_FORCEFILESYSTEM | FOS_FILEMUSTEXIST | FOS_PATHMUSTEXIST,
		_T("pdf"),
		filterSpecs,
		_countof(filterSpecs));
	if (fileOpenDlg.DoModal(m_hWnd) == IDOK)
	{
		CString filePath;
		fileOpenDlg.GetFilePath(filePath);
		CComBSTR str(filePath);
		m_view.m_ctr->OpenDocFromPath(str, nullptr);
	}
	return 0L;
}

LRESULT CMainFrame::OnViewToolBar(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	static BOOL bVisible = TRUE;	// initially visible
	bVisible = !bVisible;
	CReBarCtrl rebar = m_hWndToolBar;
	int nBandIndex = rebar.IdToIndex(ATL_IDW_BAND_FIRST + 1);	// toolbar is 2nd added band
	rebar.ShowBand(nBandIndex, bVisible);
	UISetCheck(ID_VIEW_TOOLBAR, bVisible);
	UpdateLayout();
	return 0;
}

LRESULT CMainFrame::OnViewStatusBar(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	BOOL bVisible = !::IsWindowVisible(m_hWndStatusBar);
	::ShowWindow(m_hWndStatusBar, bVisible ? SW_SHOWNOACTIVATE : SW_HIDE);
	UISetCheck(ID_VIEW_STATUS_BAR, bVisible);
	UpdateLayout();
	return 0;
}

LRESULT CMainFrame::OnViewRibbon(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	ShowRibbonUI(!IsRibbonUI());
	UISetCheck(ID_VIEW_RIBBON, IsRibbonUI());
	return 0;
}

LRESULT CMainFrame::OnAppAbout(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	CAboutDlg dlg;
	dlg.DoModal();
	return 0;
}

LRESULT CMainFrame::OnCommandTisableclose(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	HRESULT hr = S_OK;
	do
	{
// 		CComPtr<PXV::IPXV_Inst> pInst;
// 		hr = m_ctr->get_Inst(&pInst);
// 		if (FAILED(hr))
// 			break;
		CComPtr<PXV::IPXV_MainFrame> pFrame;
		//hr = pInst->get_ActiveMainFrm(&pFrame);
		hr = g_Inst->get_ActiveMainFrm(&pFrame);
		if (FAILED(hr))
			break;
		CComPtr<PXV::IPXV_MainView> pView;
		hr = pFrame->get_View(&pView);
		if (FAILED(hr))
			break;
		CComPtr<PXV::IPXV_DocumentViewsArea> pViewArea;
		hr = pView->get_DocViewsArea(&pViewArea);
		if (FAILED(hr))
			break;
		CComPtr<PXV::IUIX_Obj> pObj;
		hr = pViewArea->get_Obj(&pObj);
		if (FAILED(hr))
			break;

		CComObject<CCustomEventTarget>* pCircle;
		hr = CComObject<CCustomEventTarget>::CreateInstance(&pCircle);
		ATLASSERT(SUCCEEDED(hr));
		pCircle->SetObj(pObj);
		// Increment reference count immediately

		m_EventTarget = pCircle;
	} while (false);

	return 0;
}
