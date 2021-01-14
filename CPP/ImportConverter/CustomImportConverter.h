#pragma once


namespace PXV
{

HRESULT ConverterCSV2PDF(IPXC_Inst* pxcInst, IStream* pFile, IProgressMon * pProgress, IPXC_Document* pxcDoc);

class CCustomImportConverter : public PXV::IPXV_ImportConverter
{
	IPXV_InstPtr		m_pInst = nullptr;
	LONG				m_cRef = 0;

public:
	CCustomImportConverter(IPXV_InstPtr pInst)
	{
		m_pInst = pInst;
	}

public:
	virtual HRESULT __stdcall CheckFormat(struct IPXV_Inst * pInst, IUnknown * pSrc, ULONG_T nFlags, enum PXV_FmtCheckResult * pCheckResVal) override
	{
		return CheckFormat2(pInst, pSrc, nFlags, nullptr, nullptr, pCheckResVal);
	}

	virtual HRESULT __stdcall CheckFormat2(struct IPXV_Inst * pInst, IUnknown * pSrc, ULONG_T nFlags, struct ICab * * pFmtDetails, IUnknown * * pCheckRes, enum PXV_FmtCheckResult * pCheckResVal) override
	{
		*pCheckResVal = FmtCheckRes_OK;
		return S_OK;
	}

	virtual HRESULT __stdcall Convert(struct IPXV_Inst * pInst, IUnknown * pSrc, ULONG_T nFlags, struct ICab * pParams, struct IProgressMon * pProgress, HANDLE_T hWndParent, IUnknown * pCtx, struct IPXC_Document * * pDoc) override
	{
		IPXC_InstPtr pxcInst = nullptr;
		IUnknownPtr pUnk;
		m_pInst->GetExtension(L"PXC", &pUnk);
		if (!pUnk)
			return E_FAIL;
		pxcInst = static_cast<IPXC_Inst*>((IUnknown*)pUnk);
		if (!pxcInst)
			return E_FAIL;


		IStreamPtr pStream;
		IAFS_FilePtr pFile;
		if (pSrc)
		{
			pSrc->QueryInterface(&pStream);

			if (pStream == nullptr)
				pSrc->QueryInterface(&pFile);

			if (pFile)
			{
				pFile->GetStream(&pStream);
			}
		}

		*pDoc = nullptr;
		if (pStream)
		{
			IPXC_DocumentPtr pxcDoc;
			pxcInst->NewDocument(&pxcDoc);
			if (!pxcDoc)
				return E_FAIL;

			ConverterCSV2PDF(pxcInst, pStream, pProgress, pxcDoc);

			*pDoc = pxcDoc;
			(*pDoc)->AddRef();
		}
		return S_OK;
	}

	virtual HRESULT __stdcall get_Flags(ULONG_T * nFlags) override
	{
		*nFlags = 0;
		return S_OK;
	}


	virtual HRESULT __stdcall get_ID(BSTR * sID) override
	{

		*sID = ::SysAllocString(L"conv.myCustom");
		return S_OK;
	}


	virtual HRESULT __stdcall get_Name(BSTR * sName) override
	{
		*sName = ::SysAllocString(L"MyCustomFilter");
		return S_OK;
	}


	virtual HRESULT __stdcall get_FilterName(BSTR * sFilterName) override
	{
		*sFilterName = ::SysAllocString(L"CSV File");
		return S_OK;
	}


	virtual HRESULT __stdcall get_Extensions(BSTR * sExtensions) override
	{
		*sExtensions = ::SysAllocString(L"*.csv");
		return S_OK;
	}


	virtual HRESULT __stdcall get_Description(BSTR * sDesc) override
	{
		*sDesc = L"Database information organized as field separated lists";
		return S_OK;
	}


	virtual HRESULT __stdcall get_MIME(BSTR * sMIME) override
	{
		*sMIME = L"text/csv";
		return S_OK;
	}


	virtual HRESULT __stdcall get_Icon(struct IUIX_Icon * * pIcon) override
	{
		*pIcon = nullptr;
		return S_OK;
	}


	virtual HRESULT __stdcall CreateParams(struct IPXV_Inst * pInst, struct ICab * * pParams) override
	{
		return S_OK;
	}


	virtual HRESULT __stdcall ShowPrefsDlg(struct IPXV_Inst * pInst, struct ICab * pParams, HANDLE_T hWndParent, IUnknown * pSrc, ULONG_T nFlags) override
	{
		return S_OK;
	}


	virtual HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppvObject)
	{
		// Always set out parameter to NULL, validating it first.
		if (!ppvObject)
			return E_INVALIDARG;
		*ppvObject = NULL;
		if (riid == IID_IUnknown)
		{
			// Increment the reference count and return the pointer.
			*ppvObject = (LPVOID)this;
			AddRef();
			return NOERROR;
		}
		return E_NOINTERFACE;
	}


	virtual ULONG STDMETHODCALLTYPE AddRef(void)
	{
		InterlockedIncrement(&m_cRef);
		return m_cRef;
	}


	virtual ULONG STDMETHODCALLTYPE Release(void)
	{
		// Decrement the object's internal counter.
		ULONG ulRefCount = InterlockedDecrement(&m_cRef);
		if (0 == m_cRef)
		{
			delete this;
		}
		return ulRefCount;
	}
};

}
