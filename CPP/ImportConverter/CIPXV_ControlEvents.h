#pragma once
#include <atlcom.h>

class CIPXV_ControlEvents : public CCmdTarget
{
public:
	CIPXV_ControlEvents() = default;
	~CIPXV_ControlEvents() = default;
public:
	DECLARE_INTERFACE_MAP()
	DECLARE_DISPATCH_MAP()

	BEGIN_INTERFACE_PART(LocalClass, PXV::_IPXV_ControlEvents)
		STDMETHOD(OnEvent)(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom);
		STDMETHOD(GetTypeInfoCount)(UINT FAR* pctinfo);
		STDMETHOD(GetTypeInfo)(UINT itinfo, LCID lcid, ITypeInfo FAR* FAR* pptinfo);
		STDMETHOD(GetIDsOfNames)(REFIID riid, OLECHAR FAR* FAR* rgszNames, UINT cNames, LCID lcid, DISPID FAR* rgdispid);
		STDMETHOD(Invoke)(DISPID dispidMember, REFIID riid, LCID lcid, WORD wFlags, DISPPARAMS FAR* pdispparams, VARIANT FAR* pvarResult, EXCEPINFO FAR* pexcepinfo, UINT FAR* puArgErr);
	END_INTERFACE_PART(LocalClass)
public:
};


class ATL_NO_VTABLE CIPXV_ControlEventsATL :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CIPXV_ControlEventsATL>,
	public IDispatchImpl<PXV::_IPXV_ControlEvents, &__uuidof(PXV::_IPXV_ControlEvents), &__uuidof(PXV::__PDFXEdit), 1, 0>
{
public:
	CIPXV_ControlEventsATL() = default;
	virtual ~CIPXV_ControlEventsATL() = default;

	DECLARE_NOT_AGGREGATABLE(CIPXV_ControlEventsATL)

	BEGIN_COM_MAP(CIPXV_ControlEventsATL)
		COM_INTERFACE_ENTRY2(IDispatch, PXV::_IPXV_ControlEvents)
		COM_INTERFACE_ENTRY(PXV::_IPXV_ControlEvents)
	END_COM_MAP()

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	STDMETHOD(OnEvent)(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom)
	{

		HRESULT hr = E_NOTIMPL;

		return hr;
	};

};

#define SINK_ID  1
static _ATL_FUNC_INFO funcInfoEvent = { CC_STDCALL, VT_EMPTY, 3, {VT_I4, VT_DISPATCH, VT_UNKNOWN} };

template <class T>
class ATL_NO_VTABLE IPXV_ControlEventsImpl :
	public IDispEventSimpleImpl<SINK_ID, IPXV_ControlEventsImpl<T>, &__uuidof(PXV::_IPXV_ControlEvents)>
{
public:
	BEGIN_SINK_MAP(IPXV_ControlEventsImpl)
		SINK_ENTRY_INFO(SINK_ID, __uuidof(PXV::_IPXV_ControlEvents), 1, OnEvent1, &funcInfoEvent)
	END_SINK_MAP()

	STDMETHOD(OnEvent1)(long nEventID, PXV::IEvent* pEvent, LPUNKNOWN pFrom)
	{
		T* pT = static_cast<T*>(this);
		return pT->OnEvent(nEventID, pEvent, pFrom);
	}
};

