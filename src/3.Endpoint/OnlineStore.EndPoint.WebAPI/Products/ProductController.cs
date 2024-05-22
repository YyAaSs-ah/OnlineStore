using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.RequestResponse.Products.Create;

namespace OnlineStore.EndPoint.WebAPI.Products;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateProduct createProduct)
    {
        var result = await mediator.Send(createProduct);
        return Ok(result);
    }

    [HttpPatch("IncreaseCount")]
    public async Task<IActionResult> IncreaseCount([FromBody] IncreaseProductCount increaseProductCount)
    {
        var result = await mediator.Send(increaseProductCount);
        return Ok(result);
    }
}
