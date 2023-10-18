using IPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPM.Controllers
{
    [Route("api/rolpermisos")]
    [ApiController]
    public class RolPermisosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolPermisosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/rolpermisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolPermiso>>> GetRolPermisos()
        {
            return await _context.RolesPermisos.ToListAsync();
        }

        // GET: api/rolpermisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolPermiso>> GetRolPermiso(int id)
        {
            var rolPermiso = await _context.RolesPermisos.FindAsync(id);

            if (rolPermiso == null)
            {
                return NotFound();
            }

            return rolPermiso;
        }

        // POST: api/rolpermisos
        [HttpPost]
        public async Task<ActionResult<RolPermiso>> PostRolPermiso([FromBody] RolPermiso rolPermiso)
        {
            _context.RolesPermisos.Add(rolPermiso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolPermiso", new { id = rolPermiso.RolPermisoId }, rolPermiso);
        }

        // PUT: api/rolpermisos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolPermiso(int id, [FromBody] RolPermiso rolPermiso)
        {
            if (id != rolPermiso.RolPermisoId)
            {
                return BadRequest();
            }

            _context.Entry(rolPermiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RolesPermisos.Any(e => e.RolPermisoId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/rolpermisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolPermiso(int id)
        {
            var rolPermiso = await _context.RolesPermisos.FindAsync(id);

            if (rolPermiso == null)
            {
                return NotFound();
            }

            _context.RolesPermisos.Remove(rolPermiso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
