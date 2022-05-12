using System;
using Access.domain.Commands;
using Access.domain.Interfaces;
using Access.domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Access.api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private ICommandHandler _command;
        private IQueryHandler _query;

        public UserController(ICommandHandler command, IQueryHandler query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                var response = _command.Handle(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = _query.Handle(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}