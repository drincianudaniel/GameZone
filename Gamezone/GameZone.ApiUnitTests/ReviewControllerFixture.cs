using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Reviews.Commands.CreateReview;
using GameZone.Application.Reviews.Commands.DeleteReview;
using GameZone.Application.Reviews.Commands.UpdateReview;
using GameZone.Application.Reviews.Queries.GetReviewById;
using GameZone.Application.Reviews.Queries.GetReviewsList;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.ApiUnitTests
{
    public class ReviewControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<ReviewController>> _mockLogger = new Mock<ILogger<ReviewController>>();

        [Fact]
        public async Task Get_All_Reviews_GetAllReviewsListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReviewsListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetReviews();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetReviewsListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Reviews_By_Id_GetReviewsByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetById(new Guid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Review_By_Id_GetReviewyIdQueryWithCorrectReviewIdIsCalled()
        {
            //Arrange
            var reviewId = new Guid();

            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetReviewByIdQuery, CancellationToken>(async (q, c) =>
               {
                   reviewId = q.Id;
                   return await Task.FromResult(
                       new Review
                       {
                           Id = q.Id,
                       });
               });

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);

            //Assert
            Assert.Equal(reviewId, guid);
        }

        [Fact]
        public async Task Get_Review_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Review
                {
                    Id = guid,
                    Content = "good game test good game",
                    Rating = 10
                });

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Review_By_Id_ShouldReturnFoundReview()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var review = new Review
            {
                Id = guid,
                Content = "good game test good game",
                Rating = 10
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReviewByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(review);

            _mockMapper.Setup(m => m.Map<ReviewDto>(It.IsAny<Review>()))
              .Returns(new ReviewDto
              {
                  Id = guid,
                  Content = "good game test good game",
                  Rating = 10
              });

            var mappedReview = _mockMapper.Object.Map<ReviewDto>(review);

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(mappedReview.Id, ((ReviewDto)okResult.Value).Id);
            Assert.Equal(mappedReview.Content, ((ReviewDto)okResult.Value).Content);
            Assert.Equal(mappedReview.Rating, ((ReviewDto)okResult.Value).Rating);
        }

        [Fact]
        public async Task CallPost_ReturnsReviewDto()
        {
            //Arrange
            var user = new User
            {
                Id = new Guid("9155dc31-8e4b-46ef-ae91-97d81fc4afa8"),
                FirstName = "test user",
                Username = "test user username"
            }; 
            
            var game = new Game
            {
                Id = new Guid("39dadaf7-373c-4562-94ad-4df6ae1f1719"),
                Name = "Game name"
            };

            var createReviewCommand = new ReviewViewModel
            {
                Content = "good game test good game",
                Rating = 10,
                UserId = user.Id,
                GameId = game.Id
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateReviewCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Review
                {
                    Content = "good game test good game",
                    Rating = 10,
                    UserId = user.Id,
                    User = user,
                    GameId = game.Id,
                    Game = game
                });

            _mockMapper.Setup(m => m.Map<ReviewDto>(It.IsAny<Review>()))
                .Returns(new ReviewDto
                {
                    Content = "good game test good game",
                    Rating = 10,
                    Username = user.Username,
                    Gamename = game.Name,
                });
            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.CreateReview(createReviewCommand);
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.Equal(createReviewCommand.Content, ((ReviewDto)createdAtActionResult.Value).Content);
            Assert.Equal(createReviewCommand.Rating, ((ReviewDto)createdAtActionResult.Value).Rating);
            Assert.Equal(user.Username, ((ReviewDto)createdAtActionResult.Value).Username);
            Assert.Equal(game.Name, ((ReviewDto)createdAtActionResult.Value).Gamename);
        }

        [Fact]
        public async Task Delete_Review_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var review = new Review
            {
                Id = guid,
                Content = "good game test good game",
                Rating = 10
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeleteReviewCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(review.Id);

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.DeleteReview(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task Update_Review_Should_Return_OkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var user = new User
            {
                Id = new Guid("9155dc31-8e4b-46ef-ae91-97d81fc4afa8"),
                FirstName = "test user",
                Username = "test user username"
            };

            var game = new Game
            {
                Id = new Guid("39dadaf7-373c-4562-94ad-4df6ae1f1719"),
                Name = "Game name"
            };

            var updateReviewCommand = new ReviewViewModel
            {
                Content = "good game test good game",
                Rating = 10,
                UserId = user.Id,
                GameId = game.Id
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<UpdateReviewCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Review
             {
                 Id = guid,
                 Content = "good game test good game",
                 Rating = 10,
                 UserId = user.Id,
                 GameId = game.Id
             });

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.UpdateReview(guid, updateReviewCommand);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Update_Review_Should_Return_UpdatedReview()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var user = new User
            {
                Id = new Guid("9155dc31-8e4b-46ef-ae91-97d81fc4afa8"),
                FirstName = "test user",
                Username = "test user username"
            };

            var game = new Game
            {
                Id = new Guid("39dadaf7-373c-4562-94ad-4df6ae1f1719"),
                Name = "Game name"
            };

            var updateReviewCommand = new ReviewViewModel
            {
                Content = "good game test good game",
                Rating = 10,
                UserId = user.Id,
                GameId = game.Id
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<UpdateReviewCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Review
             {
                 Id = guid,
                 Content = "good game test good game",
                 Rating = 10,
                 UserId = user.Id,
                 GameId = game.Id
             });

            _mockMapper.Setup(m => m.Map<ReviewDto>(It.IsAny<Review>()))
              .Returns(new ReviewDto
              {
                  Content = "good game test good game",
                  Rating = 10,
                  Username = user.Username,
                  Gamename = game.Name
              });

            //Act
            var controller = new ReviewController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.UpdateReview(guid, updateReviewCommand);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(updateReviewCommand.Content, ((ReviewDto)okResult.Value).Content);
            Assert.Equal(updateReviewCommand.Rating, ((ReviewDto)okResult.Value).Rating);
            Assert.Equal(user.Username, ((ReviewDto)okResult.Value).Username);
            Assert.Equal(game.Name, ((ReviewDto)okResult.Value).Gamename);
        }
    }
}