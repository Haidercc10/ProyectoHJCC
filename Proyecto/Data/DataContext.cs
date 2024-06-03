using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }   

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Status_Type> Status_Types { get; set; }

        public DbSet<Document_Type> Documents_Types {  get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Statuses 
            modelBuilder.Entity<Status>().HasOne(x => x.Statuses_Types).WithMany().HasForeignKey(z => z.Staty_Id).OnDelete(DeleteBehavior.Restrict);

            //Users
            modelBuilder.Entity<User>().HasOne(x => x.CivilStatus).WithMany().HasForeignKey(z => z.Status_Civil).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.Statuses).WithMany().HasForeignKey(z => z.Status_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.Docs_Types).WithMany().HasForeignKey(z => z.DocType_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany().HasForeignKey(z => z.Rol_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.TypeUsers).WithMany().HasForeignKey(z => z.TypeUser_Id).OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Proyecto.Models.TypeUser> TypeUser { get; set; } = default!;
    }
}
