using Microsoft.EntityFrameworkCore;

namespace Condez_SIS_v3
{
    public class SchoolContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().ToTable("DaveSTS");
        }
    }
}