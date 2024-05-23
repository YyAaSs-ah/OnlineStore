using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.RequestResponse.Products.Create;
using OnlineStore.Core.RequestResponse.Products.GetDetail;
using OnlineStore.Core.RequestResponse.Products.IncreaseCount;

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
    [HttpGet("GetDetail")]
    public async Task<IActionResult> GetDetail([FromQuery]GetProductDetail getProductDetail)
    {
        var result = await mediator.Send(getProductDetail);
        return Ok(result);
    }
}
