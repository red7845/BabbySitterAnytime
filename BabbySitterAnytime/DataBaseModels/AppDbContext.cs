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
        public DbSet<Area> Areas { get; set; }
        public DbSet<BabysitterArea> BabysitterArea { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Babysitter>()
                .HasOne(p => p.CurriculumVitae)
                .WithOne(pd => pd.Babysitter)
                .HasForeignKey<CurriculumVitae>(pd => pd.BabySitterId);

            modelBuilder.Entity<BabysitterArea>()
           .HasKey(ba => new { ba.BabysitterId, ba.AreaId });

            modelBuilder.Entity<BabysitterArea>()
                .HasOne(ba => ba.Babysitter)
                .WithMany(b => b.SupportingAreas)
                .HasForeignKey(ba => ba.BabysitterId);

            modelBuilder.Entity<BabysitterArea>()
                .HasOne(ba => ba.Area)
                .WithMany(a => a.Babysitters)
                .HasForeignKey(ba => ba.AreaId);

            modelBuilder.Entity<Rating>()
                .HasOne(b => b.Babysitter)
                .WithMany(r => r.Ratings)
                .HasForeignKey(b => b.BabysitterId);

            modelBuilder.Entity<Area>().HasData(
    new Area { Id = Guid.NewGuid(), Name = "Syntagma" },
    new Area { Id = Guid.NewGuid(), Name = "Plaka" },
    new Area { Id = Guid.NewGuid(), Name = "Monastiraki" },
    new Area { Id = Guid.NewGuid(), Name = "Kolonaki" },
    new Area { Id = Guid.NewGuid(), Name = "Exarchia" },
    new Area { Id = Guid.NewGuid(), Name = "Psiri" },
    new Area { Id = Guid.NewGuid(), Name = "Gazi" },
    new Area { Id = Guid.NewGuid(), Name = "Pangrati" },
    new Area { Id = Guid.NewGuid(), Name = "Metaxourgeio" },
    new Area { Id = Guid.NewGuid(), Name = "Koukaki" },
    new Area { Id = Guid.NewGuid(), Name = "Kypseli" },
    new Area { Id = Guid.NewGuid(), Name = "Thissio" },
    new Area { Id = Guid.NewGuid(), Name = "Petralona" },
    new Area { Id = Guid.NewGuid(), Name = "Neapoli" },
    new Area { Id = Guid.NewGuid(), Name = "Lykavittos" },
    new Area { Id = Guid.NewGuid(), Name = "Neos Kosmos" },
    new Area { Id = Guid.NewGuid(), Name = "Agios Dimitrios" },
    new Area { Id = Guid.NewGuid(), Name = "Piraeus" },
    new Area { Id = Guid.NewGuid(), Name = "Marousi" },
    new Area { Id = Guid.NewGuid(), Name = "Chalandri" },
    new Area { Id = Guid.NewGuid(), Name = "Glyfada" },
    new Area { Id = Guid.NewGuid(), Name = "Vouliagmeni" },
    new Area { Id = Guid.NewGuid(), Name = "Ilisia" },
    new Area { Id = Guid.NewGuid(), Name = "Ano Patisia" },
    new Area { Id = Guid.NewGuid(), Name = "Kato Patisia" },
    new Area { Id = Guid.NewGuid(), Name = "Zografou" },
    new Area { Id = Guid.NewGuid(), Name = "Aghia Paraskevi" },
    new Area { Id = Guid.NewGuid(), Name = "Galatsi" },
    new Area { Id = Guid.NewGuid(), Name = "Omonia" },
    new Area { Id = Guid.NewGuid(), Name = "Sepolia" },
    new Area { Id = Guid.NewGuid(), Name = "Ano Ilisia" },
    new Area { Id = Guid.NewGuid(), Name = "Elliniko" },
    new Area { Id = Guid.NewGuid(), Name = "Peristeri" },
    new Area { Id = Guid.NewGuid(), Name = "Kallithea" },
    new Area { Id = Guid.NewGuid(), Name = "Moschato" },
    new Area { Id = Guid.NewGuid(), Name = "Tavros" },
    new Area { Id = Guid.NewGuid(), Name = "Nikaia" },
    new Area { Id = Guid.NewGuid(), Name = "Agios Ioannis Rentis" },
    new Area { Id = Guid.NewGuid(), Name = "Kifisia" },
    new Area { Id = Guid.NewGuid(), Name = "Vrilissia" },
    new Area { Id = Guid.NewGuid(), Name = "Melissia" },
    new Area { Id = Guid.NewGuid(), Name = "Agios Stefanos" },
    new Area { Id = Guid.NewGuid(), Name = "Ano Liosia" },
    new Area { Id = Guid.NewGuid(), Name = "Varvakeios" },
    new Area { Id = Guid.NewGuid(), Name = "Ambelokipi" },
    new Area { Id = Guid.NewGuid(), Name = "Gyzi" },
    new Area { Id = Guid.NewGuid(), Name = "Psychiko" },
    new Area { Id = Guid.NewGuid(), Name = "Filothei" },
    new Area { Id = Guid.NewGuid(), Name = "Argyroupoli" },
    new Area { Id = Guid.NewGuid(), Name = "Alimos" },
    new Area { Id = Guid.NewGuid(), Name = "Palaio Faliro" },
    new Area { Id = Guid.NewGuid(), Name = "Kaisariani" },
    new Area { Id = Guid.NewGuid(), Name = "Votanikos" },
    new Area { Id = Guid.NewGuid(), Name = "Kerameikos" },
    new Area { Id = Guid.NewGuid(), Name = "Rizoupoli" },
    new Area { Id = Guid.NewGuid(), Name = "Aghios Eleftherios" },
    new Area { Id = Guid.NewGuid(), Name = "Nea Smyrni" },
    new Area { Id = Guid.NewGuid(), Name = "Aghios Artemios" },
    new Area { Id = Guid.NewGuid(), Name = "Ano Petralona" },
    new Area { Id = Guid.NewGuid(), Name = "Kaminia" }
);
        }
    }
}
