using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenuBackend.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }

        // Custom foreign key property
        [ForeignKey(nameof(Product))]
        public int Product_Id { get; set; }

        // Navigation property
        public Product? Product { get; set; }

        public ICollection<OptionValue>? OptionValues { get; set; }
    }
}
