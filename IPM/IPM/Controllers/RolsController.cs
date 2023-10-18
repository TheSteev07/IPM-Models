using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using IPM.Models;

namespace IPM.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<Rol> _roleManager;

        public RolesController(RoleManager<Rol> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: api/roles
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(string id)
        {
            var rol = await _roleManager.FindByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // POST: api/roles
        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] Rol rol)
        {
            var result = await _roleManager.CreateAsync(rol);

            if (result.Succeeded)
            {
                return CreatedAtAction("GetRol", new { id = rol.RolId }, rol);
            }

            return BadRequest(result.Errors);
        }

        // PUT: api/roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, [FromBody] Rol rol)
        {
            if (id != rol.RolId)
            {
                return BadRequest();
            }

            var result = await _roleManager.UpdateAsync(rol);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(string id)
        {
            var rol = await _roleManager.FindByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(rol);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }
    }
}
