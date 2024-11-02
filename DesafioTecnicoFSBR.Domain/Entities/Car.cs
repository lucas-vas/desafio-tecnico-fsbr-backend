using DesafioTecnicoFSBR.Domain.Abstraction;
using DesafioTecnicoFSBR.Domain.Exceptions;

namespace DesafioTecnicoFSBR.Domain.Entities
{
    public sealed class Car : AggregateRoot
    {
        public string ModelDescription { get; private set; }
        public int Year { get; private set; }
        public double Value { get; private set; }
        public Guid BrandId { get; private set; }
        public Brand Brand { get; }

        private Car
        (
            string modelDescription,
            int year,
            double value,
            Guid brandId
        ) 
        {
            ModelDescription = modelDescription;
            Year = year;
            Value = value;
            BrandId = brandId;

            Validate();
        }

        internal static Car Create
        (
            string modelDescription,
            int year,
            double value,
            Guid brandId
        )
        {
            var car = new Car
            (
                modelDescription: modelDescription,
                year: year,
                value: value,
                brandId: brandId
            );

            return car;
        }

        public void Update
        (
            string modelDescription,
            int year,
            double value,
            Guid brandId
        )
        {
            ModelDescription = modelDescription;
            Year = year;
            Value = value;
            BrandId = brandId;

            Validate();
        }

        private void Validate()
        {
            ValidateModelDescription();
            ValidateValue();
            ValidateYear();
        }

        private void ValidateModelDescription()
        {
            DomainException.When(string.IsNullOrWhiteSpace(ModelDescription), "A descrição do modelo não pode ser nula ou vazia");
        }

        private void ValidateValue()
        {
            DomainException.When(Value <= 0, "O valor do carro não pode ser menor ou igual a zero");
        }

        private void ValidateYear()
        {
            DomainException.When(Year <= 0, "O ano do carro não pode ser menor ou igual a zero");
        }
    }
}
