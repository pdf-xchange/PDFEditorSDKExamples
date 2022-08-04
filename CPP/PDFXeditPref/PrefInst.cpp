#include "stdafx.h"
#include "PrefInst.h"
#include "resource.h"

CPrefInst::CPrefInst()
{
	CString strMainFrame;
	strMainFrame.LoadStringW(IDR_MAINFRAME);

/**/
	m_Inst.CoCreateInstance(__uuidof(PXV::PXV_Inst));
/*/
	hSDKInst = LoadLibrary(SDK_DLL);
	if (hSDKInst == nullptr)
	{
		WCHAR path[MAX_PATH + 1] = { 0 };
		ExpandEnvironmentStrings(SDK_PATH, path, _countof(path));
		lstrcat(path, L"\\");
		lstrcat(path, SDK_DLL);
		hSDKInst = LoadLibrary(path);
	}
	if (!hSDKInst)
	{
		MessageBox(::GetActiveWindow(), L"Invalid SDK DLL", strMainFrame, 0);
		return;
	}
	fnPXC_GetInstance pfn = (fnPXC_GetInstance)GetProcAddress(hSDKInst, "PXV_GetInstance");
	if (!pfn)
	{
		MessageBox(::GetActiveWindow(), L"Invalid SDK DLL - function PXV_GetInstance not found", strMainFrame, 0);
		return;
	}
	if (FAILED(pfn(&m_Inst)))
	{
		MessageBox(::GetActiveWindow(), L"Invalid SDK DLL - function PXV_GetInstance not found", strMainFrame, 0);
		return;
	}
/**/

	m_Inst->Init(nullptr, CComBSTR(L""), nullptr, nullptr, nullptr, 0, nullptr);

	m_Inst->Str2ID(CComBSTR(L"e.app.prefsChanged"), FALSE, &nid_e_app_prefsChanged);
	m_Inst->Str2ID(CComBSTR(L"e.operBeforeExecute"), FALSE, &nid_e_operBeforeExecute);
	m_Inst->Str2ID(CComBSTR(L"e.operBeforeExecute"), FALSE, &nid_op_appPrefsChanged);

	//pMain->EnableEventListening2();

	IUnknownPtr pEx;
	m_Inst->GetExtension(CComBSTR(L"AFS"), &pEx);
	pEx->QueryInterface(&m_AFSInst);
	pEx = nullptr;

	m_Inst->GetExtension(CComBSTR(L"AUX"), &pEx);
	pEx->QueryInterface(&m_AUXInst);
}


CPrefInst::~CPrefInst()
{
	if (m_pCab != nullptr)
		m_pCab->Save(m_pStream);
	if (m_Inst)
		m_Inst->Shutdown(0);

	if (hSDKInst != nullptr)
		FreeLibrary(hSDKInst);
}


CString CPrefInst::GetText(int iItem, int iSubItem)
{
	_cab_node_t filelist = m_appParams[L"FileList"];
	if (iItem >= filelist.size())
		return {};
	return { (LPCWSTR)filelist.at(iItem) };
}

int CPrefInst::GetItemCount()
{
	_cab_node_t filelist = m_appParams[L"FileList"];
	return filelist.size();
}

bool CPrefInst::AddFileList(LPCWSTR sFilePath)
{
	_cab_node_t filelist = m_appParams[L"FileList"];
	for (int i = 0; i < filelist.size(); i++)
	{
		CString str = (LPCWSTR)filelist.at(i);
		if (str.Compare(sFilePath) == 0)
			return false;
	}
	m_appParams[L"FileList"].Insert(PXV::dt_String) = sFilePath;
	return true;
}

bool CPrefInst::DelFileList(LPCWSTR sFilePath)
{
	_cab_node_t filelist = m_appParams[L"FileList"];
	for (int i = 0; i < filelist.size(); i++)
	{
		CString str = (LPCWSTR)filelist.at(i);
		if (str.Compare(sFilePath) == 0)
		{
			filelist.Remove(i);
			return true;
		}
	}
	return false;
}

bool CPrefInst::DeleteItem(int nIndex)
{
	_cab_node_t filelist = m_appParams[L"FileList"];
	if (nIndex >= filelist.size())
		return false;

	filelist.Remove(nIndex);
	return true;
}

