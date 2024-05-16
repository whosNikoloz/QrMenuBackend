using QrMenuBackend.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenuBackend.Dtos.Create
{
    public class ProductCreateDto
    {
        [Required]
        public string Name_En { get; set; } = string.Empty;

        [Required]
        public string Name_Ka { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)] 
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int? Discount { get; set; }

        public string Description_En { get; set; } = string.Empty;

        public string Description_Ka { get; set; } = string.Empty;

        [Required]
        public int Group_Id { get; set; }
    }
}
