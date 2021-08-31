namespace ABBI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
