#pragma once
using namespace PXV;

class CEventHandle;
const int ID_EVENT = 1;
extern _ATL_FUNC_INFO info1;

const GUID  LIBID_Event = { 0x8d00937c, 0x06b9, 0x4b5c,{ 0x9a, 0x94, 0xa7, 0xe0, 0x46, 0x33, 0x6b, 0x01 } };

typedef IDispEventImpl<ID_EVENT,
	CEventHandle,
	&__uuidof(PXV::_IPXV_ControlEvents),
	&GUID_NULL,
	1,
	0> MyPXVEvents;

class CEventHandle : public MyPXVEvents
{
public:
	// constructor/destructor
	CEventHandle();
	virtual ~CEventHandle();

	// set Monitor
	void SetEventMonitor(PXV::IPXV_ControlPtr v_pEvent);

		  // Sink interface declaration
	BEGIN_SINK_MAP(CEventHandle)
		SINK_ENTRY_INFO(ID_EVENT, __uuidof(PXV::_IPXV_ControlEvents), 1, __OnEvent, &info1)
	END_SINK_MAP()

	// COM event hookup
	STDMETHOD_(HRESULT, __OnEvent)(/*[in]*/ long nEventID, /*[in]*/ struct IEvent * pEvent, /*[in]*/ IUnknown * pFrom);

private:
	PXV::IPXV_ControlPtr m_pCtrlEvent;

	void _Release();
};
