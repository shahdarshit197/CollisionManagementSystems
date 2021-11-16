using CollisionManagementSystems.Model;
using Microsoft.EntityFrameworkCore;

namespace CollisionManagementSystems.Db
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(c => c.Id);
        }
        public DbSet<Users> Userses { get; set; }


    }
}
