using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceResponseDTO> CreateInvoiceAsync(CreateInvoiceMasterDTO dto);
        Task<List<InvoiceResponseDTO>> GetAllInvoiceAsync();
        Task<InvoiceResponseDTO?> GetInvoiceByIdAsync(int id);
        Task<bool> UpdateInvoiceAsync(int id , CreateInvoiceMasterDTO dto);
        Task<bool> DeleteInvoiceAsync(int id );
    }
}