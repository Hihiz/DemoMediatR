using DemoMediatR.Models;
using DemoMediatR.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            User user = await _mediator.Send(command);

            return Ok(user);
        }
    }
}
