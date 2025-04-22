namespace EgShopApi.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int GroceryId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
