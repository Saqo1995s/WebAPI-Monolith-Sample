using System;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Base;
using IUniversity.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository
{
    public class StudentsRepository : BaseRepository<Student, CoreDbContext>, IStudentRepository
    {
        public StudentsRepository(CoreDbContext context) 
            : base(context)
        {
            //Add here your custom requests for "Student" entity using LINQ
        }

        public async Task<Student> GetStudentByAccountId(Guid id)
        {
            var student = await Context.Students.FirstOrDefaultAsync(x => x.AccountId.Equals(id));

            return student;
        }
    }
}