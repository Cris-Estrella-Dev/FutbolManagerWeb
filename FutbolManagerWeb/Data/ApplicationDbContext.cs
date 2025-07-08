using Microsoft.EntityFrameworkCore;
using FutbolManagerWeb.Models;

namespace FutbolManagerWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aquí definimos los DbSet de nuestras entidades
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<Contrato> Contratos { get; set; }

    }
}
