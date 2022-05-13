using System;
using Catalog.domain.Commands;
using Catalog.domain.Interfaces;
using Catalog.domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private IHandler _handler;
        private IProductRepository _productRepository;

        public ProductController(IHandler handler, IProductRepository productRepository)
        {
            _handler = handler;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productRepository.GetProducts();
                return Ok(products);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            if (id < 1)
                return BadRequest("Id inválido");

            try
            {
                var product = _productRepository.GetProduct(id);
                return Ok(product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar banco de dados");
            }
        }

        [HttpPost("Product")]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var response = _handler.Handle(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}