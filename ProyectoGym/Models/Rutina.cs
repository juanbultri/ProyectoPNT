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

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public String Detalle { get; set; }

        public int UsuarioId { get; set; }
    }
}
