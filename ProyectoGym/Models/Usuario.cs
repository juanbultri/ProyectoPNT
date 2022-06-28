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
        
        public string Nombres { get; set; }
        
        public string Apellidos { get; set; }
        
        public string NombreUsuario { get; set; }
        
        public string Password { get; set; }

        [EnumDataType(typeof(Perfil))]
        public Perfil Perfil { get; set; }

        [EnumDataType(typeof(Plan))]
        public Plan? Plan { get; set; }
    }
}