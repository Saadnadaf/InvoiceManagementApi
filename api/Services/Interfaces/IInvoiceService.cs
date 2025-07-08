using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Helpers;

namespace api.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceResponseDTO> CreateInvoiceAsync(CreateInvoiceMasterDTO dto);
        Task<List<InvoiceResponseDTO>> GetAllInvoiceAsync(QueryObject query);
        Task<InvoiceResponseDTO?> GetInvoiceByIdAsync(int id);
        Task<bool> UpdateInvoiceAsync(int id, UpdateInvoiceMasterDTO dto);
        Task<bool> DeleteInvoiceAsync(int id);
        Task<bool> DeleteSingleInvoiceItemAsync(int invoicemasterid,int invoiceitemid);
    }
}