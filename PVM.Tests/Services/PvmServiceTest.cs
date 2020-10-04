using Microsoft.Extensions.Logging;
using NSubstitute;
using PVM.Domain.Params;
using Shouldly;
using System.Collections.Generic;
using Technical_Task_Aurimas_Šernas.Services;
using Xunit;

namespace PVM.Tests.Services
{
    public class PvmServiceTest
    {
        private readonly ILogger<PvmService> _mockLogger;
        private readonly PvmService _target;

        public PvmServiceTest() 
        {
            this._mockLogger = Substitute.For<ILogger<PvmService>>();

            this._target = new PvmService(this._mockLogger);
        }

        [Fact]
        public void GenerateInvoice_NullInput_ReturnsNull()
        {
            var actual = this._target.GenerateInvoice(null);

            actual.Result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void GenerateInvoice_NullCustomer_ReturnsNull()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = null,
                ServiceProviderName = "Amazon DE",
                Services = new List<string>() { "Prime" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void GenerateInvoice_NullServiceProvider_ReturnsNull()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = null,
                Services = new List<string>() { "Prime" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void GenerateInvoice_NullServices_ReturnsNull()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = "Amazon DE",
                Services = null
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void GenerateInvoice_NotVatPayer_ReturnsInvoiceWithVat0()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = "Air",
                Services = new List<string>() { "Fast Internet" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.VatPercent.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void GenerateInvoice_OutsideEU_ReturnsInvoiceWithVat0()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "John Jonny",
                ServiceProviderName = "Amazon DE",
                Services = new List<string>() { "Prime" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.VatPercent.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void GenerateInvoice_DifferentCountriesCustomerNotVatpayer_ReturnsInvoiceWithVat21()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "That Jonny",
                ServiceProviderName = "Amazon DE",
                Services = new List<string>() { "Prime" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.VatPercent.ShouldBeEquivalentTo(21);
        }

        [Fact]
        public void GenerateInvoice_DifferentCountriesCustomerVatpayer_ReturnsInvoiceWithVat0()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "Flip Conner",
                ServiceProviderName = "Amazon DE",
                Services = new List<string>() { "Prime" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.VatPercent.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void GenerateInvoice_SameCountry_ReturnsInvoiceWithVat0()
        {
            var input = new InvoiceBuilderParams()
            {
                CustomerName = "Flip Conner",
                ServiceProviderName = "Amazon LT",
                Services = new List<string>() { "Prime" }
            };

            var actual = this._target.GenerateInvoice(input);

            actual.Result.VatPercent.ShouldBeEquivalentTo(21);
        }
    }
}
