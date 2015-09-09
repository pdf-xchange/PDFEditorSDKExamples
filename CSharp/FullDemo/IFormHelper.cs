using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullDemo
{
	interface IFormHelper
	{
		bool IsValid();
		void OnUpdate();
		void OnSerialize(PDFXEdit.IOperation dest);
	}
}
