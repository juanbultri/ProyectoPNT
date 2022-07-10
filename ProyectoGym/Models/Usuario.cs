using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoGym.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe especificar un nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Debe especificar un apellido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Debe especificar un nombre de usuario")]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debe especificar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Debe especificar un tipo de perfil")]
        [EnumDataType(typeof(Perfil))]
        public Perfil Perfil { get; set; }

        [EnumDataType(typeof(Plan))]
        public Plan? Plan { get; set; }
    }
}