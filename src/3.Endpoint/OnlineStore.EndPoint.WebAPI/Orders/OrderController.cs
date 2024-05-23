using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.RequestResponse.Orders.Create;

namespace OnlineStore.EndPoint.WebAPI.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
       
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrder createOrder)
        {
            var result = await mediator.Send(createOrder);
            return Ok(result);
        }
    }
}
