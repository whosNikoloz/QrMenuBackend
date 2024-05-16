using System.Text.Json.Serialization;

namespace QrMenuBackend.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Discount { get; set; }
        public string? Description_En { get; set; }
        public string? Description_Ka { get; set; }

        // Custom foreign key property
        public int Group_Id { get; set; }

        // Navigation property
        [JsonIgnore]
        public ProductGroupDto? ProductGroup { get; set; }

        // Collection of options
        public ICollection<OptionDto>? Options { get; set; }
    }
}
