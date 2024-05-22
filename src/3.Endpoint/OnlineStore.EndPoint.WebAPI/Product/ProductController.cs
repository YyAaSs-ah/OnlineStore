using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.RequestResponse.Products.Create;

namespace OnlineStore.EndPoint.WebAPI.Product;

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
}
