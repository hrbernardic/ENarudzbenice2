using DDFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ENarudzbenice2.Persistence.Configurations
{
    public abstract class SifarnikConfiguration<T>  : IEntityTypeConfiguration<T> where T : SifarnikEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Naziv)
                .IsRequired();

            builder.HasIndex(d => d.Naziv)
                .IsUnique();

            builder.Property(p => p.Sifra)
                .IsRequired()
                .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
        }
    }
}
