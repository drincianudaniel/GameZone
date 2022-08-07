using GameZoneModels;
using MediatR;

namespace GameZone.Application.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Guid>
    {
        private readonly IDeveloperRepository _developerRepository;

        public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public Task<Guid> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Developer { Name = request.Name, Headquarters = request.HeadQuarters };
            _developerRepository.Create(developer);
            
            return Task.FromResult(developer.Id);
        }
    }
}
