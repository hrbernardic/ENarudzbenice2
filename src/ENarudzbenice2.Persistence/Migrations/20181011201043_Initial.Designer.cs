﻿// <auto-generated />
using System;
using ENarudzbenice2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ENarudzbenice2.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181011201043_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Adresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("Sifra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.ToTable("Adrese");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Djelatnost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<Guid?>("RadnikId");

                    b.Property<int>("Sifra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.HasIndex("RadnikId");

                    b.ToTable("Djelatnosti");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.Claim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<bool>("Active");

                    b.Property<string>("Controller");

                    b.HasKey("Id");

                    b.ToTable("Claims","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Aktivan");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DatumIzmjene");

                    b.Property<DateTime>("DatumIzrade");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Ime");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prezime");

                    b.Property<string>("PrikazIme");

                    b.Property<string>("SecurityStamp");

                    b.Property<Guid?>("TimId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TimId");

                    b.ToTable("Users","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens","App");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Lokacija", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("Sifra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.ToTable("Lokacije");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Tim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdresaDostava");

                    b.Property<Guid?>("AdresaId");

                    b.Property<bool>("Aktivan");

                    b.Property<Guid?>("DjelatnostId");

                    b.Property<string>("Email");

                    b.Property<string>("Godisnji");

                    b.Property<string>("KontaktBroj");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<string>("RadnoVrijeme");

                    b.Property<int>("Sifra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("AdresaId");

                    b.HasIndex("DjelatnostId");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.ToTable("Timovi");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.VrstaNarudzbenice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("Sifra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.ToTable("VrsteNarudzbenica");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Djelatnost", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.User", "Radnik")
                        .WithMany("Djelatnosti")
                        .HasForeignKey("RadnikId");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.RoleClaim", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.User", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Tim", "Tim")
                        .WithMany()
                        .HasForeignKey("TimId");
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserClaim", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserLogin", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Identity.UserToken", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ENarudzbenice2.Domain.Entities.Tim", b =>
                {
                    b.HasOne("ENarudzbenice2.Domain.Entities.Adresa", "Adresa")
                        .WithMany()
                        .HasForeignKey("AdresaId");

                    b.HasOne("ENarudzbenice2.Domain.Entities.Djelatnost", "Djelatnost")
                        .WithMany("Timovi")
                        .HasForeignKey("DjelatnostId");
                });
#pragma warning restore 612, 618
        }
    }
}
