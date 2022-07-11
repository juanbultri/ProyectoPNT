using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoGym.Models
{
    public class Rutina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RutinaId { get; set; }

        [Display(Name = "Inicio")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe especificar una fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fin")]
        [DataType(DataType.Date)]
        public DateTime? FechaFin { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Debe escribir una rutina")]
        [StringLength(300,MinimumLength = 10, ErrorMessage = "Debe de tener al menos 10 caracteres y como máximo 300")]
        public String Detalle { get; set; }

        public int UsuarioId { get; set; }
    }
}
