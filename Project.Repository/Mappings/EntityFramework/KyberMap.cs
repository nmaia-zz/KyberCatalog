using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Repository.Mappings.EntityFramework
{
    public class KyberMap : IEntityTypeConfiguration<Kyber>
    {
        public void Configure(EntityTypeBuilder<Kyber> builder)
        {
            builder.ToTable("Kybers");

            builder.Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(p => p.Color)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Planet)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(p => p.Meaning)
                .HasColumnType("varchar(400)")
                .IsRequired();
        }
    }
}
