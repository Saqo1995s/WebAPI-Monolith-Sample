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
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminsController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        #region RestApi

        // GET: api/admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _adminRepository.GetAll().ConfigureAwait(false);
        }

        // GET: api/admins/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _adminRepository.Get(id).ConfigureAwait(false);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // GET: api/admins/GetAdminByAccountId?id=00000000-0000-0000-0000-000000000000
        [HttpGet("GetAdminByAccountId")]
        public async Task<ActionResult<Admin>> GetAdminByAccountId(Guid id)
        {
            var admin = await _adminRepository.GetAdminByAccountIdAsync(id).ConfigureAwait(false);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // POST: api/admins
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmins(Admin admin)
        {
            if (admin == null)
            {
                return BadRequest(new { message = "Bad Request." });
            }

            try
            {
                await _adminRepository.Add(admin).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                if (EntityExists(admin.Id))
                {
                    return Conflict();
                }

                return Problem(exception.Message);
            }

            return CreatedAtAction("GetAdmins", new { id = admin.Id }, admin);
        }

        // PUT: api/admins/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin adminUpd)
        {
            if (adminUpd == null || id != adminUpd.Id)
            {
                return BadRequest();
            }

            try
            {
                await _adminRepository.Update(adminUpd).ConfigureAwait(false);
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

        // DELETE: api/admins/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdminById(int id)
        {
            var admin = await _adminRepository.Get(id).ConfigureAwait(false);

            if (admin == null)
            {
                return NotFound();
            }

            await _adminRepository.Delete(id).ConfigureAwait(false);

            return Ok();
        }

        #endregion

        #region Private Methods

        private bool EntityExists(int id)
        {
            var entity = _adminRepository.Get(id);

            return entity != null;
        }

        #endregion
    }
}
