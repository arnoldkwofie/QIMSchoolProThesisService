using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public ILogger<Student> Logger { get; }

        public StudentRepository(ThesisDbContext context, ILogger<Student> logger): base(context)
        {
            Logger = logger;
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            //var data = await GetBaseQuery().Where(a => a.Party.PrimaryEmailAddress.Email.Value == email).FirstOrDefaultAsync();
            var data = await GetBaseQuery().Where(a => a.StudentNumber == email).FirstOrDefaultAsync();
            return data;
         }

        //public async Task<Student> GetStudentByStud(string email)
        //{
        //    var data = await GetBaseQuery().Where(a => a.Party.PrimaryEmailAddress.Email.Value == email).FirstOrDefaultAsync();
        //    return data;
        //}
        public override IQueryable<Student> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(a=>a.Programme).ThenInclude(a=>a.Department)
                .Include(a=>a.Party);
               

        }

    }
}
