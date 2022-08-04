#pragma once
class CPrefInst
{
public:
	CPrefInst();
	~CPrefInst();

	t_pInst m_Inst;
	PXV::IAFS_InstPtr m_AFSInst;
	PXV::IAUX_InstPtr m_AUXInst;
	_cab_node_t m_appParams;

	long nid_e_app_prefsChanged = 0;
	long nid_e_operBeforeExecute = 0;
	long nid_op_appPrefsChanged = 0;

	CString GetText(int iItem, int iSubItem);
	int GetItemCount();
private:
	HMODULE hSDKInst = nullptr;

	PXV::ICabPtr m_pCab;
	IStreamPtr m_pStream;

	CString m_strFile;
	bool m_bAppPrefsChanged = false;
public:

	void appSettLoad(CString& strPath);

	void SettSave(LPCWSTR strFile = nullptr);
	void SettLoad(LPCWSTR strFile);
	void SettOpen();

	bool AddFileList(LPCWSTR sFilePath);
	bool DelFileList(LPCWSTR sFilePath);
	bool DeleteItem(int nIndex);

	HRESULT OnEventPxvControl(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom);
};

