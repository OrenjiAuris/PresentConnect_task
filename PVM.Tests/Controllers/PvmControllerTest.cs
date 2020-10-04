using Xunit;
using NSubstitute;
using PVM.Api.Services.Interfaces;
using Technical_Task_Aurimas_Šernas.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PVM.Domain.DTOs;
using Shouldly;
using PVM.Domain.Params;

namespace PVM.Tests.Controllers
{
    public class PvmControllerTest
    {
        private readonly IPvmService _mockPvmService;
        private readonly ILogger<PvmController> _mockLogger;
        private readonly PvmController _target;
        public PvmControllerTest() 
        {
            this._mockPvmService = Substitute.For<IPvmService>();
            this._mockLogger = Substitute.For<ILogger<PvmController>>();

            this._target = new PvmController(this._mockLogger, this._mockPvmService);
        }

        [Fact]
        public void GenerateInvoice_NullInput_ReturnsNotFoundResult()
        {
            _mockPvmService.GenerateInvoice(null).Returns((InvoiceDto)null);

            var actual = this._target.GenerateInvoice(null);

            actual.Result.ShouldBeOfType<NotFoundResult>();
        }

        [Fact]
        public void GenerateInvoice_NoCustomer_ReturnsNotFoundResult()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = null,
                ServiceProviderName = "Amazon DE",
                Services = new List<string>() { "Prime" }
            };
            _mockPvmService.GenerateInvoice(input).Returns((InvoiceDto)null);

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeOfType<NotFoundResult>();
        }

        [Fact]
        public void GenerateInvoice_NoServiceProvider_ReturnsNotFoundResult()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = null,
                Services = new List<string>() { "Prime" }
            };
            _mockPvmService.GenerateInvoice(input).Returns((InvoiceDto)null);

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeOfType<NotFoundResult>();
        }

        [Fact]
        public void GenerateInvoice_NoServices_ReturnsNotFoundResult()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = "Amazon DE",
                Services = null
            };
            _mockPvmService.GenerateInvoice(input).Returns((InvoiceDto)null);

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeOfType<NotFoundResult>();
        }

        [Fact]
        public void GenerateInvoice_AllParams_ReturnsOkResult()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = "Amazon DE",
                Services = new List<string>() { "Prime" }
            };

            var result = new InvoiceDto();

            _mockPvmService.GenerateInvoice(input).Returns(result);

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeOfType<OkObjectResult>();
        }
    }
}
