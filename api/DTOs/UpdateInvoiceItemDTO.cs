using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using System.Text.Json.Serialization;
namespace api.DTOs
{
    public class UpdateInvoiceItemDTO
    {
        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        
        [JsonPropertyName("UnitPrice")]
        public decimal UnitPrice { get; set; }
    }
}