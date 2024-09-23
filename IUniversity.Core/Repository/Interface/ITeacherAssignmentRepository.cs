using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Interface.Base;

namespace IUniversity.Core.Repository.Interface
{
    public interface ITeacherAssignmentRepository : IBaseRepository<TeacherAssignment, CoreDbContext>
    {
        public Task<TeacherAssignment[]> GetTeacherAssignmentsByTeacherId(int teacherId);
    }
}