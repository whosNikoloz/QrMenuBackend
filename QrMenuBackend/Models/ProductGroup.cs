using System.ComponentModel.DataAnnotations;

namespace QrMenuBackend.Models
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
