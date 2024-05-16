using System.ComponentModel.DataAnnotations;

namespace QrMenuBackend.Dtos.Create
{
    public class OptionCreateDto
    {
        [Required]
        public string? Name_En { get; set; }
        [Required]
        public string? Name_Ka { get; set; }
        [Required]
        public int Product_Id { get; set; }
    }
}
