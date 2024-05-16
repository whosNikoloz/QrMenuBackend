namespace QrMenuBackend.Dtos
{
    public class ProductGroupDto
    {
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
