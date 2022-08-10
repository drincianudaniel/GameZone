using MediatR;

namespace GameZone.Application.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, Guid>
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeleteDeveloperCommandHandler(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public async Task<Guid> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.ReturnByIdAsync(request.Id);
            await _developerRepository.DeleteAsync(developer);
            return developer.Id;
        }
    }
}
