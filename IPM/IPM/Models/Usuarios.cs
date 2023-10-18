namespace IPM.Models
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; } 

        // Relación con Roles
        public ICollection<Rol>? Roles { get; set; }

        public List<SolicitudRestablecimientoContrasena>? SolicitudesRestablecimiento { get; set; }

    } 
}
