using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Interface.Base;

namespace IUniversity.Core.Repository.Interface
{
    public interface ICourseRepository : IBaseRepository<Course, CoreDbContext>
    {
        public Task<Course[]> GetCoursesByGroup(string group);
    }
}