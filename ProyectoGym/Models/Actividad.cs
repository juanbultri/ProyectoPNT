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

        [Required(ErrorMessage = "Debe especificar un nombre")]
        public string Nombre { get; set; }

        [EnumDataType(typeof(Dias))]
        [Required(ErrorMessage = "Debe especificar el día de la actividad")]
        public Dias Dia { get; set; }

        [Required(ErrorMessage = "Debe especificar la hora")]
        [DataType(DataType.Time)]
        public string Hora { get; set; }

        [Required(ErrorMessage = "Debe especificar la duración")]
        public int Duracion { get; set; }

    }
}