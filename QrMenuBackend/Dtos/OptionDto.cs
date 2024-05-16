
namespace QrMenuBackend.Dtos
{
    public class OptionDto
    {
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public int Product_Id { get; set; }

        public ProductDto? Product { get; set; }

        public ICollection<OptionValueDto>? OptionValues { get; set; }
    }
}
