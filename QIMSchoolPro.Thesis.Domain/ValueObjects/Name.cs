using Qface.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.ValueObjects
{
	public class Name : ValueObjectType
	{
		

		//public Sex Sex { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string OtherName { get; set; }

	}

	}
