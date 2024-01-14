using Qface.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
	public class Staff : AuditableAutoEntity
	{
		public string StaffNumber { get; private set; }
		public string ProfileUrl { get; private set; }
		public int DepartmentId { get; private set; }
		//public Department Department { get; private set; }
		//public StaffCategory StaffCategory { get; private set; }
		public Party Party { get; set; }
		public int PartyId { get; set; }



		//public Staff WithParty(Party party)
		//{
		//	Party = party;
		//	return this;
		//}
		public Staff() { }//For EF



		//private Staff(Party party, string staffNo)
		//{
		//	Party = party;
		//	StaffNumber = staffNo;
		//}


		public static Staff Empty()
		{
			throw new System.Exception("Please Link user to staff");

		}
		//public static Staff Create(Party party, string staffNo)
		//{
		//	return new Staff(party, staffNo);
		//}


		//public Staff WithDepartmentId(int departmentId)
		//{
		//	DepartmentId = departmentId;
		//	return this;
		//}
		//public Staff WithStaffNo(string staffNo)
		//{
		//	StaffNumber = staffNo;
		//	return this;
		//}

		//public Staff WithProfileUrl(string photoUrl)
		//{
		//	ProfileUrl = photoUrl;
		//	return this;
		//}

		//public Staff WithStaffCategory(StaffCategory staffCategory)
		//{
		//	StaffCategory = staffCategory;
		//	return this;
		//}
	}

}
