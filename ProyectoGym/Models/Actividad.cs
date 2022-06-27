using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoGym.Models
{
    public class Actividad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        [EnumDataType(typeof(Dias))]
        public Dias Dia { get; set; }

        public string Hora { get; set; }

        public int Duracion { get; set; }

    }
}