using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FutbolManagerWeb.Models
{
    public class Equipo
    {
        [Key]
        public int EquipoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        // Relación uno-a-muchos: un equipo tiene muchos jugadores
        public ICollection<Jugador> Jugadores { get; set; }
    }
}
