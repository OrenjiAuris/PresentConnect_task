using System.Collections.Generic;
using PVM.Domain.DTOs;

namespace Technical_Task_Aurimas_Šernas.Api.DataStores
{
    public class ServicesDataStore
    {
        public static ServicesDataStore Current { get; } = new ServicesDataStore();
        public List<ServiceDto> Services { get; set; }

        public ServicesDataStore()
        {
            Services = new List<ServiceDto>()
            {
                new ServiceDto()
                {
                    Name = "Prime Video",
                    ServiceProvider ="Amazon DE",
                    Description = "Streaming Service",
                    Price = 5.99m
                },
                new ServiceDto()
                {
                    Name = "Prime Video",
                    ServiceProvider ="Amazon LT",
                    Description = "Streaming Service",
                    Price = 5.99m
                },
                new ServiceDto()
                {
                    Name = "Prime",
                    ServiceProvider ="Amazon DE",
                    Description = "Monthly subscription",
                    Price = 5.99m
                },
                new ServiceDto()
                {
                    Name = "Prime",
                    ServiceProvider ="Amazon LT",
                    Description = "Monthly subscription",
                    Price = 5.99m
                },
                new ServiceDto()
                {
                    Name = "Fast Internet",
                    ServiceProvider ="Air",
                    Description = "150 MBPs internet",
                    Price = 15.99m
                },
                new ServiceDto()
                {
                    Name = "Cable TV Plus",
                    ServiceProvider ="Air",
                    Description = "30 Channels",
                    Price = 10.99m
                }
            };
        }
    }
}
