#pragma once

#include <vector>
#include <string>

#include "Macroses.h"

#if defined _M_X64
#define Api_File "PDFXEditCore.x64.dll"
#else
#define Api_File "PDFXEditCore.x86.dll"
#endif

#pragma warning( disable : 4192 )
#pragma warning( disable : 4278 )

#import Api_File rename_namespace("PXV"), raw_interfaces_only, exclude("LONG_PTR", "ULONG_PTR", "UINT_PTR")

#pragma warning( default : 4278 )
#pragma warning( default : 4192 )

#include "CabHelper.h"

typedef CComPtr<PXV::IPXV_Inst> t_pInst;

//typedef CComPtr<PXV::ICabNode> t_pCabNode;


#if defined _M_X64

#define SDK_DLL L"PDFXCoreAPI.x64.dll"

#ifdef _DEBUG
#define SDK_PATH L"%PXCC_BIN64D_PATH%"
#else	// _DEBUG
#define SDK_PATH L"%PXCC_BIN64R_PATH%"
#endif	// _DEBUG

#else	// _M_X64

#define SDK_DLL L"PDFXCoreAPI.x86.dll"

#ifdef _DEBUG
#define SDK_PATH L"%PXCC_BIN32D_PATH%"
#else	// _DEBUG
#define SDK_PATH L"%PXCC_BIN32R_PATH%"
#endif	// _DEBUG

#endif

typedef HRESULT(WINAPI *fnPXC_GetInstance)(PXV::IPXV_Inst** ppInst);


