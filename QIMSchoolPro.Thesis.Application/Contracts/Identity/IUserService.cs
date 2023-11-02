using QIMSchoolPro.Thesis.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(string userId);
    }
}
