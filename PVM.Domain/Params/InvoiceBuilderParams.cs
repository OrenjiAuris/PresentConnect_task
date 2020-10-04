using System.Collections.Generic;

namespace PVM.Domain.Params
{
    public class InvoiceBuilderParams
    {
        public string CustomerName { get; set; }
        public string ServiceProviderName { get; set; }
        public List<string> Services { get; set; }
    }
}
