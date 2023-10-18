using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPM.Models
{
    public class SolicitudRestablecimientoContrasena
    {
        [Key]
        public int SolicitudRestablecimientoContraseñaId { get; set; }

        [Required]
        public string? UsuarioId { get; set; }

        [Required]
        public string? Token { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        [Required]
        public bool Utilizado { get; set; }

        [Required]
        public DateTime? FechaUtilizado { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? Usuario { get; set; }
    }

}
