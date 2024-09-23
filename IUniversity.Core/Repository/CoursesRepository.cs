using System;
using System.Linq;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using IUniversity.Core.Repository.Base;
using IUniversity.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository
{
    public class CoursesRepository : BaseRepository<Course, CoreDbContext>, ICourseRepository
    {
        private readonly ICourseAssignmentRepository _courseAssignmentRepository;

        public CoursesRepository(CoreDbContext context, ICourseAssignmentRepository courseAssignmentRepository, ITeacherRepository teacherRepository)
            : base(context)
        {
            _courseAssignmentRepository = courseAssignmentRepository;

            //Add here your custom requests for "Course" entity using LINQ
        }

        private async Task<Course[]> GetCoursesByIdAsync(int[] ids)
        {
            var coursesQueryable = Context.Courses.Where(x => ids.Contains(x.Id));

            if (coursesQueryable.Any())
            {
                var coursesArr = await coursesQueryable.ToArrayAsync();
                return coursesArr;
            }

            return null;
        }

        public async Task<Course[]> GetCoursesByGroup(string group)
        {
            var courseAssignments = await _courseAssignmentRepository.GetCourseAssignmentsByGroupAsync(group).ConfigureAwait(false);
            var courseIds = courseAssignments
                .Select(x => x.Id)
                .ToArray();

            var courses = await GetCoursesByIdAsync(courseIds);

            return courses;
        }
    }
}
