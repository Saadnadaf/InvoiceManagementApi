using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.MicrosoftExtensions;
namespace api.DTOs
{
    public class CreateInvoiceItemDTO
    {
        [JsonPropertyName("ProductName")]
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("Quantity")]
        [Required]
        [Range(1,99,ErrorMessage = "Quantity should be at least 1")] 
        public int Quantity { get; set; }

        [JsonPropertyName("UnitPrice")]
        [Required]
        public decimal UnitPrice { get; set; }
        
    }
}