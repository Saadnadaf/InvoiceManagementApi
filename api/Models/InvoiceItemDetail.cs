using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class InvoiceItemDetail
    {
        public int Id { get; set; }

        [ForeignKey("InvoiceMaster")]
        public int InvoiceId { get; set; }
        public InvoiceMaster InvoiceMaster { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal UnitPrice { get; set; }
        
        [Column(TypeName = "decimal(15,2)")]
        public decimal Total{ get; set; }
    }
}