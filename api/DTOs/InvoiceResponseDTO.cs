using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs
{
    public class InvoiceResponseDTO
    {
        [JsonPropertyName("InvoiceId")]
        public int Id { get; set; }
        [JsonPropertyName("InvoiceNumber")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [JsonPropertyName("CustomerName")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("InvoiceDate")]
        public DateTime InvoiceDate { get; set; }

        [JsonPropertyName("TotalAmount")]
        public decimal TotalAmount{ get; set; }

        [JsonPropertyName("InvoiceItems")]
        public List<InvoiceItemResponseDTO> InvoiceItemDetails { get; set; } = new List<InvoiceItemResponseDTO>();
    }
}