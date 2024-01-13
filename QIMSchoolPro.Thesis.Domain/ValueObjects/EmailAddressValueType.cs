using Qface.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.ValueObjects
{
	public class EmailAddressValueType : ValueObjectType
	{
		public Email Email { get; private set; }

		//private EmailAddressValueType() { } //For EF Core

		//private EmailAddressValueType(Email email)
		//{
		//	Email = email;
		//}

		//public static EmailAddressValueType Create(string email, EmailType type)
		//{
		//	return new EmailAddressValueType(Email.Create(email, type));
		//}


	}
}
