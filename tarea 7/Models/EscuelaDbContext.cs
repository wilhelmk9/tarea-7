using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using tarea_7.Models;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace tarea_7.Models
{
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<TipoSangre> TiposSangre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones y restricciones aquí

            // Relación entre Estudiante y TipoSangre (un estudiante tiene un tipo de sangre)
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.TipoSangre)
                .WithMany()
                .HasForeignKey(e => e.IdTipoSangre);
        }
    }

    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public required string Carne { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string CorreoElectronico { get; set; }
        public int IdTipoSangre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Propiedad de navegación para la relación con TipoSangre
        public required TipoSangre TipoSangre { get; set; }
    }

    public class TipoSangre
    {
        [Key]
        public int IdTipoSangre { get; set; }
        public required string Sangre { get; set; }
    }


}
