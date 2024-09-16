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
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var token = await _mediator.Send(loginRequest);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
        }
    }
}
