#pragma once

#ifndef _raw_method

#ifdef API_NRAW_IMPORT
#define _raw_method(name)	raw_ ## name
#else
#define _raw_method(name)	name
#endif // API_NRAW_IMPORT

#endif // _raw_method

#ifndef _maxint
#define _maxint	0x7fffffff
#endif

// class _cab_node_t;
//
// template <class T>
// class _object_t : public ATL::CComPtr < T >
// {
// 	typedef ATL::CComPtr<T> baseClass;
// 	typedef _object_t<T> thisClass;
// public:
// 	inline _object_t() { }
// 	inline _object_t(T* lp)
// 	{
// 		p = lp;
// 		if (p)
// 			p->AddRef();
// 	}
// 	inline _object_t(thisClass const &lp)
// 	{
// 		*this = lp;
// 	}
// 	inline _object_t(thisClass &&lp) throw()
// 	{
// 		p = lp.p;
// 		lp.p = nullptr;
// 	}
// // 	inline _object_t(const _cab_node_t& src)
// // 	{
// // 		src.GetValue(*this);
// // 	}
// public:
// 	inline T* operator=(T* lp) throw()
// 	{
// 		ReplaceT(p, lp);
// 		return p;
// 	}
// 	inline thisClass& operator=(thisClass && lp) throw()
// 	{
// 		if (p != lp.p)
// 		{
// 			T* p2 = p;
// 			p = lp.p;
// 			lp.p = nullptr;
// 			if (p2)
// 				p2->Release();
// 		}
// 		return *this;
// 	}
// 	inline T* operator=(const thisClass& lp) throw()
// 	{
// 		ReplaceT(p, lp.p);
// 		return p;
// 	}
// };
//
// typedef _object_t<IUnknown> _unknown_t;
// typedef _object_t<IStream> _stream_t;

typedef CComPtr<IUnknown> _unknown_t;
typedef CComPtr<IStream> _stream_t;

class _cab_node_t
{
public:
	class _iter
	{
		PXV::ICabNode*	p;
		int			pos = 0;
	public:
		_iter(PXV::ICabNode* p_, long pos_)
		{
			p = p_;
			if (p)
				p->AddRef();
			pos = pos_;
		}
		_iter(const _iter& src)
		{
			p = src.p;
			pos = src.pos;
			if (p)
				p->AddRef();
		}
		~_iter()
		{
			if (p)
				p->Release();
		};
	public:
		inline _iter& operator++()
		{
			if (p)
			{
				int nCnt = 0;
				p->get_Count(&nCnt);
				if (pos < nCnt)
					pos++;
			}
			return *this;
		}
		inline _iter& operator--()
		{
			if (pos >= 0)
				pos--;
			return *this;
		}
		inline operator _cab_node_t()
		{
			if (!p || (pos < 0) || (pos == _maxint))
				return _cab_node_t();
			VARIANT key = { 0 };
			key.vt = VT_I4;
			key.iVal = pos;
			_cab_node_t res;
			p->get_Item(key, &res.p);
			return res;
		}
		inline bool operator==(const _iter& right) const
		{
			return (p == right.p) && (pos == right.pos);
		}
		inline bool operator!=(const _iter& right) const
		{
			return (!(*this == right));
		}
		inline bool operator<(const _iter& right) const
		{
			_ASSERTE(p && p == right.p);
			if (!p || p != right.p)
				return false;
			int rightPos = 0;
			if (right.pos == _maxint) // end() iterator
				p->get_Count(&rightPos);
			return (pos < rightPos);
		}
		inline bool operator>(const _iter& right) const
		{
			return (right < *this);
		}
		inline bool operator<=(const _iter& right) const
		{
			return (!(right < *this));
		}
		inline bool operator>=(const _iter& right) const
		{
			return (!(*this < right));
		}
	};

	typedef const _iter const_iter;

public:
	PXV::ICabNode*	p;
public:
	inline _cab_node_t()
	{
		p = nullptr;
	};
	inline _cab_node_t(_cab_node_t&& src)
	{
		p = src.p;
		src.p = nullptr;
	};
	inline _cab_node_t(const _cab_node_t& src)
	{
		p = src.p;
		if (p)
			p->AddRef();
	};
	inline _cab_node_t(PXV::ICabNode* pI)
	{
		p = pI;
		if (p)
			p->AddRef();
	};
	inline _cab_node_t(PXV::ICabNode* pI, bool bAddRef)
	{
		p = pI;
		if (p && bAddRef)
			p->AddRef();
	};
	inline _cab_node_t(PXV::ICab* pI)
	{
		p = nullptr;
		if (pI)
			pI->get_Root(&p);
	};
	~_cab_node_t()
	{
		_Release();
	};
public:
	inline void _Release()
	{
		if (p)
		{
			p->Release();
			p = nullptr;
		}
	}

