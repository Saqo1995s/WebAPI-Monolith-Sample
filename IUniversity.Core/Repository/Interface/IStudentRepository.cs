using System;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Interface.Base;

namespace IUniversity.Core.Repository.Interface
{
    public interface IStudentRepository : IBaseRepository<Student, CoreDbContext>
    {
        public Task<Student> GetStudentByAccountId(Guid id);
    }
}