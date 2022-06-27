﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoGym.Models
{
    public class ActividadesUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Usuario Usuario  { get; set; }

        public Actividad Actividad { get; set; }
    }
}
