using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullDemo
{
	internal sealed class HResults
	{
		internal const int S_OK = 0;
		internal const int S_FALSE = 1;
		internal const int E_NOTIMPL = unchecked((int)0x80004001);
		internal const int E_POINTER = unchecked((int)0x80004003);
		internal const int E_FAIL = unchecked((int)0x80004005);
		internal const int E_OUTOFMEMORY = unchecked((int)0x8007000E);

		private HResults() { }
	}

}
