using System;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Base;
using IUniversity.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository
{
    public class TeachersRepository : BaseRepository<Teacher, CoreDbContext>, ITeacherRepository
    {
        public TeachersRepository(CoreDbContext context)
            : base(context)
        {
            //Add here your custom requests for "Student" entity using LINQ
        }

        public async Task<Teacher> GetTeacherByAccountId(Guid id)
        {
            var teacher = await Context.Teachers.FirstOrDefaultAsync(x => x.AccountId.Equals(id));

            return teacher;
        }
    }
}