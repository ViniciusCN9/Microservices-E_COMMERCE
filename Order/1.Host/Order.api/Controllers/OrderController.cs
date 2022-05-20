using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.domain.Commands;
using Order.domain.Interfaces;

namespace Order.api.Controllers
{
    [ApiController]
    [Authorize(Roles = "CUSTOMER")]
    [Route("v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private IHandler _handler;

        public OrderController(IHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult CreateOrder()
        {
            try
            {
                var username = User.Claims.First().Value;
                var response = _handler.Handle(new CreateOrderRequest() { Username = username });
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Addproduct([FromBody] AddProductRequest request)
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

        [HttpPost("Remove")]
        public IActionResult RemoveProduct([FromBody] RemoveProductRequest request)
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