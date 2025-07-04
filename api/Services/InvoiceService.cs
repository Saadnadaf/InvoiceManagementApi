using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Exceptions;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoicerepo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public InvoiceService(AppDbContext context, IInvoiceRepository invoicerepo, IMapper mapper)
        {
            _invoicerepo = invoicerepo;
            _mapper = mapper;
            _context = context;
            
        }
        public async Task<InvoiceResponseDTO> CreateInvoiceAsync(CreateInvoiceMasterDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CustomerName))
            {
                throw new BadRequestException("Customer name is required");
            }

            if (await _invoicerepo.InvoiceNumberExistsAsync(dto.InvoiceNumber))
            {
                throw new ConflictException("Invoice number already exists");

            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {

                var invoice = _mapper.Map<InvoiceMaster>(dto);

                foreach (var item in invoice.InvoiceItemDetails)

                {
                    item.Total = item.Quantity * item.UnitPrice;
                }

                invoice.TotalAmount = invoice.InvoiceItemDetails.Sum(i => i.Total);

                var saved = await _invoicerepo.AddInvoiceAsync(invoice);

                await transaction.CommitAsync();

                return _mapper.Map<InvoiceResponseDTO>(saved);

            }

            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<InvoiceResponseDTO>> GetAllInvoiceAsync()
        {
            var invoice = await _invoicerepo.GetAllInvoiceAsync();

            return _mapper.Map<List<InvoiceResponseDTO>>(invoice);
        }

        public async Task<InvoiceResponseDTO?> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoicerepo.GetInvoiceById(id);

            if (invoice == null) throw new NotFoundException("Invoice not found (Wrong Id)");

            return _mapper.Map<InvoiceResponseDTO>(invoice);
        }

        public async Task<bool> UpdateInvoiceAsync(int id, UpdateInvoiceMasterDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {

                var invoice = await _invoicerepo.GetInvoiceById(id);

                if (invoice == null) throw new NotFoundException("Invoice not found (Wrong id)");

                if (string.IsNullOrWhiteSpace(dto.CustomerName))
                {
                    throw new BadRequestException("Customer name is required");
                }
                var updatedinvoice = _mapper.Map(dto, invoice);

                updatedinvoice.Id = id;

                foreach (var item in updatedinvoice.InvoiceItemDetails)
                {
                    item.Total = item.Quantity * item.UnitPrice;
                }
                updatedinvoice.TotalAmount = updatedinvoice.InvoiceItemDetails.Sum(i => i.Total);

                var result = await _invoicerepo.UpdateInvoiceAsync(updatedinvoice);

                await transaction.CommitAsync();

                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var invoice = await _invoicerepo.GetInvoiceById(id);
                if (invoice == null)
                {
                    throw new NotFoundException("Invoice not found (Wrong Id)");
                }
                var deleted = await _invoicerepo.DeleteInvoiceAsync(id);

                await transaction.CommitAsync();

                return deleted;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw; 
            }
        }

        public async Task<bool> DeleteSingleInvoiceItemAsync(int invoicemasterid , int invoiceitemid)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _invoicerepo.DeleteSingleInvoiceItemAsync(invoicemasterid, invoiceitemid);

                if (!result) throw new NotFoundException("Invoice or item not found");

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}