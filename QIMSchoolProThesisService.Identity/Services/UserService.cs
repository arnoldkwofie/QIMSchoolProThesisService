using Microsoft.AspNetCore.Identity;
using QIMSchoolPro.Thesis.Application.Contracts.Identity;
using QIMSchoolPro.Thesis.Application.Models.Identity;
using QIMSchoolProThesisService.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolProThesisService.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Student> GetStudent(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Student
            {
                Email = employee.Email,
                Id = employee.Id,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            };
        }

        public async Task<List<Student>> GetStudents()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Student
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }
    }
}
