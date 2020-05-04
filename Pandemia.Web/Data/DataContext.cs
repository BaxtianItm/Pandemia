using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pandemic.Web.Data.Entities;

namespace Pandemic.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ReportEntity> Report { get; set; }
        public DbSet<ReportDetailsEntity> ReportDetails { get; set; }
        public DbSet<StatusReport> StatusReport { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
