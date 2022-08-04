#include "stdafx.h"
#include "CCustomEventTarget.h"


CCustomEventTarget::CCustomEventTarget(PXV::IUIX_Obj* obj)
{
	SetObj(obj);
}


CCustomEventTarget::CCustomEventTarget()
{

}

CCustomEventTarget::~CCustomEventTarget()
{
	Dispose();
}

void CCustomEventTarget::SetObj(PXV::IUIX_Obj* obj)
{
	m_Obj = obj;
	if (m_Obj != nullptr)
		m_Obj->PushImpl(this, VARIANT_FALSE);
}

HRESULT __stdcall CCustomEventTarget::get_Obj(struct PXV::IUIX_Obj * * pObj)
{
	return 0;
}

HRESULT __stdcall CCustomEventTarget::OnPreEvent(struct PXV::IUIX_Obj * pSender, struct PXV::IUIX_Event * pEvent)
{
	return 0;
}

HRESULT __stdcall CCustomEventTarget::OnEvent(struct PXV::IUIX_Obj * pSender, struct PXV::IUIX_Event * pEvent)
{
	//If the event is not handled then it will be
	pEvent->put_Handled(VARIANT_FALSE);
	long nCode = 0;
	pEvent->get_Code(&nCode);
	if (nCode == (int)PXV::e_Notify)
	{
		PXV::PARAM_T nParam = 0;
		pEvent->get_Param1(&nParam);
		PXV::UIX_NotifyInfo* ni = (PXV::UIX_NotifyInfo*)nParam;
		if (ni->nCode == (int)PXV::UIX_Notify_Layout_AddNewTabs)
		{
			pEvent->put_Handled(VARIANT_TRUE);
		}
	}
	return 0;
}

HRESULT __stdcall CCustomEventTarget::OnPostEvent(struct PXV::IUIX_Obj * pSender, struct PXV::IUIX_Event * pEvent)
{
	return 0;
}

void CCustomEventTarget::Dispose()
{
	if (m_Disposed)
		return;
	m_Disposed = true;
	if (m_Obj != nullptr)
	{
		m_Obj->PopImpl(this);
		m_Obj = nullptr;
	}
}


