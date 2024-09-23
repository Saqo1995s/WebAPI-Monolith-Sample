using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Interface.Base;

namespace IUniversity.Core.Repository.Interface
{
    public interface ICourseAssignmentRepository : IBaseRepository<CourseAssignment, CoreDbContext>
    {
        public Task<CourseAssignment[]> GetCourseAssignmentsByGroupAsync(string group);
    }
}