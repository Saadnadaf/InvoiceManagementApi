using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class InvoiceItemResponseDTO
    {
        
        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("Total")]
        public decimal Total{ get; set; }
    }
}