	inline void Attach(PXV::ICabNode* pI, bool bAddRef = true)
	{
		if (pI)
			pI->AddRef();
		_Release();
		p = pI;
	}

	inline _cab_node_t& operator =(const _cab_node_t& src)
	{
		if (p == src.p)
			return *this;
		Attach(src.p);
		return *this;
	}

	inline _cab_node_t& operator =(PXV::ICabNode* pI)
	{
		if (p == pI)
			return *this;
		Attach(pI);
		return *this;
	}

	inline bool operator ==(PXV::ICabNode* pI) const
	{
		return (p == pI);
	}

	inline bool operator !=(PXV::ICabNode* pI) const
	{
		return (p != pI);
	}

	inline PXV::ICabNode* Detach()
	{
		PXV::ICabNode* pI = p;
		p = nullptr;
		return pI;
	}

	inline operator PXV::ICabNode*() const
	{
		return p;
	}

	inline PXV::ICabNode** operator &()
	{
		return &p;
	}

	inline bool IsNull() const
	{
		return (p == nullptr);
	}

	inline PXV::CabDataTypeID GetType() const
	{
		if (!p)
			return PXV::dt_Invalid;
		PXV::CabDataTypeID res = PXV::dt_Invalid;
		p->get_Type(&res);
		return res;
	}
	__declspec(property(get = GetType)) PXV::CabDataTypeID type;

	inline bool IsArray() const { return (GetType() == PXV::dt_Array); }
	inline bool IsInvalid() const { return (GetType() == PXV::dt_Invalid); }

	inline bool Copy(PXV::ICabNode* pI)
	{
		if (p == pI)
			return false;
		_ASSERT(p && pI);
		if (!p || !pI)
			return false;
		HRESULT hr = p->Copy(pI);
		return SUCCEEDED(hr);
	}

public:

	//////////////////////////////////////////////////////////////////////////
	// get sub-node
	//////////////////////////////////////////////////////////////////////////

	// get by name (Dictionary)
	inline _cab_node_t at(const wchar_t* pKey) const
	{
		_ASSERTE(p != nullptr);
		if (!p || !pKey || !pKey[0])
			return *this;
		VARIANT key = { 0 };
		key.vt = VT_LPWSTR;
		key.bstrVal = (BSTR)pKey;
		_cab_node_t res;
		p->get_Item(key, &res.p);
		return res;
	}
	inline _cab_node_t operator [](const wchar_t* pKey) const
	{
		return at(pKey);
	}

	// get by index (Array/Dictionary)
	inline _cab_node_t at(int nIndex) const
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		VARIANT key = { 0 };
		key.vt = VT_I4;
		key.iVal = nIndex;
		_cab_node_t res;
		p->get_Item(key, &res.p);
		return res;
	}
	inline _cab_node_t operator [](int nIndex) const
	{
		return at(nIndex);
	}

	inline int size() const
	{
		if (!p)
			return 0;
		int res = 0;
		p->get_Count(&res);
		return res;
	}

	inline bool empty() const
	{
		if (!p)
			return true;
		int res = 0;
		p->get_Count(&res);
		return (res == 0);
	}

	inline _iter begin()
	{
		return _iter(p, 0);
	}

	inline const_iter begin() const
	{
		return const_iter(p, 0);
	}

	inline _iter end()
	{
		return _iter(p, _maxint);
	}

	inline const_iter end() const
	{
		return const_iter(p, _maxint);
	}

	// Array
	inline _cab_node_t Insert(PXV::CabDataTypeID dt = PXV::dt_Undefined, int nIndex = -1)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Array || dt_ == PXV::dt_Undefined);
		if (!(dt_ == PXV::dt_Array || dt_ == PXV::dt_Undefined))
			return _cab_node_t();
		VARIANT key = { 0 };
		key.vt = VT_I4;
		key.iVal = nIndex;
		_cab_node_t res;
		p->_raw_method(Insert)(key, dt, &res.p);
		return res;
	}
	inline bool Remove(int nIndex)
	{
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Array);
		if (!(dt_ == PXV::dt_Array))
			return false;
		VARIANT key = { 0 };
		key.vt = VT_I4;
		key.iVal = nIndex;
		HRESULT hr = p->_raw_method(Remove)(key);
		return SUCCEEDED(hr);
	}

	// Dictionary
	inline _cab_node_t Insert(LPCWSTR pKey, PXV::CabDataTypeID dt = PXV::dt_Undefined)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE((dt_ == PXV::dt_Dictionary || dt_ == PXV::dt_Undefined) && (pKey && pKey[0]));
		if (!((dt_ == PXV::dt_Dictionary || dt_ == PXV::dt_Undefined) && (pKey && pKey[0])))
			return _cab_node_t();
		VARIANT key = { 0 };
		key.vt = VT_LPWSTR;
		key.bstrVal = (BSTR)pKey;
		_cab_node_t res;
		p->_raw_method(Insert)(key, dt, &res.p);
		return res;
	}
	inline bool Remove(LPCWSTR pKey)
	{
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE((dt_ == PXV::dt_Dictionary) && (pKey && pKey[0]));
		if (!((dt_ == PXV::dt_Dictionary) && (pKey && pKey[0])))
			return false;
		VARIANT key = { 0 };
		key.vt = VT_LPWSTR;
		key.bstrVal = (BSTR)pKey;
		HRESULT hr = p->_raw_method(Remove)(key);
		return SUCCEEDED(hr);
	}

	inline void Clear()
	{
		if (!p)
			return;
		p->Clear();
	}

