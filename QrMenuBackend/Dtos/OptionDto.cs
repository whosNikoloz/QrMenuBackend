
using System.Text.Json.Serialization;

namespace QrMenuBackend.Dtos
{
    public class OptionDto
    {
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public string Type { get; set; } = "Radio";
        public int Product_Id { get; set; }

        [JsonIgnore]
        public ProductDto? Product { get; set; }

        public ICollection<OptionValueDto>? OptionValues { get; set; }
    }
}
