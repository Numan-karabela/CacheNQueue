using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.Delete;
using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Med.ProductMed.Update;
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
        [HttpPut("DeleteId")]
        public async Task<IActionResult> Delete(ProductDeleteCommandRequest request)
        {

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("Gett")]
        public async Task<IActionResult> GettAll()
        {
            ProductGettAllQueryRequest request = new ProductGettAllQueryRequest();

            return Ok(await mediator.Send(request));
        }

        [HttpPut("UpdateId")]
        public async Task<IActionResult> Update( ProductUpdateCommandRequest request)
        {
            ProductUpdateCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }


    }
}
