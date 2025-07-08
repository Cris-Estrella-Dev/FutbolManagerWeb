using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolManagerWeb.Models
{
    public class Jugador
    {
        [Key]
        public int JugadorId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Range(1, 99, ErrorMessage = "El dorsal debe estar entre 1 y 99.")]
        public int Dorsal { get; set; }

        [Range(16, 60, ErrorMessage = "La edad debe ser entre 16 y 60.")]
        public int Edad { get; set; }

        // Llave foránea a Equipo (igual que antes)
        [Required]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; } = null!;

        // ——— Aquí lo cambiamos ———
        // Ya no hay PosicionId ni ForeignKey ni entidad Posicion
        
    }
}
