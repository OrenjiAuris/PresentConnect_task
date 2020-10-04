using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PVM.Api.Services.Interfaces;
using PVM.Domain.DTOs;
using PVM.Domain.Params;

namespace Technical_Task_Aurimas_Šernas.Controllers
{
    [Route("vat")]
    [ApiController]
    public class PvmController : ControllerBase
    {
        private readonly ILogger<PvmController> _logger;
        private readonly IPvmService _pvmService;
        public PvmController(ILogger<PvmController> logger, IPvmService pvmService)
        {
            _logger = logger;
            _pvmService = pvmService;
        }

        [HttpGet("invoice")]
        public async Task<IActionResult> GenerateInvoice([FromQuery] InvoiceBuilderParams properties)
        {
            try
            {
                InvoiceDto invoice = await _pvmService.GenerateInvoice(properties);
                if (invoice == null)
                {
                    return NotFound();
                }
                return Ok(invoice);
            }
            catch (Exception)
            {
                _logger.LogError("Error in PvmController GenerateInvoice().");
                throw;
            }
        }
    }
}
