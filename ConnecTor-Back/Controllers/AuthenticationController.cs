using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConnecTor_Back.Requests;
using Microsoft.AspNetCore.Identity.Data;

namespace ConnecTor_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            var token = await _mediator.Send(loginQuery);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterQuery registerRequest)
        {
            var result = await _mediator.Send(registerRequest);
            if (result)
            {
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(new { Message = "Failed to register user" });
        }
    }
}
