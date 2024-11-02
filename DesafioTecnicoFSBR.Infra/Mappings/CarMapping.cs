using DesafioTecnicoFSBR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTecnicoFSBR.Infra.Mappings
{
    internal sealed class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("CAR");

            builder.HasOne(x => x.Brand)
            .WithMany()
            .HasForeignKey(x => x.BrandId);

            builder.Property(x => x.ModelDescription)
            .HasColumnName("MODEL_DESCRIPTION")
            .HasColumnType("NVARCHAR(100)")
            .IsRequired();

            builder.Property(x => x.Year)
            .HasColumnName("YEAR")
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(x => x.Value)
            .HasColumnName("VALUE")
            .HasColumnType("DECIMAL")
            .IsRequired();

            builder.Property(x => x.BrandId)
            .HasColumnName("BRAND_ID")
            .HasColumnType("uniqueidentifier")
            .IsRequired();
        }
    }
}
