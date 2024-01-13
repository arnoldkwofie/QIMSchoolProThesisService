using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
	public class Party : AuditableAutoEntity
	{
		public bool? IsDisability { get; private set; }
		public string DisabilityReason { get; private set; }
		public DateTime? DateOfBirth { get; private set; }
		public MaritalStatus? MaritalStatus { get; private set; }
		public string PlaceOfBirth { get; set; }
		public PartyType PartyType { get; private set; }
		public Name Name { get; set; }
		public EmailAddressValueType PrimaryEmailAddress { get; private set; }
		//public EmailAddressValueType OtherEmailAddress { get; private set; }

		//public PhoneNumberValueType PrimaryPhoneNumber { get; private set; }
		//public PhoneNumberValueType OtherPhoneNumber { get; private set; }
		public string FaxNumber { get; private set; }

		//public AddressLine AddressLine { get; private set; }
		//public virtual ICollection<Student> Students { get; set; }
		//public virtual ICollection<Applicant> Applicants { get; set; }

		public virtual ICollection<Staff> Staffs { get; set; }
		public Party()
		{
		}

		//private Party(Name name, DateTime dateOfBirth, MaritalStatus maritalStatus)
		//{
		//	Name = name;
		//	MaritalStatus = maritalStatus;
		//	DateOfBirth = dateOfBirth;
		//}



		//private Party(Name name, MaritalStatus maritalStatus)
		//{
		//	Name = name;
		//	MaritalStatus = maritalStatus;
		//}

		//private Party(Name name)
		//{
		//	Name = name;
		//}

		//private Party(Name name, DateTime dateOfBirth)
		//{
		//	Name = name;
		//	DateOfBirth = dateOfBirth;
		//	//CheckRule(new ProvidedDateOfBirthMustBeRule(dateOfBirth));

		//}

		//public static Party Create(Sex sex)
		//{
		//	return new Party();
		//}
		//public static Party Create(Name name)
		//{
		//	return new Party(name);
		//}
		//public static Party Create(Name name, DateTime dateOfBirth)
		//{
		//	return new Party(name, dateOfBirth);
		//}
		//public static Party Create(Name name, MaritalStatus maritalStatus)
		//{
		//	return new Party(name, maritalStatus);

		//}
		//public static Party Create(Name name,
		//		   DateTime dateOfBirth,
		//		   MaritalStatus maritalStatus)
		//{
		//	return new Party(name, dateOfBirth, maritalStatus);
		//}


		//public Party Of(PartyType type)
		//{
		//	PartyType = type;
		//	return this;
		//}



		//public Party WithPrimaryEmail(string email)
		//{
		//	PrimaryEmailAddress = EmailAddressValueType.Create(email, EmailType.Primary);
		//	return this;
		//}
		//public Party WithMaritalStatus(MaritalStatus maritalStatus)
		//{
		//	MaritalStatus = maritalStatus;
		//	return this;
		//}

		//public Party WithSecondaryEmail(string email)
		//{
		//	OtherEmailAddress = EmailAddressValueType.Create(email, EmailType.Other);
		//	return this;
		//}
		//public Party WithPrimaryPhone(string phone)
		//{
		//	PrimaryPhoneNumber = PhoneNumberValueType.Create(phone, PhoneNumberType.Primary);
		//	return this;
		//}
		//public Party WithSecondaryPhone(string phone)
		//{
		//	OtherPhoneNumber = PhoneNumberValueType.Create(phone, PhoneNumberType.Primary);
		//	return this;
		//}
		//public Party WithDateOfBirth(DateTime? dateOfBirth)
		//{
		//	DateOfBirth = dateOfBirth;
		//	return this;
		//}
		//public Party WithPlaceOfBirth(string placeOfBirth)
		//{
		//	PlaceOfBirth = placeOfBirth;
		//	return this;
		//}
		//public Party WithFaxNumber(string faxNumber)
		//{
		//	FaxNumber = faxNumber;
		//	return this;
		//}

		//public IReadOnlyList<IdentificationCard> IdentificationCards => _identificationCards.AsReadOnly();


		//#region ReadOnlyList




		//private readonly List<IdentificationCard> _identificationCards = new List<IdentificationCard>();
		//public void AddIdentificationCard(IdentificationCard identificationCard)
		//{
		//	_identificationCards.Add(identificationCard);
		//}




	}
}
