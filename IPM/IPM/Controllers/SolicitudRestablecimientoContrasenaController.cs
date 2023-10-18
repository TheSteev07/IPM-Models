namespace IPM.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using IPM.Models;
    using global::IPM.Models;

    namespace IPM.Controllers
    {
        [Route("api/solicitudes-restablecimiento-contrasena")]
        [ApiController]
        public class SolicitudRestablecimientoContrasenaController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public SolicitudRestablecimientoContrasenaController(ApplicationDbContext context)
            {
                _context = context;
            }

            // Acción para crear una nueva solicitud de restablecimiento de contraseña
            [HttpPost]
            public async Task<IActionResult> CrearSolicitudRestablecimiento([FromBody] SolicitudRestablecimientoContrasena solicitud)
            {
                if (solicitud == null)
                {
                    return BadRequest("La solicitud no es válida.");
                }

                // Verificar si el usuario existe
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == solicitud.UsuarioId);
                if (usuario == null)
                {
                    return NotFound("El usuario no existe.");
                }

                // Validar si ya existe una solicitud pendiente para este usuario (puedes ajustar esta lógica según tus requisitos)
                var solicitudExistente = await _context.SolicitudesRestablecimiento
                    .FirstOrDefaultAsync(s => s.UsuarioId == solicitud.UsuarioId && s.Utilizado == false);

                if (solicitudExistente != null)
                {
                    return BadRequest("Ya existe una solicitud de restablecimiento de contraseña pendiente para este usuario.");
                }

                // Establecer la fecha de la solicitud y guardarla en la base de datos
                solicitud.FechaSolicitud = DateTime.Now;
                _context.SolicitudesRestablecimiento.Add(solicitud);
                await _context.SaveChangesAsync();

                // Aquí puedes enviar un correo electrónico al usuario con el enlace para restablecer la contraseña, incluyendo el token

                return Ok("Solicitud de restablecimiento de contraseña creada exitosamente.");
            }

            // Acción para procesar el uso de un token de restablecimiento
            [HttpPost("usar-token")]
            public async Task<IActionResult> UsarTokenRestablecimiento([FromBody] TokenRestablecimientoViewModel model)
            {
                if (model == null)
                {
                    return BadRequest("El modelo no es válido.");
                }

                // Buscar la solicitud correspondiente al token
                var solicitud = await _context.SolicitudesRestablecimiento
                    .FirstOrDefaultAsync(s => s.Token == model.Token && s.Utilizado == false);

                if (solicitud == null)
                {
                    return NotFound("El token no es válido o ha sido utilizado.");
                }

                // Marcar la solicitud como utilizada y guardarla en la base de datos
                solicitud.Utilizado = true;
                solicitud.FechaUtilizado = DateTime.Now;
                _context.SolicitudesRestablecimiento.Update(solicitud);
                await _context.SaveChangesAsync();

                // Aquí puedes redirigir al usuario a la página de restablecimiento de contraseña

                return Ok("Token de restablecimiento de contraseña utilizado con éxito.");
            }
        }
    }

}
