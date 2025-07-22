namespace EcommerceIntegrationAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

        // Future: Platform sync tracking
        public string PlatformProductId { get; set; } = string.Empty;
        public string PlatformName { get; set; } = string.Empty; // e.g., "Shopify"
    }
}
