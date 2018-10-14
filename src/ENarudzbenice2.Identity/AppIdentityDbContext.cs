using System;
using ENarudzbenice2.Domain.Entities.App;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ENarudzbenice2.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        protected AppIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Claim>(claim => { claim.ToTable("Claims", "App"); });
            builder.Entity<User>(user => { user.ToTable("Users", "App"); });
            builder.Entity<Role>(user => { user.ToTable("Roles", "App"); });
            builder.Entity<UserClaim>(user => { user.ToTable("UserClaims", "App"); });
            builder.Entity<UserLogin>(user => { user.ToTable("UserLogins", "App"); });
            builder.Entity<RoleClaim>(user => { user.ToTable("RoleClaims", "App"); });
            builder.Entity<UserToken>(user => { user.ToTable("UserTokens", "App"); });

            builder.Entity<UserRole>(userRole =>
            {
                userRole.ToTable("UserRoles", "App");

                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