public:

	//////////////////////////////////////////////////////////////////////////
	// get value
	//////////////////////////////////////////////////////////////////////////

	// boolean
	inline operator bool() const
	{
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Bool);
		if (dt_ != PXV::dt_Bool)
			return false;
		VARIANT_BOOL res = 0;
		p->get_Bool(&res);
		return (res != 0);
	}

	// string
	inline operator LPCWSTR() const
	{
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_String);
		if (dt_ != PXV::dt_String)
			return nullptr;
		SIZE_T res = 0;
		p->get_StringPtr(&res);
		return (LPCWSTR)res;
	}

	inline operator LPWSTR() const
	{
		return (LPWSTR)(LPCWSTR)*this;
	}

	// int
	inline operator short() const // cast to VARIANT_BOOL
	{
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Bool);
		if (dt_ != PXV::dt_Bool)
			return 0;
		VARIANT_BOOL res = 0;
		p->get_Bool(&res);
		return -(res != 0);
	}
	inline operator unsigned short() const
	{
		return (unsigned short)(short)*this;
	}
	inline operator int() const
	{
		const PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Int || dt_ == PXV::dt_Bool);
		int res = 0;
		if (dt_ == PXV::dt_Int)
		{
			p->get_Int(&res);
		}
		else if (dt_ == PXV::dt_Bool)
		{
			VARIANT_BOOL v = 0;
			p->get_Bool(&v);
			res = v != 0;
		}
		return res;
	}
	inline operator unsigned int() const
	{
		return (unsigned int)(int)*this;
	}
	inline operator long() const
	{
		return (long)(int)*this;
	}
	inline operator unsigned long() const
	{
		return (long)(int)*this;
	}
	// int64
	inline operator __int64() const
	{
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Int64);
		if (dt_ != PXV::dt_Int64)
			return 0;
		__int64 res = 0;
		p->get_Int64(&res);
		return res;
	}

	inline operator unsigned __int64() const
	{
		return (unsigned __int64)(__int64)*this;
	}
	// double
	inline operator double() const
	{
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Double);
		if (dt_ != PXV::dt_Double)
			return 0.0;
		double res = 0.0;
		p->get_Double(&res);
		return res;
	}

	inline operator _unknown_t() const
	{
		_unknown_t r;
		GetValue(r);
		return r;
	}

	inline operator _stream_t() const
	{
		_stream_t r;
		GetValue(r);
		return r;
	}

	inline bool GetValue(_unknown_t& res) const
	{
		res = nullptr;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_IUnknown);
		if (dt_ != PXV::dt_IUnknown)
			return false;
		p->get_Unknown(&res);
		return (res != nullptr);
	}

	inline bool GetValue(_stream_t& res) const
	{
		res = nullptr;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Stream);
		if (dt_ != PXV::dt_Stream)
			return false;
		p->get_Stream(&res);
		return (res != nullptr);
	}

