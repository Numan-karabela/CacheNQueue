using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CacheNQueue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult>Add(ProductAddCommandReques reques)
        {
          ProductAddCommandResponse response= await mediator.Send(reques);
            return Ok(response);

        }


    }
}
