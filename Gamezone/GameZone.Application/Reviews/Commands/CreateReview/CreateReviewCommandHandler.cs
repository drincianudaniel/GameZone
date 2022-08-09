using AutoMapper;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Reviews.Commands.CreateReview
{
    internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper, IGameRepository gameRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _gameRepository=gameRepository;
            _userRepository=userRepository;
        }

        public Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var userDto = _mapper.Map<User>(_userRepository.ReturnById(request.UserId));
            var gameDto = _mapper.Map<Game>(_gameRepository.ReturnById(request.GameId));
            var review = new Review { User = userDto, Game= gameDto, Content = request.Content, Rating = request.Rating };
            _reviewRepository.Create(review);
            return Task.FromResult(review.Id);
        }
    }
}
