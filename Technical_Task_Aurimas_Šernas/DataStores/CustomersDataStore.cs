using System.Collections.Generic;
using PVM.Domain.DTOs;

namespace Technical_Task_Aurimas_Šernas.Api.DataStores
{
    public class CustomersDataStore
    {
        public static CustomersDataStore Current { get; } = new CustomersDataStore();
        public List<CustomerDTO> Customers { get; set; }

        public CustomersDataStore() 
        {
            Customers = new List<CustomerDTO>()
            {
                new CustomerDTO()
                {
                    Name = "John Jonny",
                    Email = "john@example.com",
                    PhoneNumber = "(999) 999 999",
                    Country = "USA",
                    BillingAddress = "street 1, 11597",
                    ShippingAddress = "street 1, 11597",
                    LegalEntity = false,
                    EuropianUnion = false,
                    VatPayer = false
                },
                new CustomerDTO()
                {
                    Name = "That Jonny",
                    Email = "that@example.com",
                    PhoneNumber = "(999) 999 999",
                    Country = "Lithuania",
                    BillingAddress = "street 2, 15915",
                    ShippingAddress = "street 2, 15915",
                    LegalEntity = true,
                    EuropianUnion = true,
                    VatPayer = false
                },
                new CustomerDTO()
                {
                    Name = "Tom Cruise",
                    Email = "tom@example.com",
                    PhoneNumber = "(999) 999 999",
                    Country = "Germany",
                    BillingAddress = "street 2, 15915",
                    ShippingAddress = "street 2, 15915",
                    LegalEntity = true,
                    EuropianUnion = true,
                    VatPayer = true
                },
                new CustomerDTO()
                {
                    Name = "Flip Conner",
                    Email = "tom@example.com",
                    PhoneNumber = "(999) 999 999",
                    Country = "Lithuania",
                    BillingAddress = "street 2, 15915",
                    ShippingAddress = "street 2, 15915",
                    LegalEntity = true,
                    EuropianUnion = true,
                    VatPayer = true
                },
                new CustomerDTO()
                {
                    Name = "Beef Jerky",
                    Email = "beef@example.com",
                    PhoneNumber = "(999) 999 999",
                    Country = "UK",
                    BillingAddress = "street 2, 15915",
                    ShippingAddress = "street 2, 15915",
                    LegalEntity = true,
                    EuropianUnion = true,
                    VatPayer = true
                }
            };
        }
    }
}
