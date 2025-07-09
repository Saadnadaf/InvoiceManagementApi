using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace api.DTOs
{
    public class UpdateInvoiceItemDTO
    {
        [JsonPropertyName("ProductName")]
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("Quantity")]
        [Required]
        [Range(1,99,ErrorMessage ="Quantity should be more than 1 and less than 100 ")]
        public int Quantity { get; set; }

        [JsonPropertyName("UnitPrice")]
        [Required]
        public decimal UnitPrice { get; set; }
    }
}