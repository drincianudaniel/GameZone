using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _userRepository.ReturnByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(result);
            return userDto;
        }
    }
}
