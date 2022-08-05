using GameZoneModels;
using MediatR;

namespace GameZone.Application.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, int>
    {
        private readonly IDeveloperRepository _developerRepository;

        public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public Task<int> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Developer(request.Name, request.HeadQuarters);
            _developerRepository.Create(developer);
            
            return Task.FromResult(developer.Id);
        }
    }
}
