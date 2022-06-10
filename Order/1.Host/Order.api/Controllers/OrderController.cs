using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.domain.Commands;
using Order.domain.Interfaces;
using Order.domain.Repositories;

namespace Order.api.Controllers
{
    [ApiController]
    [Authorize(Roles = "CUSTOMER")]
    [Route("v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private IHandler _handler;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IHandler handler, IOrderRepository orderRepository)
        {
            _handler = handler;
            _orderRepository = orderRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrder([FromRoute] int id)
        {
            if (id < 0)
                return BadRequest();

            try
            {
                var username = User.Claims.First().Value;
                var response = _orderRepository.GetOrder(id, username);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
                var username = User.Claims.First().Value;
                var response = _handler.Handle(request, username);
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
                var username = User.Claims.First().Value;
                var response = _handler.Handle(request, username);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Finish")]
        public IActionResult FinishOrder([FromBody] FinishOrderRequest request)
        {
            try
            {
                var username = User.Claims.First().Value;
                var response = _handler.Handle(request, username);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}