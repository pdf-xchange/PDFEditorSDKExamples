// MainDlg.cpp : implementation of the CMainDlg class
//
/////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "resource.h"

#include "aboutdlg.h"
#include "MainDlg.h"

BOOL CMainDlg::PreTranslateMessage(MSG* pMsg)
{
	return CWindow::IsDialogMessage(pMsg);
}

BOOL CMainDlg::OnIdle()
{
	UIUpdateChildWindows();
	return FALSE;
}

CString CMainDlg::AppDirectory()
{
	WCHAR szPath[_MAX_PATH] = { 0 };
	::GetModuleFileName(_Module.m_hInst, szPath, _MAX_PATH);
	WCHAR szPathCanon[_MAX_PATH] = { 0 };
	PathCanonicalize(szPathCanon, szPath);
	PathRemoveFileSpec(szPathCanon);
	PathAddBackslash(szPathCanon);
	return {szPathCanon};
}

LRESULT CMainDlg::OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
{
	// center the dialog on the screen
	CenterWindow();
	DoDataExchange(FALSE);
	// set icons
	HICON hIcon = AtlLoadIconImage(IDR_MAINFRAME, LR_DEFAULTCOLOR, ::GetSystemMetrics(SM_CXICON), ::GetSystemMetrics(SM_CYICON));
	SetIcon(hIcon, TRUE);
	HICON hIconSmall = AtlLoadIconImage(IDR_MAINFRAME, LR_DEFAULTCOLOR, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON));
	SetIcon(hIconSmall, FALSE);

	GetDlgControl(IDC_PXV_CONTROL1, __uuidof(PXV::IPXV_Control), (void**)&m_pControl);
	m_pControl->EnableEventListening2(m_inst.nid_e_app_prefsChanged, VARIANT_TRUE);
	m_pControl->EnableEventListening2(m_inst.nid_e_operBeforeExecute, VARIANT_TRUE);

	// register object for message filtering and idle updates
	CMessageLoop* pLoop = _Module.GetMessageLoop();
	ATLASSERT(pLoop != nullptr);
	pLoop->AddMessageFilter(this);
	pLoop->AddIdleHandler(this);

	UIAddChildWindowContainer(m_hWnd);

	if (IsThemingSupported())
		SetWindowTheme(m_ListFile, L"Explorer", nullptr);

	m_ListFile.SetExtendedListViewStyle(LVS_EX_DOUBLEBUFFER, LVS_EX_DOUBLEBUFFER);
	m_ListFile.SetExtendedListViewStyle(LVS_EX_FULLROWSELECT, LVS_EX_FULLROWSELECT);
	m_ListFile.SetExtendedListViewStyle(LVS_EX_AUTOSIZECOLUMNS, LVS_EX_AUTOSIZECOLUMNS);
	m_ListFile.InsertColumn(0, L"Path File", 0, 2500);

	CString strFile;
	strFile = AppDirectory();
	strFile.Append(L"PDFXeditPref.dat");
	m_inst.appSettLoad(strFile);

	m_ListFile.SetItemCount(m_inst.GetItemCount());
	DlgResize_Init();
	return TRUE;
}

LRESULT CMainDlg::OnDestroy(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
{
	// unregister message filtering and idle updates
	CMessageLoop* pLoop = _Module.GetMessageLoop();
	ATLASSERT(pLoop != nullptr);
	pLoop->RemoveMessageFilter(this);
	pLoop->RemoveIdleHandler(this);
	return 0;
}

LRESULT CMainDlg::OnAppAbout(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	CAboutDlg dlg;
	dlg.DoModal();
	return 0;
}

LRESULT CMainDlg::OnAdd(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	const int nfileTypesCount = 2;
	const COMDLG_FILTERSPEC fileTypes[nfileTypesCount] =
	{
		{ L"PDF-XChange Editor Settings (*.xces)", L"*.xces;*.xcs" },
		{ L"All Files (*.*)", L"*.*" }
	};
	WTL::CShellFileOpenDialog dlg1(nullptr, FOS_FORCEFILESYSTEM | FOS_PATHMUSTEXIST | FOS_FILEMUSTEXIST | FOS_ALLOWMULTISELECT, L"xces", fileTypes, nfileTypesCount);
	if (dlg1.DoModal() == IDOK)
	{
		ATL::CComPtr<IShellItemArray> spItemArr;
		HRESULT hRet = dlg1.GetPtr()->GetResults(&spItemArr);
		DWORD nCount = 0;
		spItemArr->GetCount(&nCount);
		for (DWORD i = 0; i < nCount; i++)
		{
			ATL::CComPtr<IShellItem> spItem;
			spItemArr->GetItemAt(i, &spItem);
			CString strFilePath;
			dlg1.GetFileNameFromShellItem(spItem, SIGDN_FILESYSPATH, strFilePath);
			if (m_inst.AddFileList(strFilePath))
				m_ListFile.AddItem(0, 0, strFilePath);
		}
	}
	return 0;
}

LRESULT CMainDlg::OnDelete(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	int nIndex = -1;
	do
	{
		nIndex = m_ListFile.GetNextItem(nIndex, LVNI_SELECTED);
		if (m_inst.DeleteItem(nIndex))
			m_ListFile.DeleteItem(nIndex);
	} while (nIndex >= 0);
	return 0;
}

LRESULT CMainDlg::OnEdit(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	int nIndex = m_ListFile.GetNextItem(-1, LVNI_FOCUSED);
	if (nIndex >= 0)
	{
		CString strPath;
		m_ListFile.GetItemText(nIndex, 0, strPath);
		{
			WTL::CWaitCursor cr;
			m_inst.SettLoad(strPath);
		}
		m_inst.SettOpen();
	}
	return 0;
}

LRESULT CMainDlg::OnCancel(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	CloseDialog(wID);
	return 0;
}

void CMainDlg::CloseDialog(int nVal)
{
	DestroyWindow();
	::PostQuitMessage(nVal);
}

LRESULT CMainDlg::OnLvnGetdispinfoListFile(int /*idCtrl*/, LPNMHDR pNMHDR, BOOL& /*bHandled*/)
{
	NMLVDISPINFOW* pDispInfo = reinterpret_cast<NMLVDISPINFO*>(pNMHDR);
	// TODO: Add your control notification handler code here
	auto& item = pDispInfo->item;
	if (item.mask & LVIF_TEXT)
	{
		m_sTextItem = m_inst.GetText(item.iItem, item.iSubItem);
		item.pszText = m_sTextItem.GetBuffer();
	}
	return 0;
}


LRESULT CMainDlg::OnLvnOdcachehintListFile(int /*idCtrl*/, LPNMHDR pNMHDR, BOOL& /*bHandled*/)
{
	LPNMLVCACHEHINT pCacheHint = reinterpret_cast<LPNMLVCACHEHINT>(pNMHDR);
	// TODO: Add your control notification handler code here
	return 0;
}

HRESULT __stdcall CMainDlg::OnEventPxvControl1(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom)
{
	return m_inst.OnEventPxvControl(nEventID, pEvent, pFrom);
}
