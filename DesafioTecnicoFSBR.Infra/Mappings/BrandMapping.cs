using DesafioTecnicoFSBR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoFSBR.Infra.Mappings
{
    internal sealed class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("BRAND");

            builder.Property(x => x.Name)
            .HasColumnName("NAME")
            .HasColumnType("NVARCHAR(100)")
            .IsRequired();
        }
    }
}
