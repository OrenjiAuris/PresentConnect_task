namespace PVM.Domain.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public bool LegalEntity { get; set; }
        public bool EuropianUnion { get; set; }
        public bool VatPayer { get; set; }
    }
}