void CPrefInst::appSettLoad(CString& strPath)
{
	PXV::IAFS_FileSysPtr pFs;
	m_AFSInst->get_DefaultFileSys(&pFs);
	PXV::IAFS_NamePtr pName;
	pFs->StringToName(strPath.GetBuffer(), 0, nullptr, &pName);

	PXV::IAFS_FilePtr pFile;
	pFs->OpenFile(pName, PXV::AFS_OpenFile_OpenAlways | PXV::AFS_OpenFile_Write, nullptr, nullptr, &pFile);
	pFile->GetStream(&m_pStream);

	m_AUXInst->CreateEmptyCab(&m_pCab);
	m_pCab->Load(m_pStream, VARIANT_TRUE);

	m_appParams = _cab_node_t(m_pCab);
	_cab_node_t filelist = m_appParams[L"FileList"];
	if (!filelist.IsArray())
		m_appParams.Insert(L"FileList", PXV::dt_Array);
}

void CPrefInst::SettSave(LPCWSTR strFile)
{
	if (!m_Inst)
		return;

	CString strPath = m_strFile;
	if (strFile != nullptr)
		strPath = strPath;
	HRESULT hr = 0;
	do
	{
		long nID = 0;
		hr = m_Inst->Str2ID(CComBSTR(L"op.settings.export"), FALSE, &nID);
		BreakOnFailure0(hr);
		PXV::IOperationPtr op;
		hr = m_Inst->CreateOp(nID, &op);
		BreakOnFailure0(hr);
		PXV::ICabPtr rootNode;
		op->get_Params(&rootNode);
		_cab_node_t rootParams(rootNode);
		rootParams[L"Options.History"] = false;
		PXV::IAFS_FileSysPtr pFs;
		m_AFSInst->get_DefaultFileSys(&pFs);
		PXV::IAFS_NamePtr pName;
		pFs->StringToName(strPath.GetBuffer(), 0, nullptr, &pName);
		rootParams[L"Input"] = (IUnknown*)pName;
		hr = op->Do(0);
		BreakOnFailure0(hr);
	} while (false);
	ATLASSERT(hr == S_OK);
}

void CPrefInst::SettLoad(LPCWSTR strFile)
{
	if (!m_Inst)
		return;

	m_strFile = strFile;
	HRESULT hr = 0;
	do
	{
		long nID = 0;
		hr = m_Inst->Str2ID(CComBSTR(L"op.settings.import"), FALSE, &nID);
		BreakOnFailure0(hr);
		PXV::IOperationPtr op;
		hr = m_Inst->CreateOp(nID, &op);
		BreakOnFailure0(hr);
		PXV::ICabPtr rootNode;
		op->get_Params(&rootNode);
		_cab_node_t rootParams(rootNode);
		rootParams[L"Options.History"] = false;
		PXV::IAFS_FileSysPtr pFs;
		m_AFSInst->get_DefaultFileSys(&pFs);
		PXV::IAFS_NamePtr pName;
		pFs->StringToName((LPWSTR)strFile, 0, nullptr, &pName);
		rootParams[L"Input"] = (IUnknown*)pName;
		hr = op->Do(0);
		BreakOnFailure0(hr);
	} while (false);
	ATLASSERT(hr == S_OK);
}

void CPrefInst::SettOpen()
{
	if (!m_Inst)
		return;

	m_Inst->ExecUICmd(CComBSTR(L"cmd.prefs"), nullptr);
}

HRESULT CPrefInst::OnEventPxvControl(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom)
{
	if (nEventID == nid_e_operBeforeExecute)
	{
		PXV::IOperationPtr oper = pFrom;
		long opID = 0;
		oper->get_ID(&opID);
		if (opID == nid_op_appPrefsChanged)
		{
			m_bAppPrefsChanged = true;
		}
	}
	else if (nEventID == nid_e_app_prefsChanged && m_bAppPrefsChanged)
	{
		m_bAppPrefsChanged = false;
		PXV::IEventPtr pEv = pEvent;
		PXV::PARAM_T param1;
		pEv->get_Param1(&param1);
		IUnknownPtr pUnk = (IUnknown*)param1;
		PXV::IBitSetPtr pBitSet;
		pUnk->QueryInterface(&pBitSet);
		VARIANT_BOOL bHas = VARIANT_FALSE;
		pBitSet->get_HasSet(&bHas);
		if (bHas != VARIANT_FALSE)
		{
			WTL::CWaitCursor cr;
			SettSave();
		}
	}

	return S_OK;
}

