using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenuBackend.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Discount { get; set; }
        public string? Description_En { get; set; }
        public string? Description_Ka { get; set; }

        // Custom foreign key property
        [ForeignKey(nameof(ProductGroup))]
        public int Group_Id { get; set; }

        // Navigation property
        public ProductGroup? ProductGroup { get; set; }

        public ICollection<Option>? Options { get; set; }
    }
}
