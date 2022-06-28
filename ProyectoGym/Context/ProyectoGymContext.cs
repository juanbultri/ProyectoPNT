using Microsoft.EntityFrameworkCore;
using ProyectoGym.Models;

namespace ProyectoGym.Context
{
    public class ProyectoGymContext : DbContext
    {
        public ProyectoGymContext(DbContextOptions<ProyectoGymContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Actividad> Actividades { get; set; }

        public DbSet<ProyectoGym.Models.ActividadesUsuario> ActividadesUsuario { get; set; }

        public DbSet<ProyectoGym.Models.Rutina> Rutinas { get; set; }
    }
}
