// MainDlg.h : interface of the CMainDlg class
//
/////////////////////////////////////////////////////////////////////////////

#pragma once
#include "PrefInst.h"

class CMainDlg : public CAxDialogImpl<CMainDlg>, public CUpdateUI<CMainDlg>,
		public CMessageFilter, public CIdleHandler, public CTheme,
		public CDialogResize<CMainDlg>,
		public CWinDataExchange<CMainDlg>,
		public IDispEventImpl<IDC_PXV_CONTROL1, CMainDlg>
		
{
public:
	enum { IDD = IDD_MAINDLG };

	virtual BOOL PreTranslateMessage(MSG* pMsg);
	virtual BOOL OnIdle();

	CString AppDirectory();
public:
	CPrefInst m_inst;
	PXV::IPXV_ControlPtr m_pControl;
	CListViewCtrl m_ListFile;
private:
	CString m_sTextItem;
public:
	BEGIN_UPDATE_UI_MAP(CMainDlg)
	END_UPDATE_UI_MAP()

	BEGIN_MSG_MAP(CMainDlg)
		CHAIN_MSG_MAP(CAxDialogImpl<CMainDlg>)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		MESSAGE_HANDLER(WM_DESTROY, OnDestroy)

		NOTIFY_HANDLER(IDC_LIST_FILE, LVN_GETDISPINFO, OnLvnGetdispinfoListFile)
		NOTIFY_HANDLER(IDC_LIST_FILE, LVN_ODCACHEHINT, OnLvnOdcachehintListFile)

		COMMAND_ID_HANDLER(IDCANCEL, OnCancel)
		COMMAND_ID_HANDLER(IDC_BTN_ADD, OnAdd)
		COMMAND_ID_HANDLER(IDC_BTN_DELETE, OnDelete)
		COMMAND_ID_HANDLER(IDC_BTN_EDIT, OnEdit)
		COMMAND_ID_HANDLER(ID_APP_ABOUT, OnAppAbout)

		CHAIN_MSG_MAP(CDialogResize<CMainDlg>)
	END_MSG_MAP()

	BEGIN_SINK_MAP(CMainDlg)
		SINK_ENTRY(IDC_PXV_CONTROL1, 1, OnEventPxvControl1)
	END_SINK_MAP()

	BEGIN_DLGRESIZE_MAP(CMainDlg)
		DLGRESIZE_CONTROL(IDC_LIST_FILE, DLSZ_SIZE_X | DLSZ_SIZE_Y)
		DLGRESIZE_CONTROL(IDC_BTN_ADD, DLSZ_MOVE_X)
		DLGRESIZE_CONTROL(IDC_BTN_EDIT, DLSZ_MOVE_X)
		DLGRESIZE_CONTROL(IDC_BTN_DELETE, DLSZ_MOVE_X | DLSZ_MOVE_Y)
		DLGRESIZE_CONTROL(ID_APP_ABOUT, DLSZ_MOVE_X | DLSZ_MOVE_Y)
	END_DLGRESIZE_MAP()

	BEGIN_DDX_MAP(CMainDlg)
		DDX_CONTROL_HANDLE(IDC_LIST_FILE, m_ListFile)
	END_DDX_MAP()

// Handler prototypes (uncomment arguments if needed):
//	LRESULT MessageHandler(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
//	LRESULT CommandHandler(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
//	LRESULT NotifyHandler(int /*idCtrl*/, LPNMHDR /*pnmh*/, BOOL& /*bHandled*/)

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/);
	LRESULT OnDestroy(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/);
	LRESULT OnAppAbout(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/);
	LRESULT OnCancel(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/);
	LRESULT OnAdd(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/);
	LRESULT OnDelete(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/);
	LRESULT OnEdit(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/);
	LRESULT OnLvnGetdispinfoListFile(int /*idCtrl*/, LPNMHDR pNMHDR, BOOL& /*bHandled*/);
	LRESULT OnLvnOdcachehintListFile(int /*idCtrl*/, LPNMHDR pNMHDR, BOOL& /*bHandled*/);

	HRESULT __stdcall OnEventPxvControl1(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom);

	void CloseDialog(int nVal);
};
