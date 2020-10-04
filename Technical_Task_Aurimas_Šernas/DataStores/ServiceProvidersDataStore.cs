using System.Collections.Generic;
using PVM.Domain.DTOs;

namespace Technical_Task_Aurimas_Šernas.Api.DataStores
{
    public class ServiceProvidersDataStore 
    {
        public static ServiceProvidersDataStore Current { get; } = new ServiceProvidersDataStore();
        public List<ServiceProviderDTO> ServiceProviders { get; set; }

        public ServiceProvidersDataStore()
        {
            ServiceProviders = new List<ServiceProviderDTO>()
            {
                new ServiceProviderDTO()
                {
                    Name = "Air",
                    PhoneNumber = "(999) 999 999",
                    Email = "air@air.co.uk",
                    Address = "London",
                    VatPayer = false,
                    Country = "UK",
                },
                new ServiceProviderDTO()
                {
                    Name = "Amazon DE",
                    PhoneNumber = "(999) 999 999",
                    Email = "amazonde@amazon.com",
                    Address = "berlin",
                    VatPayer = true,
                    Country = "Germany",
                },
                new ServiceProviderDTO()
                {
                    Name = "Amazon LT",
                    PhoneNumber = "(999) 999 999",
                    Email = "amazonlt@amazon.com",
                    Address = "Vilnius",
                    VatPayer = true,
                    Country = "Lithuania",
                }
            };
        }
    }
}
