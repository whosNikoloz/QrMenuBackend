using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenuBackend.Models
{
    public class OptionValue
    {
        [Key]
        public int Id { get; set; }

        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public decimal Price { get; set; }

        // Custom foreign key property
        [ForeignKey(nameof(Option))]
        public int Option_Id { get; set; }

        // Navigation property
        public Option? Option { get; set; }
    }
}
