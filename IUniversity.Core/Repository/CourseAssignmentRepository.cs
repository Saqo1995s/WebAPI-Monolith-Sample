using System.Linq;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Base;
using IUniversity.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository
{
    public class CourseAssignmentRepository : BaseRepository<CourseAssignment, CoreDbContext>, ICourseAssignmentRepository
    {
        public CourseAssignmentRepository(CoreDbContext context)
            : base(context)
        {
            //Add here your custom requests for "CourseAssignment" entity using LINQ
        }


        public async Task<CourseAssignment[]> GetCourseAssignmentsByGroupAsync(string group)
        {
            var courseAssignmentsQueryable = Context.CourseAssignments.Where(x => x.Group.Equals(group));

            if (courseAssignmentsQueryable.Any())
            {
                var courseAssignmentsArr = await courseAssignmentsQueryable.ToArrayAsync();
                return courseAssignmentsArr;
            }

            return null;
        }
    }
}
