using System.Collections.Generic;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IUniversity.Core.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace IUniversity.WebApi.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        #region RestApi

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseRepository.GetAll().ConfigureAwait(false);

            return courses;
        }

        // GET: api/courses/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseRepository.Get(id).ConfigureAwait(false);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // GET: api/courses/GetCoursesByGroup?group="group"
        [HttpGet("GetCoursesByGroup")]
        public async Task<ActionResult<Course[]>> GetCoursesByGroup(string group)
        {
            var course = await _courseRepository.GetCoursesByGroup(group).ConfigureAwait(false);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourses([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest(new { message = "Bad Request." });
            }

            try
            {
                await _courseRepository.Add(course).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                if (EntityExists(course.Id))
                {
                    return Conflict();
                }

                return Problem(exception.Message);
            }

            return CreatedAtAction("GetCourses", new { id = course.Id }, course);
        }

        // PUT: api/courses/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse([FromRoute] int id, [FromBody] Course courseUpd)
        {
            if (courseUpd == null || id != courseUpd.Id)
            {
                return BadRequest();
            }

            try
            {
                await _courseRepository.Update(courseUpd).ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }

                return Problem(exception.Message);
            }

            return Ok();
        }

        // DELETE: api/courses/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourseById(int id)
        {
            var course = await _courseRepository.Get(id).ConfigureAwait(false);

            if (course == null)
            {
                return NotFound();
            }

            await _courseRepository.Delete(id).ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Private Methods

        private bool EntityExists(int id)
        {
            var entity = _courseRepository.Get(id);

            return entity != null;
        }

        #endregion
    }
}
