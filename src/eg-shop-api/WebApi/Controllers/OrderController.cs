using MediatR;
using Microsoft.AspNetCore.Mvc;
using EgShopApi.Application.Orders.Commands;
using System.Threading.Tasks;

namespace EgShopApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
    }
}
