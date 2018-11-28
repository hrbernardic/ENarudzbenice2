using System;
using Microsoft.EntityFrameworkCore;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence.Extensions;
using ENarudzbenice2.Identity;

namespace ENarudzbenice2.Persistence
{
    public class ApplicationDbContext : AppIdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Djelatnost> Djelatnosti { get; set; }
        public DbQuery<DjelatnostBrowse> DjelatnostiBrowse { get; set; }
        public DbQuery<AdresaBrowse> AdreseBrowse { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<Tim> Timovi { get; set; }
        public DbSet<VrstaNarudzbenice> VrsteNarudzbenica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurations();
        }

        [DbFunction("dd_integerLike", "dbo")]
        public static bool IntegerLike(int value, string filter)
        {
            throw new NotImplementedException();
        }
    }

    public class DjelatnostBrowse
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public int Sifra { get; set; }
        public string RadnikPrikazIme { get; set; }
    }

    public class AdresaBrowse
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public int Sifra { get; set; }
    }
}
