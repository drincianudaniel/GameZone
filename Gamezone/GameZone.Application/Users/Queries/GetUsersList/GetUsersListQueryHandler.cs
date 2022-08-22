using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.UserRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<UserDto>>(query);
            return mappedResult;
        }
    }
}
