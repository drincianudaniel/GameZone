using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Replies.Commands.CreateReply;
using GameZone.Application.Replies.Commands.DeleteReply;
using GameZone.Application.Replies.Queries.GetRepliesList;
using GameZone.Application.Replies.Queries.GetReplyById;
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
    public class ReplyControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<RepliesController>> _mockLogger = new Mock<ILogger<RepliesController>>();

        [Fact]
        public async Task Get_All_Replies_GetAllReviewsListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetRepliesListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetReplies();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetRepliesListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Reply_By_Id_GetReviewsByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReplyByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetById(new Guid());

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetReplyByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Reply_By_Id_GetReplyIdQueryWithCorrectReplyIdIsCalled()
        {
            //Arrange
            var replyId = new Guid();

            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetReplyByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetReplyByIdQuery, CancellationToken>(async (q, c) =>
               {
                   replyId = q.Id;
                   return await Task.FromResult(
                       new Reply
                       {
                           Id = q.Id,
                       });
               });

            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);

            //Assert
            Assert.Equal(replyId, guid);
        }

        [Fact]
        public async Task Get_Reply_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetReplyByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Reply
                {
                    Id = guid,
                    Content = "good game test good game",
                });

            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Reply_By_Id_ShouldReturnFoundReply()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var reply = new Reply
            {
                Id = guid,
                Content = "good game test good game",
            };

            

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetReplyByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(reply);

            _mockMapper.Setup(m => m.Map<ReplyDto>(It.IsAny<Reply>()))
              .Returns(new ReplyDto
              {
                  Id = guid,
                  Content = "good game test good game"
              });

            var mappedReply = _mockMapper.Object.Map<ReplyDto>(reply);
            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(mappedReply.Id, ((ReplyDto)okResult.Value).Id);
            Assert.Equal(mappedReply.Content, ((ReplyDto)okResult.Value).Content);
        }

        [Fact]
        public async Task CallPost_ReturnsReplyDto()
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

            var comment = new Comment
            {
                Id = new Guid("a71fef0e-2955-11ed-a261-0242ac120002"),
                Content = "comment test comment",
                User = user,
                UserId = user.Id,
                Game = game,
                GameId = game.Id
            };

            var createReplyCommand = new ReplyViewModel
            {
                Content = "good game test good game",
                UserId = user.Id,
                CommentId = game.Id
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateReplyCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Reply
                {
                    Content = "good game test good game",
                    UserId = user.Id,
                    User = user,
                    CommentId = comment.Id,
                    Comment = comment
                });

            _mockMapper.Setup(m => m.Map<ReplyDto>(It.IsAny<Reply>()))
             .Returns(new ReplyDto
             {
                 Content = "good game test good game",
                 Username = user.Username,
             });

            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.CreateReply(createReplyCommand);
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.Equal(createReplyCommand.Content, ((ReplyDto)createdAtActionResult.Value).Content);
            Assert.Equal(user.Username, ((ReplyDto)createdAtActionResult.Value).Username);
        }

        [Fact]
        public async Task Delete_Reply_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var reply = new Reply
            {
                Id = guid,
                Content = "good game test good game"
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeleteReplyCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(reply.Id);

            //Act
            var controller = new RepliesController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.DeleteReply(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }
    }
}