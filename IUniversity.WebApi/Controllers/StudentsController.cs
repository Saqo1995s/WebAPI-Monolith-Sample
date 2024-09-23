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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #region RestApi

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _studentRepository.GetAll().ConfigureAwait(false);
        }

        // GET: api/Students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentRepository.Get(id).ConfigureAwait(false);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // GET: api/Students/GetStudentByAccountId?id=00000000-0000-0000-0000-000000000000
        [HttpGet("GetStudentByAccountId")]
        public async Task<ActionResult<Student>> GetStudentByAccountId(Guid id)
        {
            var student = await _studentRepository.GetStudentByAccountId(id).ConfigureAwait(false);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudents([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(new { message = "Bad Request." });
            }

            try
            {
                await _studentRepository.Add(student).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                if (EntityExists(student.Id))
                {
                    return Conflict();
                }

                return Problem(exception.Message);
            }

            return CreatedAtAction("GetStudents", new { id = student.Id }, student);
        }

        // PUT: api/Students/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student studentUpd)
        {
            if (studentUpd == null || id != studentUpd.Id)
            {
                return BadRequest();
            }

            try
            {
                await _studentRepository.Update(studentUpd).ConfigureAwait(false);
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

        // DELETE: api/Students/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            var student = await _studentRepository.Get(id).ConfigureAwait(false);

            if (student == null)
            {
                return NotFound();
            }

            await _studentRepository.Delete(id).ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Private Methods

        private bool EntityExists(int id)
        {
            var entity = _studentRepository.Get(id);

            return entity != null;
        }

        #endregion

    }
}