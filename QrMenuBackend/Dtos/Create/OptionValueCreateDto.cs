using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenuBackend.Dtos.Create
{
    public class OptionValueCreateDto
    {
        [Required]
        public string? Name_En { get; set; }
        [Required]
        public string? Name_Ka { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int Option_Id { get; set; }
    }
}
