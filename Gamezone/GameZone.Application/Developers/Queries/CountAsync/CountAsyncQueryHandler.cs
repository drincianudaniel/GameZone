using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Developers.Queries.CountAsync
{
    public class CountAsyncQueryHandler : IRequestHandler<CountAsyncQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountAsyncQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CountAsyncQuery request, CancellationToken cancellationToken)
        {
            var count = await _unitOfWork.DeveloperRepository.CountAsync();
            return count;
        }
    }
}
