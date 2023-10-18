namespace IPM.Models
{
    public class RolPermiso 
    {
        public int RolPermisoId { get; set; }

        // Clave foránea para Rol
        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        // Clave foránea para Permiso
        public int PermisoId { get; set; }
        public Permiso? Permiso { get; set; }
    }
}