using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<InvoiceMaster> InvoiceMasters { get; set; }
        public DbSet<InvoiceItemDetail> InvoiceItemDetails { get; set; }
    }
}