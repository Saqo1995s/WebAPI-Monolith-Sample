using System;
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
    public class TeacherAssignmentsController : ControllerBase
    {
        private readonly ITeacherAssignmentRepository _teacherAssignmentRepository;

        public TeacherAssignmentsController(ITeacherAssignmentRepository teacherAssignmentRepository)
        {
            _teacherAssignmentRepository = teacherAssignmentRepository;
        }

        #region RestApi

        // GET: api/TeacherAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherAssignment>>> GetTeacherAssignments()
        {
            return await _teacherAssignmentRepository.GetAll().ConfigureAwait(false);
        }

        // GET: api/TeacherAssignments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherAssignment>> GetTeacherAssignmentById(int id)
        {
            var teacherAssignment = await _teacherAssignmentRepository.Get(id).ConfigureAwait(false);

            if (teacherAssignment == null)
            {
                return NotFound();
            }

            return teacherAssignment;
        }

        // GET: api/TeacherAssignments/GetTeacherAssignmentsByTeacherId?id={id}
        [HttpGet("GetTeacherAssignmentsByTeacherId")]
        public async Task<ActionResult<TeacherAssignment[]>> GetTeacherAssignmentsByTeacherId(int id)
        {
            var teacherAssignments = await  _teacherAssignmentRepository.GetTeacherAssignmentsByTeacherId(id).ConfigureAwait(false);

            if (teacherAssignments == null)
            {
                return NotFound();
            }

            return teacherAssignments;
        }

        // POST: api/TeacherAssignments
        [HttpPost]
        public async Task<ActionResult<TeacherAssignment>> PostTeacherAssignment([FromBody] TeacherAssignment teacherAssignment)
        {
            if (teacherAssignment == null)
            {
                return BadRequest(new { message = "Bad Request." });
            }

            try
            {
                await _teacherAssignmentRepository.Add(teacherAssignment).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                if (EntityExists(teacherAssignment.Id))
                {
                    return Conflict();
                }

                return Problem(exception.Message);
            }

            return CreatedAtAction("GetTeacherAssignments", new { id = teacherAssignment.Id }, teacherAssignment);
        }

        // PUT: api/TeacherAssignments/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherAssignment(int id, TeacherAssignment teacherAssignmentUpd)
        {
            if (teacherAssignmentUpd == null || id != teacherAssignmentUpd.Id)
            {
                return BadRequest();
            }

            try
            {
                await _teacherAssignmentRepository.Update(teacherAssignmentUpd).ConfigureAwait(false);
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

        // DELETE: api/TeacherAssignments/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherAssignment>> DeleteTeacherAssignmentById(int id)
        {
            var teacherAssignment = await _teacherAssignmentRepository.Get(id).ConfigureAwait(false);

            if (teacherAssignment == null)
            {
                return NotFound();
            }

            await _teacherAssignmentRepository.Delete(id).ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Private Methods

        private bool EntityExists(int id)
        {
            var entity = _teacherAssignmentRepository.Get(id);

            return entity != null;
        }

        #endregion

    }
}