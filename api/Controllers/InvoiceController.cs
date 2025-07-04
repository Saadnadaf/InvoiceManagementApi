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
            if (!ModelState.IsValid) return BadRequest(ModelState);

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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var invoice = await _invoiceService.CreateInvoiceAsync(dto);

            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] UpdateInvoiceMasterDTO dto) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var invoice = await _invoiceService.UpdateInvoiceAsync(id, dto);

            if (!invoice) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var invoice = await _invoiceService.DeleteInvoiceAsync(id);

            if (!invoice) return NotFound();

            return NoContent();
        }

        [HttpDelete("{InvoiceId}/{ItemId}")]
        public async Task<IActionResult> Deleteinvoiceitem([FromRoute]int InvoiceId,[FromRoute] int ItemId)
        {
            var result = await _invoiceService.DeleteSingleInvoiceItemAsync(InvoiceId, ItemId);

            return result ? Ok("Invoice item deleted succesfully") : NotFound("Invoice or item not found");
        }
    }
            
}
