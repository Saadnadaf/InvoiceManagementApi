using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetInvoiceById([FromRoute] int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceResponseDTO>>> GetAllInvoices()
        {
            var invoice = await _invoiceService.GetAllInvoiceAsync();
            return Ok(invoice);
        } 

        [HttpPost]
        public async Task<ActionResult<InvoiceResponseDTO>> CreateInvoice([FromBody] CreateInvoiceMasterDTO dto)
        {
            var invoice = await _invoiceService.CreateInvoiceAsync(dto);
            return CreatedAtAction(nameof(GetInvoiceById),new{id=invoice.Id},invoice);
        }

            
    }
}