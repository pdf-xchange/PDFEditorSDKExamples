#pragma once

// Exit macros
#define BreakFunction()							{ break; }

#define E_CANCELLED								HRESULT_FROM_WIN32(ERROR_CANCELLED)

#define USER_CANCEL								E_CANCELLED

#define IS_ERR_Cancel(x)						(USER_CANCEL == x)
#define IS_ERR_S_FALSE(x)						(S_FALSE == x)

#define BreakOnFailure0(x)						if (FAILED(x)) { BreakFunction(); }
#define BreakOnFailureOrUserChoise(x)			if (FAILED(x)  || IS_ERR_Cancel(x)) { BreakFunction(); }

#define ReturnOnFailure0(x)						if (FAILED(x)) { return x; }
#define ReturnOnFailureOrUserChoise(x)			if (FAILED(x)  || IS_ERR_Cancel(x)) { return x; }

#define BreakFunction()							{ break; }
#define DS_ExitTrace DU_TraceError
#define DU_TraceError(f, ...)
#define BreakOnFailure(x, f, ...)				if (FAILED(x)) { DS_ExitTrace(x, f, __VA_ARGS__);  BreakFunction(); }

#define __STR2__(x) #x
#define __STR1__(x) __STR2__(x)
#define __LOC__ __FILE__ "("__STR1__(__LINE__)") : "
#define NOTE( x ) message( x )  
#define FILE_LINE message( __LOC__ )  
#define TODO( x ) message( __LOC__"\n" \
 "-------------------------------------------------\n" \
 "| TODO : " #x "\n" \
 "--------------------------------------------------\n" )  
#define FIXME( x ) message( __LOC__"\n" \
 "-------------------------------------------------\n" \
 "| FIXME : " #x "\n" \
 "--------------------------------------------------\n" )  
#define todo( x ) message( __LOC__"ToDo : " #x)  
#define fixme( x ) message( __LOC__"FixMe : " #x)  
#define note( x ) message( __LOC__"Note : " #x)
