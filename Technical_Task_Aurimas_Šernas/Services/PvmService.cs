using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PVM.Api.DataStores;
using PVM.Api.Mapping;
using PVM.Api.Services.Interfaces;
using PVM.Domain.DTOs;
using PVM.Domain.Params;
using Technical_Task_Aurimas_Šernas.Api.DataStores;

namespace Technical_Task_Aurimas_Šernas.Services
{
    public class PvmService : IPvmService
    {
        private readonly ILogger<PvmService> _logger;
        private static Random random = new Random();
        public PvmService(ILogger<PvmService> logger) 
        {
            _logger = logger;
        }

        public async Task<InvoiceDto> GenerateInvoice(InvoiceBuilderParams properties) 
        {
            try
            {
                ServiceProviderDTO serviceProvider = ServiceProvidersDataStore.Current.ServiceProviders.Single(a => a.Name == properties.ServiceProviderName);
                CustomerDTO customer = CustomersDataStore.Current.Customers.Single(a => a.Name == properties.CustomerName);

                if (serviceProvider != null && customer != null)
                {
                    List<ServiceDto> services = new List<ServiceDto>();
                    foreach (var service in properties.Services)
                    {
                        services.Add(ServicesDataStore.Current.Services.Single(a => a.Name == service && a.ServiceProvider == serviceProvider.Name));
                    }

                    if (services.Count > 0)
                    {
                        InvoiceDto invoice = new InvoiceDto();

                        invoice.InvoiceId = RandomString(16);
                        invoice.InvoiceDate = DateTime.Now;
                        invoice.Customer = Mapper.MapInvoiceCustomerDto(customer);
                        invoice.ServiceProvider = Mapper.MapInvoiceServiceProviderDto(serviceProvider);
                        invoice.Services = services;
                        invoice.SubTotalPrice = CalculateAmount(invoice.Services);
                        invoice.Discount = 0;
                        invoice.VatPercent = GetVatPercent(customer, serviceProvider);
                        invoice.VatTax = CalculateVatTax(invoice);
                        invoice.TotalAmount = CalculateTotalAmount(invoice);

                        return invoice;
                    }
                }

                return null;
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private decimal CalculateAmount(List<ServiceDto> services) 
        {
            decimal total = 0;
            foreach (var service in services)
            {
                total += service.Price;
            }
            return total;
        }

        private int GetVatPercent(CustomerDTO customer, ServiceProviderDTO serviceProvider) 
        {
            if (!serviceProvider.VatPayer)
            {
                return 0;
            }
            if (serviceProvider.VatPayer) {
                if (!customer.EuropianUnion)
                {
                    return 0;
                }
                else if (customer.EuropianUnion && !customer.VatPayer && customer.Country != serviceProvider.Country)
                {
                    return CountriesDataStore.Current.Countries.Single(a => a.Name == customer.Country).Tax;
                }
                else if (customer.EuropianUnion && customer.VatPayer && customer.Country != serviceProvider.Country)
                {
                    return 0;
                }
                else if (customer.EuropianUnion && customer.Country == serviceProvider.Country)
                {
                    return CountriesDataStore.Current.Countries.Single(a => a.Name == customer.Country).Tax;
                }
            }

            return 0;
        }

        private decimal CalculateVatTax(InvoiceDto invoice) 
        {
            if (invoice.VatPercent > 0)
            {
                return (invoice.SubTotalPrice - invoice.Discount) * (decimal)invoice.VatPercent / 100;

            }
            return 0;
        }

        private decimal CalculateTotalAmount(InvoiceDto invoice) 
        {
            return invoice.SubTotalPrice - invoice.Discount + invoice.VatTax;
        }
    }
}
