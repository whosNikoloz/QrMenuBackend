using QrMenuBackend.Dtos;
using System.ComponentModel.DataAnnotations;

namespace QrMenuBackend.Dtos.Create
{
    public class ProductGroupCreateDto
    {
        [Required]
        public string? Name_En { get; set; }
        [Required]
        public string? Name_Ka { get; set; }
    }
}
