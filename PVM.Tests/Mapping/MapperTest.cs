using PVM.Api.Mapping;
using PVM.Domain.DTOs;
using Shouldly;
using Xunit;

namespace PVM.Tests.Mappers
{
    public class MapperTest
    {
        [Fact]
        public void MapInvoiceCustomerDto_CustomerDtoPassed_ReturnsInvoiceCustomerDto()
        {
            CustomerDTO customer = new CustomerDTO();

            var actual = Mapper.MapInvoiceCustomerDto(customer);

            actual.ShouldBeOfType<InvoiceCustomerDto>();
        }

        [Fact]
        public void MapInvoiceServiceProviderDto_ServiceProviderDtoPassed_ReturnsInvoiceServiceProviderDto()
        {
            ServiceProviderDTO serviceProvider = new ServiceProviderDTO();

            var actual = Mapper.MapInvoiceServiceProviderDto(serviceProvider);

            actual.ShouldBeOfType<InvoiceServiceProviderDto>();
        }
    }
}
