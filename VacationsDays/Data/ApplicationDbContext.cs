using Microsoft.EntityFrameworkCore;
using VacationsDays.Models;

namespace VacationsDays.Data
{
       
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

            public DbSet<Vacation> Vacations { get; set; }

            public DbSet<DayData> DaysData { get; set; }    

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Dictionary<int, string>>().HasNoKey();

        //    // Agrega otras configuraciones de modelos aquí si es necesario
        //}

    }
    
}
