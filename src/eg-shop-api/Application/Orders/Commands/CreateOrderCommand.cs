namespace EgShopApi.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int GroceryId { get; set; }
        public int Quantity { get; set; }
    }
}
