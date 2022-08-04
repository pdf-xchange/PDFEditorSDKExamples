// WTLSampleView.h : interface of the CWTLSampleView class
//
/////////////////////////////////////////////////////////////////////////////

#pragma once

class CWTLSampleView : public CAxDialogImpl<CWTLSampleView>, public CDialogResize<CWTLSampleView>
{
public:
	enum { IDD = IDD_WTLSAMPLE_FORM };

	BOOL PreTranslateMessage(MSG* pMsg);

	PXV::IPXV_ControlPtr m_ctr;

	BEGIN_DLGRESIZE_MAP(CWTLSampleView)
		DLGRESIZE_CONTROL(IDC_PXV_CONTROL1, DLSZ_SIZE_X | DLSZ_SIZE_Y)
	END_DLGRESIZE_MAP()

	BEGIN_MSG_MAP(CWTLSampleView)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		CHAIN_MSG_MAP(CDialogResize<CWTLSampleView>)
	END_MSG_MAP()


	LRESULT OnInitDialog(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);

// Handler prototypes (uncomment arguments if needed):
//	LRESULT MessageHandler(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
//	LRESULT CommandHandler(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
//	LRESULT NotifyHandler(int /*idCtrl*/, LPNMHDR /*pnmh*/, BOOL& /*bHandled*/)
};
