namespace DesafioTecnicoFSBR.Application.Features.Brand.Responses
{
    public sealed record BrandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
