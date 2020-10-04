using PVM.Domain.DTOs;

namespace PVM.Api.Mapping
{
    public static class Mapper
    {
        public static InvoiceCustomerDto MapInvoiceCustomerDto(CustomerDTO customer) 
        {
            return new InvoiceCustomerDto()
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Country = customer.Country,
                BillingAddress = customer.BillingAddress,
                ShippingAddress = customer.ShippingAddress
            };
        }

        public static InvoiceServiceProviderDto MapInvoiceServiceProviderDto(ServiceProviderDTO serviceProvider)
        {
            return new InvoiceServiceProviderDto()
            {
                Name = serviceProvider.Name,
                PhoneNumber = serviceProvider.PhoneNumber,
                Email = serviceProvider.Email,
                Address = serviceProvider.Address,
                Country = serviceProvider.Country
            };
        }
    }
}
