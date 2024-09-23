using System;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Common.Models.Base;
using IUniversity.Core.Repository.Base;
using IUniversity.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository
{
    public class AdminsRepository : BaseRepository<Admin, CoreDbContext>, IAdminRepository
    {
        public AdminsRepository(CoreDbContext context)
            : base(context)
        {
            //Add here your custom requests for "Admins" entity using LINQ
        }

        public async Task<Admin> GetAdminByAccountIdAsync(Guid id)
        {
            var admin = await Context.Admins.FirstOrDefaultAsync(x => x.AccountId.Equals(id));

            return admin;
        }
    }
}