using PVM.Domain.DTOs;
using PVM.Domain.Params;
using System.Threading.Tasks;

namespace PVM.Api.Services.Interfaces
{
    public interface IPvmService
    {
        Task<InvoiceDto> GenerateInvoice(InvoiceBuilderParams properties);
    }
}
