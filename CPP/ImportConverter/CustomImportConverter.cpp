#include "stdafx.h"
#include "CustomImportConverter.h"

#include <memory>
#include <string.h>
#include <algorithm>

namespace PXV
{

const PXC_Rect rc_letterSize = { 0.0, 0.0, 8.5 * 72.0, 11.0 * 72.0 };

const CHAR g_chDelimiter = ',';
const CHAR g_chQuote = '\"';
const CHAR g_chTerminator = '\n';

double I2P(double x)
{
	return (x * 72.0);
}

HRESULT ConverterCSV2PDF(IPXC_Inst* pxcInst, IStream* pFile, IProgressMon * pProgress, IPXC_Document* pxcDoc)
{
	HRESULT hr = S_OK;
	IPXC_PagesPtr pPages;
	pxcDoc->get_Pages(&pPages);
	if (!pPages)
		return E_FAIL;


	IPXC_ContentCreatorPtr pCC;
	pxcDoc->CreateContentCreator(&pCC);

	IPXC_FontPtr pFont;
	hr = pxcDoc->CreateNewFont(L"Arial", CreateFont_Italic, FW_BOLD, &pFont);
	if (pFont == nullptr)
		return hr;

	IPXC_FontPtr pFontText;
	hr = pxcDoc->CreateNewFont(L"Arial", CreateFont_Serif, FW_NORMAL, &pFontText);
	if (pFontText == nullptr)
		return hr;

	//pProgress
	double fPos = 0;
	STATSTG ss;
	pFile->Stat(&ss, 0);
	ss.cbSize;
	if (pProgress)
	{
		pProgress->put_Duration(ss.cbSize.QuadPart);
		pProgress->put_Pos(fPos);
	}

	int nLine = 0;
	CString dataHead[3];
	CString strLine;
	const auto pRead = std::get_temporary_buffer<BYTE>(1024);
	while (true)
	{
		ULONG cb = 0;
		HRESULT hr = pFile->Read(pRead.first, (ULONG)pRead.second, &cb);
		if (cb == 0)
			break;

		fPos += cb;
		if (pProgress)
		{
			VARIANT_BOOL bCancel = VARIANT_FALSE;
			pProgress->get_Canceled(&bCancel);
			if (bCancel)
				break;

			pProgress->put_Pos(fPos);
		}


		if (FAILED(hr))
			break;

		const auto pEnd = pRead.first + cb;
		PBYTE pStart = pRead.first;
		for (auto p = pRead.first; p < pEnd; p++)
		{
			if (*p == g_chTerminator)
			{
				nLine++;
				strLine.Append(CString((PCHAR)pStart, (int)(p - pStart)));
				strLine.AppendChar(g_chDelimiter);
				pStart = p + 1;

				CString data[3];
				int nIndex = 0;
				LPCWSTR pStart = strLine;
				LPCWSTR pEndLine = (LPCWSTR)strLine + strLine.GetLength();
				for (LPCWSTR pSplit = pStart; pSplit < pEndLine; pSplit++)
				{
					if (nIndex > 2)
						break;

					if (pSplit[0] == g_chDelimiter)
					{
						data[nIndex].SetString(pStart, (int)(pSplit - 1 - pStart));
						nIndex++;
						pStart = pSplit + 1;
					}
					else if (pSplit[0] == g_chQuote)
					{
						pSplit++;
						pStart = pSplit;
						while (pSplit < pEndLine && (pSplit[0] != g_chQuote))
						{
							pSplit++;
						}
					}
				}
				strLine.Empty();
				if (nLine == 1)
				{
					for (int i = 0; i < _countof(data); i++)
					{
						dataHead[i] = data[i];
					}
					continue;
				}

				pCC->SaveState();
				pCC->SetTextRenderMode(TRM_Fill);

				PXC_Rect rc(rc_letterSize);
				double x = I2P(1);
				double y = rc.top - I2P(1);
				//data[0].Format(L"Page %d", nLine);
				for (int i = 0; i < _countof(data); i++)
				{
					pCC->SetFont(pFont);
					pCC->SetFontSize(14);
					pCC->ShowTextLine(x, y, dataHead[i].GetBuffer(), -1, 0);

					pCC->SetFont(pFontText);
					pCC->SetFontSize(11);
					PXC_Rect rc1 = { x + I2P(2), y - I2P(1) , rc.right, y};
					PXC_Rect rcBlock = {0};
					pCC->ShowTextBlock(data[i].GetBuffer(), &rc1, &rc1, 0, -1, nullptr, nullptr, nullptr, &rcBlock);
					y -= I2P(1);
				}
				pCC->RestoreState();

				IPXC_PagePtr pPage;
				hr = pPages->InsertPage(-1, &rc, nullptr, &pPage);
				if (FAILED(hr))
					return hr;

				IPXC_ContentPtr pContent;
				pCC->Detach(&pContent);
				hr = pPage->PlaceContent(pContent, PlaceContent_Replace);
			}
		}
		strLine.SetString(CString((PCHAR)pStart, (int)(pEnd - pStart)));
	};
	std::return_temporary_buffer(pRead.first);
	return hr;
};

}
