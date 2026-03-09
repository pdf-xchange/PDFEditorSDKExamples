#include "stdafx.h"
#include "CIPXV_ControlEvents.h"




BEGIN_INTERFACE_MAP(CIPXV_ControlEvents, CCmdTarget)
	INTERFACE_PART(CIPXV_ControlEvents, __uuidof(PXV::_IPXV_ControlEvents), LocalClass)
END_INTERFACE_MAP()

BEGIN_DISPATCH_MAP(CIPXV_ControlEvents, CCmdTarget)
	DISP_FUNCTION_ID(CIPXV_ControlEvents, "OnEvent", 1, CIPXV_ControlEvents::OnEvent, VT_EMPTY, VTS_I4 VTS_DISPATCH VTS_UNKNOWN)
END_DISPATCH_MAP()


STDMETHODIMP_(ULONG) CIPXV_ControlEvents::XLocalClass::AddRef()
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		return pThis->ExternalAddRef();
}

STDMETHODIMP_(ULONG) CIPXV_ControlEvents::XLocalClass::Release()
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		return pThis->ExternalRelease();
}

STDMETHODIMP CIPXV_ControlEvents::XLocalClass::QueryInterface(REFIID iid, LPVOID* ppvObj)
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		return pThis->ExternalQueryInterface(&iid, ppvObj);
}

STDMETHODIMP CIPXV_ControlEvents::XLocalClass::GetTypeInfoCount(UINT FAR* pctinfo)
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		LPDISPATCH lpDispatch = pThis->GetIDispatch(FALSE);
	ASSERT(lpDispatch != NULL);
	return lpDispatch->GetTypeInfoCount(pctinfo);
}

STDMETHODIMP CIPXV_ControlEvents::XLocalClass::GetTypeInfo(UINT itinfo, LCID lcid, ITypeInfo FAR* FAR* pptinfo)
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		LPDISPATCH lpDispatch = pThis->GetIDispatch(FALSE);
	ASSERT(lpDispatch != NULL);
	return lpDispatch->GetTypeInfo(itinfo, lcid, pptinfo);
}

STDMETHODIMP CIPXV_ControlEvents::XLocalClass::GetIDsOfNames(REFIID riid, OLECHAR FAR* FAR* rgszNames, UINT cNames, LCID lcid, DISPID FAR* rgdispid)
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		LPDISPATCH lpDispatch = pThis->GetIDispatch(FALSE);
	ASSERT(lpDispatch != NULL);
	return lpDispatch->GetIDsOfNames(riid, rgszNames, cNames,
		lcid, rgdispid);
}

STDMETHODIMP CIPXV_ControlEvents::XLocalClass::Invoke(DISPID dispidMember, REFIID riid, LCID lcid, WORD wFlags,
	DISPPARAMS FAR* pdispparams, VARIANT FAR* pvarResult,
	EXCEPINFO FAR* pexcepinfo, UINT FAR* puArgErr)
{
	METHOD_PROLOGUE(CIPXV_ControlEvents, LocalClass)
		LPDISPATCH lpDispatch = pThis->GetIDispatch(FALSE);
	ASSERT(lpDispatch != NULL);
	return lpDispatch->Invoke(dispidMember, riid, lcid,
		wFlags, pdispparams, pvarResult,
		pexcepinfo, puArgErr);
}

STDMETHODIMP CIPXV_ControlEvents::XLocalClass::OnEvent(long nEventID, LPDISPATCH pEvent, LPUNKNOWN pFrom)
{
	HRESULT hr = E_NOTIMPL;

	return hr;
}


//const _ATL_FUNC_INFO IPXV_ControlEventsImpl<T>::mc_AtlFuncInfo = {};


