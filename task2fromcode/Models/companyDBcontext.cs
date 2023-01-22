using Microsoft.EntityFrameworkCore;

namespace task2fromcode.Models
{
    public class companyDBcontext:DbContext
    {
        public virtual DbSet<employee> employees { get; set; }
         public virtual DbSet<department> Departments { get; set; } 

        public virtual DbSet<dependent> Dependents { get; set; }

        public virtual DbSet<Dlocations> DLocations { get; set; }
        public virtual DbSet<project> Projects { get; set; }

        public virtual DbSet<workOn> WorkOns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=NEWCOMPANY;Integrated Security=True ;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<workOn>().HasKey("ESSN", "Pnum");
            modelBuilder.Entity<dependent>().HasKey("name", "EmployeeSSN");
            modelBuilder.Entity<Dlocations>().HasKey("Dlocation", "Dnum");
        }

    }
}
