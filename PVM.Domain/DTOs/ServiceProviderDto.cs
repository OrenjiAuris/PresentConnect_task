namespace PVM.Domain.DTOs
{
    public class ServiceProviderDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool VatPayer { get; set; }
        public string Country { get; set; }
    }
}
