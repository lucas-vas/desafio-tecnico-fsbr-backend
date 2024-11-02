namespace DesafioTecnicoFSBR.Application.Features.Car.Responses
{
    public sealed record CarResponse
    {
        public Guid Id { get; set; }
        public string ModelDescription { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }

        internal static CarResponse MapFromTheEntity(Domain.Entities.Car car)
        {
            var carResponse = new CarResponse
            {
                Id = car.Id,
                BrandId = car.BrandId,
                ModelDescription = car.ModelDescription,
                Value = car.Value,
                Year = car.Year,
                BrandName = car.Brand?.Name
            };

            return carResponse;
        }
    }
}
