namespace DesafioTecnicoFSBR.Application.Features.Brand.Responses
{
    public sealed record BrandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        internal static BrandResponse MapFromTheEntity(Domain.Entities.Brand brand)
        {
            var brandResponse = new BrandResponse
            {
                Id = brand.Id,
                Name = brand.Name
            };

            return brandResponse;
        }
    }
}
