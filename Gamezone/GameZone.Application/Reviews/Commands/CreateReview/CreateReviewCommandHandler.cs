using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
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

        public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReturnByIdAsync(request.UserId);
            var game = await _gameRepository.ReturnByIdAsync(request.GameId);
            var userDto = _mapper.Map<User>(user);
            var gameDto = _mapper.Map<Game>(game);
            var review = new Review { User = userDto, Game= gameDto, Content = request.Content, Rating = request.Rating };
            await _reviewRepository.CreateAsync(review);
            await _gameRepository.CalculateTotalRatingAsync(game);
            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;
        }
    }
}
