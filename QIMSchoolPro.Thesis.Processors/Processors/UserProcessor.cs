using Qface.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class UserProcessor
    {
        private readonly IIdentityService _identityService;
        private readonly StaffProcessor _staffProcessor;
        private readonly StudentProcessor _studentProcessor;

        public UserProcessor(
            IIdentityService identityService,
            StaffProcessor staffProcessor,
            StudentProcessor studentProcessor
            )
        {
            _identityService = identityService;
            _staffProcessor = staffProcessor;
            _studentProcessor = studentProcessor;
        }



        public async Task<UserViewModel> GetLoginUser()
        {
            var user = new UserViewModel();

            
                var uid = _identityService.GetUserName();
                var staff = await _staffProcessor.GetStaffByEmail(uid);
                if (staff == null)
                {

                    //var refNo = _identityService.GetUserName();
                    var student = await _studentProcessor.GetStudentByNumber(uid);
                    if (student == null) return user;
                    //user.Name = student.Party.Name.FullNamev3;
                    user.FirstName = student.Party.Name.FirstName;
                    user.LastName = student.Party.Name.LastName;
                    user.OtherName = student.Party.Name.OtherName;
                    //user.Email = student.Party?.PrimaryEmailAddress?.Email.Value;
                    user.No = student.StudentNumber;
                    //user.PhotoUrl = student.PhotoUrl;
                    user.Department = student.Programme.Department?.Name;
                    //user.Campus = student.Programme.Department?.Faculty.SchoolCentre.Campus.Name;
                    //user.ShowModuleRegistration = student.Programme.Certificate.Code.ToLower() != "bsc" && student.Programme.Certificate.Code.ToLower() != "diploma in"
                    //                                && student.Programme.Certificate.Code.ToLower() != "certificate in";
                    user.YearGroup = student.YearGroup.ClassYear;
                }
                else
                {
                    //user.Name = staff.Party.Name.FullNamev3;
                    user.FirstName = staff.Party.Name.FirstName;
                    user.LastName = staff.Party.Name.LastName;
                    user.OtherName = staff.Party.Name.OtherName;
                    user.No = staff.StaffNumber;
                    //user.PhotoUrl = staff.PhotoUrl;
                    //user.Department = staff.Department?.Name;
                    //user.Campus = staff.Department?.Faculty.SchoolCentre.Campus.Name;
                    //user.Email = staff.Party?.PrimaryEmailAddress?.Email.Value;
                }
                
                return user;


            }
    }


    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string No { get; set; }
        public string PhotoUrl { get; set; }
        public string Department { get; set; }
        public string Campus { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool ShowModuleRegistration { get; set; }
        public int YearGroup { get; set; }
    }
}
