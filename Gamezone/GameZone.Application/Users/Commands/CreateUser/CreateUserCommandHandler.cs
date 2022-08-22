using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper=mapper;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Email = request.Email, Username = request.Username, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName, Role = request.Role};
            await _userRepository.CreateAsync(user);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
