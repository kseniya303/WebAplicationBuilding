using Db.Model;
using System;
using System.Data.Entity;

namespace Db
{
    public class BuildingContext : DbContext
    {
        public BuildingContext(string connectionString)
               : base(connectionString)
        {

        }
        public BuildingContext()
            :base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
           .HasMany<Material>(s => s.Materials)
           .WithMany(c => c.Users)
           .Map(cs =>
           {
               cs.MapLeftKey("UserId");
               cs.MapRightKey("MaterialId");
               cs.ToTable("UserMaterials");
           });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
