using System.Collections.Generic;
using System.Threading.Tasks;
using IUniversity.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IUniversity.Core.Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace IUniversity.WebApi.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class CourseAssignmentsController : ControllerBase
    {
        private readonly ICourseAssignmentRepository _courseAssignmentRepository;

        public CourseAssignmentsController(ICourseAssignmentRepository courseAssignmentRepository)
        {
            _courseAssignmentRepository = courseAssignmentRepository;
        }

        #region RestApi

        // GET: api/CourseAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseAssignment>>> GetCourseAssignments()
        {
            return await _courseAssignmentRepository.GetAll().ConfigureAwait(false);
        }

        // GET: api/CourseAssignments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseAssignment>> GetCourseAssignmentById(int id)
        {
            var courseAssignment = await _courseAssignmentRepository.Get(id).ConfigureAwait(false);

            if (courseAssignment == null)
            {
                return NotFound();
            }

            return courseAssignment;
        }

        // POST: api/CourseAssignments
        [HttpPost]
        public async Task<ActionResult<CourseAssignment>> PostCourseAssignments([FromBody] CourseAssignment courseAssignment)
        {
            if (courseAssignment == null)
            {
                return BadRequest(new { message = "Bad Request." });
            }

            try
            {
                await _courseAssignmentRepository.Add(courseAssignment).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                if (EntityExists(courseAssignment.Id))
                {
                    return Conflict();
                }

                return Problem(exception.Message);
            }

            return CreatedAtAction("GetCourseAssignments", new { id = courseAssignment.Id }, courseAssignment);
        }

        // PUT: api/CourseAssignments/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseAssignment(int id, [FromBody] CourseAssignment courseAssignmentUpd)
        {
            if (courseAssignmentUpd == null || id != courseAssignmentUpd.Id)
            {
                return BadRequest();
            }

            try
            {
                await _courseAssignmentRepository.Update(courseAssignmentUpd).ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }

                return Problem(exception.Message);
            }

            return NoContent();
        }

        // DELETE: api/CourseAssignments/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseAssignment>> DeleteCourseAssignmentById(int id)
        {
            var courseAssignment = await _courseAssignmentRepository.Get(id).ConfigureAwait(false);

            if (courseAssignment == null)
            {
                return NotFound();
            }

            await _courseAssignmentRepository.Delete(id).ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Private Methods

        private bool EntityExists(int id)
        {
            var entity = _courseAssignmentRepository.Get(id);

            return entity != null;
        }

        #endregion
    }
}
