using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.ValueObjects
{
	public class Email : ValueObjectType
	{
		public EmailType EmailType { get; private set; }

		public string Value { get; private set; }

		private Email() { }
		//private Email(string value, EmailType type)
		//{
		//	Value = value;
		//	EmailType = type;
		//	CheckRule(new EmailMustBeValidRule(value));
		//}
		//public Email WithEmail(string email)
		//{
		//	Value = email;
		//	return this;
		//}
		//public static Email Create(string email, EmailType type = EmailType.Other) => new Email(email, type);



		//public static implicit operator string(Email email)
		//{
		//	return email.Value;
		//}
	}
}
