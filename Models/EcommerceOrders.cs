using System;

namespace EcommerceIntegrationAPI.Models
{
    public class EcommerceOrder
    {
        public int Id { get; set; }
        public string Platform { get; set; }
        public long PlatformOrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SyncStatus { get; set; }
        public string RawJson { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
