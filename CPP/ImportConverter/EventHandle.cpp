#include "stdafx.h"
#include "EventHandle.h"

_ATL_FUNC_INFO info1 = { CC_STDCALL, VT_EMPTY, 3,{ VT_I4, VT_DISPATCH, VT_UNKNOWN} };

CEventHandle::CEventHandle()
{
}


CEventHandle::~CEventHandle()
{
	_Release();
}

HRESULT CEventHandle::__OnEvent(long nEventID, IEvent * pEvent, IUnknown * pFrom)
{
	//   return OnEvent(nEventID, pEvent, pFrom);
	OutputDebugString(_T("Hello~"));
	return 0;
}

void CEventHandle::_Release()
{
	if (m_pCtrlEvent != NULL)
	{
		MyPXVEvents::DispEventUnadvise(m_pCtrlEvent);
		m_pCtrlEvent = NULL;
	}
}

void CEventHandle::SetEventMonitor(PXV::IPXV_ControlPtr v_pEvent)
{
	HRESULT hr = NULL;

	_Release();

	if (v_pEvent != NULL)
	{
		hr = MyPXVEvents::DispEventAdvise(v_pEvent, &__uuidof(PXV::_IPXV_ControlEvents));
		if (FAILED(hr))
		{
			_com_raise_error(hr);
		}

		m_pCtrlEvent = v_pEvent;
	}
}
