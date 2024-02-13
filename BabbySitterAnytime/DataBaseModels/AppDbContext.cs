using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BabbySitterAnytime.DataBaseModels
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Babysitter> Babysitters { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<Rating> Ratings { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Babysitter>()
                .HasOne(p => p.CurriculumVitae)
                .WithOne(pd => pd.Babysitter)
                .HasForeignKey<CurriculumVitae>(pd => pd.BabySitterId);

            modelBuilder.Entity<Appointment>()
                .HasKey(ap => new {ap.BabySitterId, ap.ClientId});

            modelBuilder.Entity<Appointment>()
                .HasOne(ap => ap.Babysitter)
                .WithMany(b => b.Appointments)
                .HasForeignKey(ap => ap.BabySitterId);

            modelBuilder.Entity<Appointment>()
                .HasOne(ap => ap.Client)
                .WithMany(b => b.Appointments)
                .HasForeignKey(ap => ap.ClientId);

            modelBuilder.Entity<Rating>()
                .HasOne(b => b.Babysitter)
                .WithMany(r => r.Ratings)
                .HasForeignKey(b => b.BabysitterId);
        }
    }
}
