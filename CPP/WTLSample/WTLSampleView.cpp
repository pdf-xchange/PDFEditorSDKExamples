// WTLSampleView.cpp : implementation of the CWTLSampleView class
//
/////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Ribbon.h"
#include "resource.h"

#include "WTLSampleView.h"

BOOL CWTLSampleView::PreTranslateMessage(MSG* pMsg)
{
	if((pMsg->message < WM_KEYFIRST || pMsg->message > WM_KEYLAST) &&
	   (pMsg->message < WM_MOUSEFIRST || pMsg->message > WM_MOUSELAST))
		return FALSE;

	HWND hWndCtl = ::GetFocus();
	if(IsChild(hWndCtl))
	{
		// find a direct child of the dialog from the window that has focus
		while(::GetParent(hWndCtl) != m_hWnd)
			hWndCtl = ::GetParent(hWndCtl);

		// give control a chance to translate this message
		if(::SendMessage(hWndCtl, WM_FORWARDMSG, 0, (LPARAM)pMsg) != 0)
			return TRUE;
	}

	return CWindow::IsDialogMessage(pMsg);
}

LRESULT CWTLSampleView::OnInitDialog(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	DlgResize_Init(FALSE);

	//m_ctr.
	GetDlgControl(IDC_PXV_CONTROL1, __uuidof(PXV::IPXV_Control), (void**)&m_ctr);

	HRESULT hr = S_OK;
	do
	{
		CComPtr<PXV::IPXV_Inst> pInst;
		hr = m_ctr->get_Inst(&pInst);
		if (FAILED(hr))
			break;

		CComPtr<PXV::ICabNode> pSettings;
		hr = pInst->get_Settings(&pSettings);
		if (FAILED(hr))
			break;

		hr = pSettings->SetBool(LPWSTR(_T("Docs.SingleWnd")), VARIANT_FALSE);
		if (FAILED(hr))
			break;

		hr = pSettings->SetBool(LPWSTR(_T("Docs.HideSingleTab")), VARIANT_FALSE);
		if (FAILED(hr))
			break;

		hr = pInst->FireAppPrefsChanged(PXV::PXV_AppPrefsChange_Documents, nullptr);
		if (FAILED(hr))
			break;

		hr = m_ctr->put_VisibleCmdPanes(PXV::PXV_VisibleCmdPanes_PagesView); //PXV_VisibleCmdPanes_MainView
		if (FAILED(hr))
			break;
	} while (false);
	return TRUE;
}
