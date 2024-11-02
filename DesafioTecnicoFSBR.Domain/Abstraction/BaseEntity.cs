using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioTecnicoFSBR.Domain.Abstraction
{
    public abstract class BaseEntity
    {
        [Column("ID")]
        [DataType("NVARCHAR(50)")]
        [Required]
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
