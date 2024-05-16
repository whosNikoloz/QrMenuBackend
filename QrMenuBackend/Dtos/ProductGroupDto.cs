namespace QrMenuBackend.Dtos
{
    public class ProductGroupDto
    {
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
