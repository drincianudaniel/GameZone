using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Email = request.Email, Username = request.Username, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName, Role = request.Role};
            
            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
