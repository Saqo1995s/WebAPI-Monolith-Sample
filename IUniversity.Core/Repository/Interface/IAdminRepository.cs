using IUniversity.Common.Models;
using IUniversity.Core.Repository.Interface.Base;
using System;
using System.Threading.Tasks;

namespace IUniversity.Core.Repository.Interface
{
    public interface IAdminRepository : IBaseRepository<Admin, CoreDbContext>
    {
        public Task<Admin> GetAdminByAccountIdAsync(Guid id);
    }
}