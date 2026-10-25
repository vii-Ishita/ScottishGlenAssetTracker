using Microsoft.EntityFrameworkCore;
using ScottishGlenApp.Models;
namespace ScottishGlenApp.Data{
    public class ScottishGlenDbContext:DbContext{
        public ScottishGlenDbContext(DbContextOptions<ScottishGlenDbContext>options):base(options){
        }   
        public DbSet<Asset> Assets {get; set;} = null!;
        public DbSet<Employee> Employees {get; set;} = null!;
        public DbSet<Department> Departments {get; set;} = null!;
        protected override void OnModelCreating (ModelBuilder modelBuilder){
            modelBuilder.Entity<Asset>().HasKey(a=>a.assetID);
            modelBuilder.Entity<Employee>().HasKey(e=>e.employeeID);
            modelBuilder.Entity<Department>().HasKey(d=>d.departmentID);
            modelBuilder.Entity<Asset>().ToTable("Asset");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Asset>()
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(a=>a.employeeID);
            modelBuilder.Entity<Employee>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(b=>b.departmentID);
        }
     }
}