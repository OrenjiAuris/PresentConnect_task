using System;
using System.Collections.Generic;

namespace PVM.Domain.DTOs
{
    public class InvoiceDto
    {
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceCustomerDto Customer { get; set; }
        public InvoiceServiceProviderDto ServiceProvider { get; set; }
        public List<ServiceDto> Services { get; set; }
        public decimal SubTotalPrice { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public int VatPercent { get; set; } = 0;
        public decimal VatTax { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
    }
}
