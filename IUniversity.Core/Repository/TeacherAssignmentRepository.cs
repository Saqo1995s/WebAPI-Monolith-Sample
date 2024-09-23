using System.Linq;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Base;
using IUniversity.Core.Repository.Interface;

namespace IUniversity.Core.Repository
{
    public class TeacherAssignmentRepository : BaseRepository<TeacherAssignment, CoreDbContext>, ITeacherAssignmentRepository
    {
        public TeacherAssignmentRepository(CoreDbContext context) : base(context)
        {
        }

        public Task<TeacherAssignment[]> GetTeacherAssignmentsByTeacherId(int teacherId)
        {
            var teacherAssignments = Context.TeacherAssignments
                .Where(x => x.TeacherId.Equals(teacherId))
                .ToArray();

            return Task.FromResult(teacherAssignments);
        }
    }
}