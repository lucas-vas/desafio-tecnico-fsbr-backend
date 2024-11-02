using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioTecnicoFSBR.Domain.Abstraction
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        [Column("CREATED_AT")]
        [DataType("DATETIME")]
        [Required]
        public DateTime CreatedAt { get; private set; }
        [Column("CREATED_BY")]
        [DataType("INT")]
        [Required]
        public Guid CreatedBy { get; private set; }
        [Column("UPDATED_AT")]
        [DataType("DATETIME")]
        public DateTime? UpdatedAt { get; private set; }
        [Column("UPDATED_BY")]
        [DataType("INT")]
        public Guid? UpdatedBy { get; private set; }

        public void SetCreatedAt() => CreatedAt = DateTime.UtcNow.AddHours(-3);
        public void SetCreatedBy(Guid createdBy) => CreatedBy = createdBy;
        public void SetUpdatedAt() => UpdatedAt = DateTime.UtcNow.AddHours(-3);
        public void SetUpdatedBy(Guid updatedBy) => UpdatedBy = updatedBy;
    }
}