public:
	//////////////////////////////////////////////////////////////////////////
	// put value
	//////////////////////////////////////////////////////////////////////////

	// boolean
	inline _cab_node_t& operator =(bool v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Bool || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_Bool || dt_ == PXV::dt_Undefined)
			p->put_Bool(-(v != false));
		return *this;
	}

	// string
	inline _cab_node_t& operator =(LPCWSTR v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_String || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_String || dt_ == PXV::dt_Undefined)
			p->put_String((BSTR)v);
		return *this;
	}

	// int
	inline _cab_node_t& operator =(short v) // VARIANT_BOOL
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Bool || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_Bool || dt_ == PXV::dt_Undefined)
			p->put_Bool(-(v != 0));
		return *this;
	}
	inline _cab_node_t& operator =(unsigned short v)
	{
		*this = (short)v;
		return *this;
	}
	inline _cab_node_t& operator =(int v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Int || dt_ == PXV::dt_Bool || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_Int || dt_ == PXV::dt_Undefined)
			p->put_Int(v);
		else if (dt_ == PXV::dt_Bool)
			p->put_Bool(-(v != 0));
		else if (dt_ == PXV::dt_Int64)
			p->put_Int64((__int64)v);
		else if (dt_ == PXV::dt_Double)
			p->put_Double((double)v);
		return *this;
	}
	inline _cab_node_t& operator =(unsigned int v)
	{
		*this = (int)v;
		return *this;
	}
	inline _cab_node_t& operator =(long v)
	{
		*this = (int)v;
		return *this;
	}
	inline _cab_node_t& operator =(unsigned long v)
	{
		*this = (int)v;
		return *this;
	}
	// int64
	inline _cab_node_t& operator =(__int64 v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Int64 || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_Int64 || dt_ == PXV::dt_Undefined)
			p->put_Int64(v);
		else if (dt_ == PXV::dt_Double)
			p->put_Double((double)v);
		return *this;
	}

	inline _cab_node_t& operator =(unsigned __int64 v)
	{
		*this = (__int64)v;
		return *this;
	}
	// double
	inline _cab_node_t& operator =(double v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Double || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_Double || dt_ == PXV::dt_Undefined)
			p->put_Double(v);
		return *this;
	}
	inline _cab_node_t& operator =(IUnknown* v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_IUnknown || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_IUnknown || dt_ == PXV::dt_Undefined)
			p->put_Unknown(v);
		return *this;
	}
	inline _cab_node_t& operator =(IStream* v)
	{
		_ASSERTE(p != nullptr);
		if (!p)
			return *this;
		PXV::CabDataTypeID dt_ = type;
		_ASSERTE(dt_ == PXV::dt_Stream || dt_ == PXV::dt_Undefined);
		if (dt_ == PXV::dt_Stream || dt_ == PXV::dt_Undefined)
			p->put_Stream(v);
		return *this;
	}
public:
	inline std::vector<CString> Dictionary_GetKeys()
	{
		_ASSERTE(type == PXV::dt_Dictionary);
		if (!p || type != PXV::dt_Dictionary)
			return std::vector<CString>();

		int nKeysCount = 0;
		p->get_Count(&nKeysCount);

		std::vector<CString> vKeys;
		vKeys.reserve(nKeysCount);
		for (int i = 0; i < nKeysCount; i++)
		{
			CComBSTR bsKey;
			p->get_ItemKey(i, &bsKey);
			vKeys.emplace_back(bsKey);
		}

		return vKeys;
	}

	inline _cab_node_t Array_FindItemByID(LPCWSTR pID, int* pIndex = nullptr) const
	{
		if (pIndex)
			*pIndex = 0;
		if (!pID || !pID[0])
			return _cab_node_t();
		PXV::CabDataTypeID dt = type;
		_ASSERTE(dt == PXV::dt_Array);
		if (dt != PXV::dt_Array)
			return _cab_node_t();

		const int cnt = size();
		for (int i = 0; i < cnt; i++)
		{
			_cab_node_t it = at(i);
			if (it.IsNull())
				break;
			_cab_node_t id = it[L"ID"];
			if (id.IsNull())
				continue;
			if (lstrcmpiW((LPCWSTR)id, pID) == 0)
			{
				if (pIndex)
					*pIndex = i;
				return it;
			}
		}
		return _cab_node_t();
	}
};


//Custom methods


static BOOL _GetBool(PXV::ICabNode* pDict, LPCWSTR sName, BOOL bDefValue = FALSE);

static int _GetLong(PXV::ICabNode* pDict, LPCWSTR sName, long long nDefValue = 0);

