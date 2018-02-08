// CPXV_Control.h  : Declaration of ActiveX Control wrapper class(es) created by Microsoft Visual C++

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CPXV_Control

class CPXV_Control : public CWnd
{
protected:
	DECLARE_DYNCREATE(CPXV_Control)
public:
	CLSID const& GetClsid()
	{
		static CLSID const clsid
			= { 0xA1149909, 0x4EDC, 0x4421, { 0xB9, 0xE5, 0xE9, 0x3C, 0x25, 0xA0, 0x0, 0xA1 } };
		return clsid;
	}
	virtual BOOL Create(LPCTSTR lpszClassName, LPCTSTR lpszWindowName, DWORD dwStyle,
						const RECT& rect, CWnd* pParentWnd, UINT nID, 
						CCreateContext* pContext = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID); 
	}

    BOOL Create(LPCTSTR lpszWindowName, DWORD dwStyle, const RECT& rect, CWnd* pParentWnd, 
				UINT nID, CFile* pPersist = NULL, BOOL bStorage = FALSE,
				BSTR bstrLicKey = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID,
		pPersist, bStorage, bstrLicKey); 
	}

// Attributes
public:

// Operations
public:

	CString get_Src()
	{
		CString result;
		InvokeHelper(0x64, DISPATCH_PROPERTYGET, VT_BSTR, (void*)&result, NULL);
		return result;
	}
	void put_Src(LPCTSTR newValue)
	{
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x64, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	unsigned long get_VisibleCmdPanes()
	{
		unsigned long result;
		InvokeHelper(0x65, DISPATCH_PROPERTYGET, VT_UI4, (void*)&result, NULL);
		return result;
	}
	void put_VisibleCmdPanes(unsigned long newValue)
	{
		static BYTE parms[] = VTS_UI4 ;
		InvokeHelper(0x65, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	BOOL get_VisibleScrollbars()
	{
		BOOL result;
		InvokeHelper(0x66, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void put_VisibleScrollbars(BOOL newValue)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x66, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	BOOL get_AllowedShortcuts()
	{
		BOOL result;
		InvokeHelper(0x67, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void put_AllowedShortcuts(BOOL newValue)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x67, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	BOOL get_LockedCmdBars()
	{
		BOOL result;
		InvokeHelper(0x68, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void put_LockedCmdBars(BOOL newValue)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x68, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	BOOL get_LockedCmdPanes()
	{
		BOOL result;
		InvokeHelper(0x69, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void put_LockedCmdPanes(BOOL newValue)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x69, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	LPDISPATCH get_Inst()
	{
		LPDISPATCH result;
		InvokeHelper(0x6a, DISPATCH_PROPERTYGET, VT_DISPATCH, (void*)&result, NULL);
		return result;
	}
	LPDISPATCH get_Frame()
	{
		LPDISPATCH result;
		InvokeHelper(0x6b, DISPATCH_PROPERTYGET, VT_DISPATCH, (void*)&result, NULL);
		return result;
	}
	BOOL SetLicKey(LPCTSTR sKey)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x6002000e, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, sKey);
		return result;
	}
	void ShowPane(LPCTSTR sPaneID, BOOL bShow, BOOL bHighlightOnShow)
	{
		static BYTE parms[] = VTS_BSTR VTS_BOOL VTS_BOOL ;
		InvokeHelper(0x6002000f, DISPATCH_METHOD, VT_EMPTY, NULL, parms, sPaneID, bShow, bHighlightOnShow);
	}
	void ShowPane2(long nPaneID, BOOL bShow, BOOL bHighlightOnShow)
	{
		static BYTE parms[] = VTS_I4 VTS_BOOL VTS_BOOL ;
		InvokeHelper(0x60020010, DISPATCH_METHOD, VT_EMPTY, NULL, parms, nPaneID, bShow, bHighlightOnShow);
	}
	long GetPaneVisibility(LPCTSTR sPaneID)
	{
		long result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x60020011, DISPATCH_METHOD, VT_I4, (void*)&result, parms, sPaneID);
		return result;
	}
	long GetPaneVisibility2(long nPaneID)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x60020012, DISPATCH_METHOD, VT_I4, (void*)&result, parms, nPaneID);
		return result;
	}
	LPDISPATCH get_Doc()
	{
		LPDISPATCH result;
		InvokeHelper(0x60020013, DISPATCH_PROPERTYGET, VT_DISPATCH, (void*)&result, NULL);
		return result;
	}
	BOOL get_HasDoc()
	{
		BOOL result;
		InvokeHelper(0x60020014, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void OpenDocFromPath(LPCTSTR sSrcPath, LPDISPATCH pOpenParams)
	{
		static BYTE parms[] = VTS_BSTR VTS_DISPATCH ;
		InvokeHelper(0x60020015, DISPATCH_METHOD, VT_EMPTY, NULL, parms, sSrcPath, pOpenParams);
	}
	void OpenDocFrom(LPUNKNOWN pSrc, LPDISPATCH pOpenParams)
	{
		static BYTE parms[] = VTS_UNKNOWN VTS_DISPATCH ;
		InvokeHelper(0x60020016, DISPATCH_METHOD, VT_EMPTY, NULL, parms, pSrc, pOpenParams);
	}
	void OpenDocWithDlg(LPCTSTR sInitialPath, BOOL bOnlyPDF, BOOL bNoErrorUI)
	{
		static BYTE parms[] = VTS_BSTR VTS_BOOL VTS_BOOL ;
		InvokeHelper(0x60020017, DISPATCH_METHOD, VT_EMPTY, NULL, parms, sInitialPath, bOnlyPDF, bNoErrorUI);
	}
	void CreateNewBlankDoc(double nPageWidth, double nPageHeight, long nPagesCount, long nPageRotation)
	{
		static BYTE parms[] = VTS_R8 VTS_R8 VTS_I4 VTS_I4 ;
		InvokeHelper(0x60020018, DISPATCH_METHOD, VT_EMPTY, NULL, parms, nPageWidth, nPageHeight, nPagesCount, nPageRotation);
	}
	void CreateNewBlankDoc2(LPCTSTR sPaperSize, long nPagesCount, long nPageRotation)
	{
		static BYTE parms[] = VTS_BSTR VTS_I4 VTS_I4 ;
		InvokeHelper(0x60020019, DISPATCH_METHOD, VT_EMPTY, NULL, parms, sPaperSize, nPagesCount, nPageRotation);
	}
	unsigned long get_PagesCount()
	{
		unsigned long result;
		InvokeHelper(0x6002001a, DISPATCH_PROPERTYGET, VT_UI4, (void*)&result, NULL);
		return result;
	}
	unsigned long get_CurrentPage()
	{
		unsigned long result;
		InvokeHelper(0x6002001b, DISPATCH_PROPERTYGET, VT_UI4, (void*)&result, NULL);
		return result;
	}
	void put_CurrentPage(unsigned long newValue)
	{
		static BYTE parms[] = VTS_UI4 ;
		InvokeHelper(0x6002001b, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	void GoToFirstPage()
	{
		InvokeHelper(0x6002001d, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void GoToLastPage()
	{
		InvokeHelper(0x6002001e, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void GoToPrevPage()
	{
		InvokeHelper(0x6002001f, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void GoToNextPage()
	{
		InvokeHelper(0x60020020, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	long get_PagesViewRotation()
	{
		long result;
		InvokeHelper(0x60020021, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void put_PagesViewRotation(long newValue)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x60020021, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	long get_PagesLayoutMode()
	{
		long result;
		InvokeHelper(0x60020023, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void put_PagesLayoutMode(long newValue)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x60020023, DISPATCH_PROPERTYPUT, VT_EMPTY, NULL, parms, newValue);
	}
	void SetZoom(long nMode, double nLevel, BOOL bAllowSmooth)
	{
		static BYTE parms[] = VTS_I4 VTS_R8 VTS_BOOL ;
		InvokeHelper(0x60020025, DISPATCH_METHOD, VT_EMPTY, NULL, parms, nMode, nLevel, bAllowSmooth);
	}
	void ZoomIn(BOOL bAllowSmooth)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x60020026, DISPATCH_METHOD, VT_EMPTY, NULL, parms, bAllowSmooth);
	}
	void ZoomOut(BOOL bAllowSmooth)
	{
		static BYTE parms[] = VTS_BOOL ;
		InvokeHelper(0x60020027, DISPATCH_METHOD, VT_EMPTY, NULL, parms, bAllowSmooth);
	}
	BOOL get_CanZoomIn()
	{
		BOOL result;
		InvokeHelper(0x60020028, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL get_CanZoomOut()
	{
		BOOL result;
		InvokeHelper(0x60020029, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	double get_ZoomLevel()
	{
		double result;
		InvokeHelper(0x6002002a, DISPATCH_PROPERTYGET, VT_R8, (void*)&result, NULL);
		return result;
	}
	long get_ZoomMode()
	{
		long result;
		InvokeHelper(0x6002002b, DISPATCH_PROPERTYGET, VT_I4, (void*)&result, NULL);
		return result;
	}
	void GoToDestination(PXV::PXC_Destination * stDest, unsigned long nGoDestFlags)
	{
		static BYTE parms[] = VTS_UNKNOWN VTS_UI4 ;
		InvokeHelper(0x6002002c, DISPATCH_METHOD, VT_EMPTY, NULL, parms, stDest, nGoDestFlags);
	}
	void GoToNamedDestination(LPCTSTR sDestName, unsigned long nGoDestFlags)
	{
		static BYTE parms[] = VTS_BSTR VTS_UI4 ;
		InvokeHelper(0x6002002d, DISPATCH_METHOD, VT_EMPTY, NULL, parms, sDestName, nGoDestFlags);
	}
	BOOL get_CanGoBack()
	{
		BOOL result;
		InvokeHelper(0x6002002e, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL get_CanGoForward()
	{
		BOOL result;
		InvokeHelper(0x6002002f, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void GoBack()
	{
		InvokeHelper(0x60020030, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void GoForward()
	{
		InvokeHelper(0x60020031, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	BOOL get_CanUndo()
	{
		BOOL result;
		InvokeHelper(0x60020032, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	BOOL get_CanRedo()
	{
		BOOL result;
		InvokeHelper(0x60020033, DISPATCH_PROPERTYGET, VT_BOOL, (void*)&result, NULL);
		return result;
	}
	void Undo()
	{
		InvokeHelper(0x60020034, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void Redo()
	{
		InvokeHelper(0x60020035, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	void PrintPages(unsigned long nFirst, unsigned long nCount, BOOL bUseDefOpts)
	{
		static BYTE parms[] = VTS_UI4 VTS_UI4 VTS_BOOL ;
		InvokeHelper(0x60020036, DISPATCH_METHOD, VT_EMPTY, NULL, parms, nFirst, nCount, bUseDefOpts);
	}
	void PrintWithDlg(BOOL bUseDefOpts, BOOL bSaveUserChanges)
	{
		static BYTE parms[] = VTS_BOOL VTS_BOOL ;
		InvokeHelper(0x60020037, DISPATCH_METHOD, VT_EMPTY, NULL, parms, bUseDefOpts, bSaveUserChanges);
	}
	void EnableEventListening(LPCTSTR sEventID, BOOL bEnable)
	{
		static BYTE parms[] = VTS_BSTR VTS_BOOL ;
		InvokeHelper(0x60020038, DISPATCH_METHOD, VT_EMPTY, NULL, parms, sEventID, bEnable);
	}
	void EnableEventListening2(long nEventID, BOOL bEnable)
	{
		static BYTE parms[] = VTS_I4 VTS_BOOL ;
		InvokeHelper(0x60020039, DISPATCH_METHOD, VT_EMPTY, NULL, parms, nEventID, bEnable);
	}
	BOOL IsEventListening(LPCTSTR sEventID)
	{
		BOOL result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x6002003a, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, sEventID);
		return result;
	}
	BOOL IsEventListening2(long nEventID)
	{
		BOOL result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x6002003b, DISPATCH_METHOD, VT_BOOL, (void*)&result, parms, nEventID);
		return result;
	}


};
