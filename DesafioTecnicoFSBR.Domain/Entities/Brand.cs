using DesafioTecnicoFSBR.Domain.Abstraction;
using DesafioTecnicoFSBR.Domain.Exceptions;

namespace DesafioTecnicoFSBR.Domain.Entities
{
    public sealed class Brand : AggregateRoot
    {
        public string Name { get; private set; }

        private Brand(string name)
        {
            Name = name;

            Validate();
        }

        internal static Brand Create(string name)
        {
            var brand = new Brand(name: name);
            return brand;
        }

        public void Update(string name)
        {
            Name = name;

            Validate();
        }

        private void Validate()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            DomainException.When(string.IsNullOrWhiteSpace(Name), "O nome da marca não pode ser nulo ou vazio");
        }
    }
}
