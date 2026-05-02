using Microsoft.EntityFrameworkCore;
using SistemaDeGestiónDeEmpleados.MODEL;

namespace SistemaDeGestiónDeEmpleados.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opciones)
           : base(opciones)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
