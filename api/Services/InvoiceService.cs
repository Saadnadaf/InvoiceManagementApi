using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoicerepo;
        private readonly IMapper _mapper;
        public InvoiceService(IInvoiceRepository invoicerepo, IMapper mapper)
        {
            _invoicerepo = invoicerepo;
            _mapper = mapper;
        }
        public async Task<InvoiceResponseDTO> CreateInvoiceAsync(CreateInvoiceMasterDTO dto)
        {
            var invoice = _mapper.Map<InvoiceMaster>(dto);
            foreach (var item in invoice.InvoiceItemDetails)
            {
                item.Total = item.Quantity * item.UnitPrice;
            }
            invoice.TotalAmount = invoice.InvoiceItemDetails.Sum(i => i.Total);
            var saved = await _invoicerepo.AddInvoiceAsync(invoice);
            return _mapper.Map<InvoiceResponseDTO>(saved);
        }

        public async Task<List<InvoiceResponseDTO>> GetAllInvoiceAsync()
        {
            var invoice = await _invoicerepo.GetAllInvoiceAsync();
            return _mapper.Map<List<InvoiceResponseDTO>>(invoice);
        }

        public async Task<InvoiceResponseDTO?> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoicerepo.GetInvoiceById(id);
            if (invoice == null) return null;
            return _mapper.Map<InvoiceResponseDTO>(invoice);
        }

        public async Task<bool> UpdateInvoiceAsync(int id, UpdateInvoiceMasterDTO dto)
        {
            var invoice = await _invoicerepo.GetInvoiceById(id);
            if (invoice == null) return false;
            var updatedinvoice = _mapper.Map(dto,invoice);
            updatedinvoice.Id = id;
            foreach (var item in updatedinvoice.InvoiceItemDetails)
            {
                item.Total = item.Quantity * item.UnitPrice;
            }
            updatedinvoice.TotalAmount = updatedinvoice.InvoiceItemDetails.Sum(i => i.Total);
            return await _invoicerepo.UpdateInvoiceAsync(updatedinvoice); 
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            return await _invoicerepo.DeleteInvoiceAsync(id);
        }
    }
}