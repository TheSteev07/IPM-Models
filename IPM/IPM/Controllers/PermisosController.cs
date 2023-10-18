using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using IPM.Models;

namespace IPM.Controllers
{
    [Route("api/permisos")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly RoleManager<Permiso> _permisoManager;

        public PermisosController(RoleManager<Permiso> permisoManager)
        {
            _permisoManager = permisoManager;
        }

        // GET: api/permisos
        [HttpGet]
        public IActionResult GetPermisos()
        {
            var permisos = _permisoManager.Roles.ToList();
            return Ok(permisos);
        }

        // GET: api/permisos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermiso(string id)
        {
            var permiso = await _permisoManager.FindByIdAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(permiso);
        }

        // POST: api/permisos
        [HttpPost]
        public async Task<IActionResult> PostPermiso([FromBody] Permiso permiso)
        {
            var result = await _permisoManager.CreateAsync(permiso);

            if (result.Succeeded)
            {
                return CreatedAtAction("GetPermiso", new { id = permiso.PermisoId }, permiso);
            }

            return BadRequest(result.Errors);
        }

        // PUT: api/permisos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermiso(int id, [FromBody] Permiso permiso)
        {
            if (id != permiso.PermisoId)
            {
                return BadRequest();
            }

            var result = await _permisoManager.UpdateAsync(permiso);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }

        // DELETE: api/permisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermiso(string id)
        {
            var permiso = await _permisoManager.FindByIdAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            var result = await _permisoManager.DeleteAsync(permiso);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }
    }
}
