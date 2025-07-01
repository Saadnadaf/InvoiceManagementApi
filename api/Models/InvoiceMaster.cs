using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class InvoiceMaster
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(15,2)")]
        public decimal TotalAmount { get; set; }
        public List<InvoiceItemDetail> InvoiceItemDetails { get; set; } = new List<InvoiceItemDetail>(); 
    }
}