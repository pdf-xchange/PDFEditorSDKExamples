#pragma once

class ATL_NO_VTABLE CCustomEventTarget:
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCustomEventTarget>,
	public IDispatchImpl<PXV::IUIX_ObjImpl>
{
public:
	CCustomEventTarget();
	CCustomEventTarget(PXV::IUIX_Obj* obj);
	virtual ~CCustomEventTarget();

	DECLARE_NOT_AGGREGATABLE(CCustomEventTarget)

	BEGIN_COM_MAP(CCustomEventTarget)
		COM_INTERFACE_ENTRY(PXV::IUIX_ObjImpl)
		COM_INTERFACE_ENTRY(IDispatch)
	END_COM_MAP()

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	CComPtr<PXV::IUIX_Obj> m_Obj;
	bool m_Disposed = false;

	void SetObj(PXV::IUIX_Obj* obj);

	virtual HRESULT __stdcall get_Obj(struct PXV::IUIX_Obj * * pObj);
	virtual HRESULT __stdcall OnPreEvent(struct PXV::IUIX_Obj * pSender, struct PXV::IUIX_Event * pEvent);
	virtual HRESULT __stdcall OnEvent(struct PXV::IUIX_Obj * pSender, struct PXV::IUIX_Event * pEvent);
	virtual HRESULT __stdcall OnPostEvent(struct PXV::IUIX_Obj * pSender, struct PXV::IUIX_Event * pEvent);

	void Dispose();
};



