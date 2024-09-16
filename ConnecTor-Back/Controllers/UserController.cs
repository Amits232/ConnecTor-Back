using ConnecTor_Back.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConnecTor_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var userDto = await _mediator.Send(query);

            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }
    }
}