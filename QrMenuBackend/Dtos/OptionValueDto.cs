﻿
using System.Text.Json.Serialization;

namespace QrMenuBackend.Dtos
{
    public class OptionValueDto
    {
        public int Id { get; set; }

        public string? Name_En { get; set; }
        public string? Name_Ka { get; set; }
        public decimal Price { get; set; }
        public int Option_Id { get; set; }
        [JsonIgnore]
        public OptionDto? Option { get; set; }
    }
}
