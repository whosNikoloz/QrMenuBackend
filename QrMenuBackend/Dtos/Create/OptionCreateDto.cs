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

        [ValidOptionType]
        public string Type { get; set; } = "Radio"; // Default to "Radio" as per your example
    }

    public class ValidOptionTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var allowedTypes = new[] { "Radio", "CheckBox", "NumField" };
            var type = value as string;

            if (type != null && Array.IndexOf(allowedTypes, type) == -1)
            {
                return new ValidationResult("Type must be either 'Radio' or 'CheckBox'.");
            }

            return ValidationResult.Success;
        }
    }
}
