namespace IPM.Models
{
    public class Permiso
    {
        public int PermisoId { get; set; }
        public string? Nombre { get; set; }

        // Relación con Roles a través de la tabla de asignación RolPermiso
        public ICollection<RolPermiso>? RolesPermisos { get; set; }
    }
}