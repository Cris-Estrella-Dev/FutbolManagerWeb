using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolManagerWeb.Models
{
    public enum FrecuenciaPago
    {
        Mensual,
        Quincenal,
        Anual
    }

    public class Contrato
    {
        [Key]
        public int ContratoId { get; set; }

        [Required]
        [Display(Name = "Jugador")]
        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Fin")]
        public DateTime FechaFin { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Monto de la Cuota")]
        public decimal MontoCuota { get; set; }

        [Required]
        [Display(Name = "Frecuencia de Pago")]
        public FrecuenciaPago Frecuencia { get; set; }

        [NotMapped]
        public string Estado =>
            FechaFin < DateTime.Today ? "Expirado" : "Activo";
    }
}
