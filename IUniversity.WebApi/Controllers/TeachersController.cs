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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        #region RestApi

        // GET: api/teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teachers = await _teacherRepository.GetAll().ConfigureAwait(false);
            return teachers;
        }

        // GET: api/teachers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.Get(id).ConfigureAwait(false);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // GET: api/teachers/GetTeacherByAccountId?id=00000000-0000-0000-0000-000000000000
        [HttpGet("GetTeacherByAccountId")]
        public async Task<ActionResult<Teacher>> GetTeacherByAccountId(Guid id)
        {
            var teacher = await _teacherRepository.GetTeacherByAccountId(id).ConfigureAwait(false);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // POST: api/teachers
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher([FromBody]Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest(new { message = "Bad Request." });
            }

            try
            {
                await _teacherRepository.Add(teacher).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                if (EntityExists(teacher.Id))
                {
                    return Conflict();
                }

                return Problem(exception.Message);
            }

            return CreatedAtAction("GetTeachers", new { id = teacher.Id }, teacher);
        }

        // PUT: api/teachers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Putteacher(int id, Teacher teacherUpd)
        {
            if (teacherUpd == null || id != teacherUpd.Id)
            {
                return BadRequest();
            }

            try
            {
                await _teacherRepository.Update(teacherUpd).ConfigureAwait(false);
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

        // DELETE: api/teachers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacherById(int id)
        {
            var teacher = await _teacherRepository.Get(id).ConfigureAwait(false);

            if (teacher == null)
            {
                return NotFound();
            }

            await _teacherRepository.Delete(id).ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Private Methods

        private bool EntityExists(int id)
        {
            var entity = _teacherRepository.Get(id);

            return entity != null;
        }

        #endregion
    }
}
