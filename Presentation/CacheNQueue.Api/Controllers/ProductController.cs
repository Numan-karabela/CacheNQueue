using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.Delete;
using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Med.ProductMed.GetById;
using CacheNQueue.Application.Med.ProductMed.Update;
using CacheNQueue.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace CacheNQueue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator mediator;
        readonly IDistributedCache _distributedCache;

        public ProductController(IMediator mediator, IDistributedCache distributedCache = null)
        {
            this.mediator = mediator;
            _distributedCache = distributedCache;
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

            ProductDeleteCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("UpdateId")]
        public async Task<IActionResult> Update(ProductUpdateCommandRequest request)
        {
            ProductUpdateCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("Gett")]
        public async Task<IActionResult> GettAll()
        {
            ProductGettAllQueryRequest request = new ProductGettAllQueryRequest();

            return Ok(await mediator.Send(request));
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GettById(Guid id)
        {
            ProductGetByIdQueryRequest request1 = new() { Id=id};
            ProductGetByIdQueryResponse response= await mediator.Send(request1);
            return Ok(response);
        }

    


    }
}