static double _GetDouble(PXV::ICabNode* pDict, LPCWSTR sName, double nDefValue = 0);

static std::wstring _GetString(PXV::ICabNode* pDict, LPCWSTR sName, LPCWSTR sDefValue = NULL);

static void _SetBool(PXV::ICabNode* pDict, LPCWSTR sName, BOOL bValue);

static void _SetLong(PXV::ICabNode* pDict, LPCWSTR sName, long nValue);

static void _SetDouble(PXV::ICabNode* pDict, LPCWSTR sName, double nValue);

static void _SetString(PXV::ICabNode* pDict, LPCWSTR sName, LPCWSTR pValue);


static std::wstring _GetNameType(PXV::CabDataTypeID dt);
static bool _IsTypeItem(PXV::ICabNode* pDict, const PXV::CabDataTypeID nType[], int nTypeSize);

std::wstring _GetString(PXV::ICabNode* pDict, LPCWSTR sName, LPCWSTR sDefValue)
{
	std::wstring  sValue = sDefValue ? sDefValue : L"";
	if (!pDict || !sName)
		return L"";
	CComBSTR s;
	pDict->GetString((BSTR)sName, (BSTR)sDefValue, &s);
	if ((LPCWSTR)s != nullptr)
		sValue = (LPCWSTR)s;
	return sValue;
}

BOOL _GetBool(PXV::ICabNode* pDict, LPCWSTR sName, BOOL bDefValue)
{
	BOOL bRes = bDefValue;
	if (!pDict || !sName)
		return bRes;
	VARIANT_BOOL v;
	pDict->GetBool((BSTR)sName, -(bDefValue != 0), &v);
	bRes = v != VARIANT_FALSE;
	return bRes;
}

int _GetLong(PXV::ICabNode* pDict, LPCWSTR sName, long long nDefValue)
{
	long long nRes = nDefValue;
	if (!pDict || !sName)
		return static_cast<int>((_int64)nRes);
	pDict->GetInt64((BSTR)sName, nDefValue, &nRes);
	return static_cast<int>((_int64)nRes);
}

double _GetDouble(PXV::ICabNode* pDict, LPCWSTR sName, double nDefValue)
{
	double nRes = nDefValue;
	if (!pDict || !sName)
		return nRes;
	pDict->GetDouble((BSTR)sName, nDefValue, (double*)&nRes);
	return nRes;
}

void _SetBool(PXV::ICabNode* pDict, LPCWSTR sName, BOOL bValue)
{
	if (!pDict || !sName)
		return;
	pDict->SetBool((BSTR)sName, bValue ? VARIANT_TRUE : VARIANT_FALSE);
}

void _SetLong(PXV::ICabNode* pDict, LPCWSTR sName, long nValue)
{
	if (!pDict || !sName)
		return;
	pDict->SetInt64((BSTR)sName, nValue);
}

void _SetDouble(PXV::ICabNode* pDict, LPCWSTR sName, double nValue)
{
	if (!pDict || !sName)
		return;
	pDict->SetDouble((BSTR)sName, nValue);
}

void _SetString(PXV::ICabNode* pDict, LPCWSTR sName, LPCWSTR pValue)
{
	if (!pDict || !sName)
		return;
	pDict->SetString((BSTR)sName, (BSTR)pValue);
}

std::wstring _GetNameType(PXV::CabDataTypeID dt)
{
	static const LPCWSTR strType[] =
	{
		L"dt_Undefined",
		L"dt_Bool",
		L"dt_Int",
		L"dt_Int64",
		L"dt_Double",
		L"dt_String",
		L"dt_Stream",
		L"dt_IUnknown",
		L"dt_Container",
		L"dt_Array",
		L"dt_Dictionary",
	};
	if (dt < PXV::dt_Container)
		return strType[dt];
	else
		return strType[dt - PXV::dt_Container + PXV::dt_IUnknown + 1];
}

bool _IsTypeItem(PXV::ICabNode* pDict, const PXV::CabDataTypeID nType[], int nTypeSize)
{
	_cab_node_t pNode(pDict);
	for (_cab_node_t::_iter pItem = pNode.begin(); pItem < pNode.end(); ++pItem)
	//for (const auto& pItem : pNode)
	{

		for (int i = 0; i < nTypeSize; i++)
		{
			_cab_node_t nodeTmp = pItem;
			if (nodeTmp.GetType() == nType[i])
				return true;
		}
	}
	return false;
}

