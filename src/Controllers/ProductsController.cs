using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Resources;
using Supermarket.API.Services;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(AppDbContext context, IProductService productService, IMapper mapper, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets the ProductList <see cref="IEnumerable{ProductResource}"/> instance from the given assembly.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        /// <summary>
        /// Gets the ProductDetail <see cref="ProductResource"/> instance from the given assembly.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailAsync(int id)
        {
            var result = await _productService.DetailAsync(id);
            var resource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(resource);
        }

        /// <summary>
        /// Save the ProductInfo 
        /// <see cref="ProductResource"/> 200
        /// <see cref="ErrorResource"/> 400
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Update the ProductInfo 
        /// <see cref="ProductResource"/> 200
        /// <see cref="ErrorResource"/> 400
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if(!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var productResource = _mapper.Map<Product,ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Delete the ProductInfo 
        /// <see cref="ProductResource"/> 200
        /// <see cref="ErrorResource"/> 400
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if(!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }
    }
}