using MediatR;

namespace GameZone.Application.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, int>
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeleteDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public Task<int> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = _developerRepository.ReturnById(request.Id);
            _developerRepository.Delete(developer.Id);
            return Task.FromResult(developer.Id);
        }
    }
}
