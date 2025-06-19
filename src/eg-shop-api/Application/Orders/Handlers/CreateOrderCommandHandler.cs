namespace EgShopApi.Application.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement order creation logic here, e.g., save to database
            // For now, return a dummy order id
            return Task.FromResult(1);
        }
    }
}
