using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Users.Commands.AddFavoriteGame;
using GameZone.Application.Users.Commands.AddRoleToUser;
using GameZone.Application.Users.Commands.CreateUser;
using GameZone.Application.Users.Commands.DeleteUser;
using GameZone.Application.Users.Commands.RemoveFavoriteGame;
using GameZone.Application.Users.Queries.FindUserByName;
using GameZone.Application.Users.Queries.GetUserById;
using GameZone.Application.Users.Queries.GetUsersList;
using GameZone.Application.Users.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;
        public UsersController(IMediator mediator, IMapper mapper, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _mapper=mapper;
            _logger=logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Getting item {id}", id);

            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<UserDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            _logger.LogInformation("Getting user {username}", username);

            var query = new FindUserByNameQuery
            {
                UserName = username,
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ProfileUserDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation("Getting users list");

            var result = await _mediator.Send(new GetUsersListQuery());
            var mappedResult = _mapper.Map<IEnumerable<UserDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserViewModel user)
        {
            _logger.LogInformation("Registering user");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new FindUserByNameQuery
            {
                UserName = user.UserName,
            };

            var userFound = await _mediator.Send(query);

            if (userFound != null)
                return BadRequest("User already exists");

            var command = new CreateUserCommand
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                ProfileImageSrc = user.ProfileImageSrc,
            };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<UserDto>(result);

            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginViewModel user)
        {
            _logger.LogInformation("Login user");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new LoginUserQuery
            {
                UserName = user.UserName,
                Password = user.Password
            };

            var result = await _mediator.Send(query);

            if(result == "Unauthorized")
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("assign-role/user/{userName}/role/{roleName}")]
        public async Task<IActionResult> AddRoleToUser(string userName, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new FindUserByNameQuery
            {
                UserName = userName,
            };

            var userFound = await _mediator.Send(query);

            if (userFound == null)
                return BadRequest("User not found");

            var command = new AddRoleToUserCommand
            {
                UserName = userName,
                RoleName = roleName
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("Failed to add role to user");
            }

            return Ok($"{userName} added successfully to {roleName} role");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            _logger.LogInformation("Deleting user with id {id}", id);

            var command = new DeleteUserCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Route("{userid}/games/{gameid}")]
        public async Task<IActionResult> AddGameToFavorite(Guid userid, Guid gameid)
        {
            _logger.LogInformation("Adding game with id {gameid} to user with id {userid}", gameid, userid);

            var command = new AddFavoriteGameCommand
            {
                GameId = gameid,
                UserId = userid
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{userid}/games/{gameid}")]
        public async Task<IActionResult> RemoveGameFromFavorite(Guid userid, Guid gameid)
        {
            _logger.LogInformation("Removing game with id {gameid} from user with id {userid}", gameid, userid);

            var command = new RemoveFavoriteGameCommand
            {
                GameId = gameid,
                UserId = userid
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
