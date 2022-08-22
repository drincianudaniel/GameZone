using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.UserRepository.ReturnByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(result);
            return userDto;
        }
    }
}
