using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<InvoiceMaster> AddInvoiceAsync(InvoiceMaster invoice);
        Task<InvoiceMaster?> GetInvoiceById(int Id);
        Task<List<InvoiceMaster>> GetAllInvoiceAsync(QueryObject query);
        Task<bool> UpdateInvoiceAsync(InvoiceMaster invoice);
        Task<bool> DeleteInvoiceAsync(int Id);
        Task<bool> InvoiceNumberExistsAsync(string invoicenumber);
        Task<bool> DeleteSingleInvoiceItemAsync(int invoicemasterid,int invoiceitemid);
    }
}