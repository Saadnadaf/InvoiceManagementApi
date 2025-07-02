using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using api.Models;
namespace api.DTOs
{
    public class UpdateInvoiceMasterDTO
    {
        [JsonPropertyName("InvoiceNumber")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [JsonPropertyName("CustomerName")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("InvoiceDate")]
        public DateTime InvoiceDate { get; set; }

        [JsonPropertyName("InvoiceItems")]
        public List<UpdateInvoiceItemDTO> InvoiceItemDetails { get; set; } = new List<UpdateInvoiceItemDTO>();
    }
}