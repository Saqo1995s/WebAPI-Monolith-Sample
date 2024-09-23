using System;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Interface.Base;

namespace IUniversity.Core.Repository.Interface
{
    public interface ITeacherRepository : IBaseRepository<Teacher, CoreDbContext>
    {
        public Task<Teacher> GetTeacherByAccountId(Guid id);
    }
}