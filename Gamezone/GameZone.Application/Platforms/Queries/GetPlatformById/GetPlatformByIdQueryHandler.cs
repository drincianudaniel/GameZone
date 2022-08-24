using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, Platform>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlatformByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Platform> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.PlatformRepository.ReturnByIdAsync(id);
            return result;
        }
    }
}
