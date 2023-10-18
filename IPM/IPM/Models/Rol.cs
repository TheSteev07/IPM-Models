namespace IPM.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        public string? Nombre { get; set; }

        // Relación con Usuarios
        public ICollection<Usuarios>? Usuarios { get; set; }

        // Relación con Permisos a través de la tabla de asignación RolPermiso
        public ICollection<RolPermiso>? RolesPermisos { get; set; }
    }
}