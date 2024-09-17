using ConnecTor_Back.Dtos;
using ConnecTor_Back.Queries;
using ConnecTor_Back.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConnecTor_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public UserController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }


        [HttpGet("{userId}/conversations")]
        public async Task<IActionResult> GetUserConversations(int userId)
        {
            var query = new GetUserConversationsQuery(userId);
            var conversations = await _mediator.Send(query);

            if (conversations == null || !conversations.Any())
            {
                return NotFound("No conversations found.");
            }

            return Ok(conversations);
        }

        [HttpGet("{userId1}/messages/{userId2}")]
        public async Task<IActionResult> GetUserMessages(int userId1, int userId2)
        {
            var query = new GetUserMessagesQuery(userId1, userId2);
            var messages = await _mediator.Send(query); 

            if (messages == null || !messages.Any())
            {
                return NotFound("No messages found between the specified users.");
            }

            return Ok(messages);
        }

    }
}