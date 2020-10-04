using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PVM.Domain.DTOs;

namespace PVM.Api.DataStores
{
    public class CountriesDataStore : ControllerBase
    {
        public static CountriesDataStore Current { get; } = new CountriesDataStore();
        public List<CountryDto> Countries { get; set; }

        public CountriesDataStore()
        {
            Countries = new List<CountryDto>()
            {
                new CountryDto() 
                {
                    Name = "USA",
                    Tax = 10
                },
                new CountryDto()
                {
                    Name = "Lithuania",
                    Tax = 21
                },
                new CountryDto()
                {
                    Name = "Germany",
                    Tax = 19
                },
                new CountryDto()
                {
                    Name = "UK",
                    Tax = 20
                }
            };
        }
    }
}
