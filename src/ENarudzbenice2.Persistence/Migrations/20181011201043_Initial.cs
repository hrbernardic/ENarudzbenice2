using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ENarudzbenice2.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Sifra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Sifra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrsteNarudzbenica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Sifra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteNarudzbenica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "App",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timovi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Sifra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RadnoVrijeme = table.Column<string>(nullable: true),
                    KontaktBroj = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Godisnji = table.Column<string>(nullable: true),
                    Aktivan = table.Column<bool>(nullable: false),
                    AdresaDostava = table.Column<string>(nullable: true),
                    AdresaId = table.Column<Guid>(nullable: true),
                    DjelatnostId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timovi_Adrese_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Aktivan = table.Column<bool>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(nullable: false),
                    DatumIzrade = table.Column<DateTime>(nullable: false),
                    PrikazIme = table.Column<string>(nullable: true),
                    TimId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Timovi_TimId",
                        column: x => x.TimId,
                        principalTable: "Timovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Djelatnosti",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Sifra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RadnikId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelatnosti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Djelatnosti_Users_RadnikId",
                        column: x => x.RadnikId,
                        principalSchema: "App",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "App",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "App",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "App",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "App",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "App",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "App",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "App",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "App",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_Naziv",
                table: "Adrese",
                column: "Naziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Djelatnosti_Naziv",
                table: "Djelatnosti",
                column: "Naziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Djelatnosti_RadnikId",
                table: "Djelatnosti",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_Naziv",
                table: "Lokacije",
                column: "Naziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timovi_AdresaId",
                table: "Timovi",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Timovi_DjelatnostId",
                table: "Timovi",
                column: "DjelatnostId");

            migrationBuilder.CreateIndex(
                name: "IX_Timovi_Naziv",
                table: "Timovi",
                column: "Naziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VrsteNarudzbenica_Naziv",
                table: "VrsteNarudzbenica",
                column: "Naziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "App",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "App",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "App",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "App",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "App",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "App",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "App",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TimId",
                schema: "App",
                table: "Users",
                column: "TimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timovi_Djelatnosti_DjelatnostId",
                table: "Timovi",
                column: "DjelatnostId",
                principalTable: "Djelatnosti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Djelatnosti_Users_RadnikId",
                table: "Djelatnosti");

            migrationBuilder.DropTable(
                name: "Lokacije");

            migrationBuilder.DropTable(
                name: "VrsteNarudzbenica");

            migrationBuilder.DropTable(
                name: "Claims",
                schema: "App");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "App");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "App");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "App");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "App");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Timovi");

            migrationBuilder.DropTable(
                name: "Adrese");

            migrationBuilder.DropTable(
                name: "Djelatnosti");
        }
    }
}
