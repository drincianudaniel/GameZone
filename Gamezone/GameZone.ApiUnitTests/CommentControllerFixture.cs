using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Comments.Commands.CreateComment;
using GameZone.Application.Comments.Commands.DeleteComment;
using GameZone.Application.Comments.Commands.UpdateComment;
using GameZone.Application.Comments.Queries.GetCommentById;
using GameZone.Application.Comments.Queries.GetCommentsList;
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
    public class CommentControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<CommentsController>> _mockLogger = new Mock<ILogger<CommentsController>>();

        [Fact]
        public async Task Get_All_Comments_GetAllCommentsListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCommentsListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetComments();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetCommentsListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Comment_By_Id_GetCommentByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCommentByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetById(new Guid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetCommentByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Comment_By_Id_GetCommentByIdQueryWithCorrectCommentIdIsCalled()
        {
            //Arrange
            var commentId = new Guid();

            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetCommentByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetCommentByIdQuery, CancellationToken>(async (q, c) =>
               {
                   commentId = q.Id;
                   return await Task.FromResult(
                       new Comment
                       {
                           Id = q.Id,
                           Content = "very good game test",
                       });
               });

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);

            //Assert
            Assert.Equal(commentId, guid);
        }

        [Fact]
        public async Task Get_Comment_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetCommentByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Comment
                {
                    Id = guid,
                    Content = "very good game test"
                });

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Comment_By_Id_ShouldReturnFoundComment()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var comment = new Comment
            {
                Id = guid,
                Content = "very good game test"
            };


            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCommentByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(comment);

            _mockMapper.Setup(m => m.Map<CommentDto>(It.IsAny<Comment>()))
                .Returns(new CommentDto
                {
                    Id = guid,
                    Content = "very good game test"
                });

            var mappedComment = _mockMapper.Object.Map<CommentDto>(comment);

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(mappedComment.Id, ((CommentDto)okResult.Value).Id);
            Assert.Equal(mappedComment.Content, ((CommentDto)okResult.Value).Content);
        }

        [Fact]
        public async Task CallPost_ReturnsCommentDto()
        {

            //Arrange
            var user = new User
            {
                Id = new Guid("9155dc31-8e4b-46ef-ae91-97d81fc4afa8"),
                FirstName = "test user",
                UserName = "test user username"
            };

            var game = new Game
            {
                Id = new Guid("39dadaf7-373c-4562-94ad-4df6ae1f1719"),
                Name = "Game name"
            };

            var createCommentCommand = new CommentViewModel
            {
                Content = "good game test good game",
                UserId = user.Id,
                GameId = game.Id
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateCommentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Comment
                {
                    Content = "good game test good game",
                    UserId = user.Id,
                    User = user,
                    GameId = game.Id,
                    Game = game
                });

            _mockMapper.Setup(m => m.Map<CommentDto>(It.IsAny<Comment>()))
                .Returns(new CommentDto
                {
                    Content = "good game test good game",
                    UserName = user.UserName,
                    Gamename = game.Name,
                });

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.CreateComment(createCommentCommand);
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.Equal(createCommentCommand.Content, ((CommentDto)createdAtActionResult.Value).Content);
            Assert.Equal(user.UserName, ((CommentDto)createdAtActionResult.Value).UserName);
            Assert.Equal(game.Name, ((CommentDto)createdAtActionResult.Value).Gamename);
        }

      /*  [Fact]
        public async Task Delete_Comment_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var comment = new Comment
            {
                Id = guid,
                Content = "very good game test"
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeleteCommentCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(comment.Id);

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.DeleteComment(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }*/

        [Fact]
        public async Task Update_Comment_Should_Return_OkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var user = new User
            {
                Id = new Guid("9155dc31-8e4b-46ef-ae91-97d81fc4afa8"),
                FirstName = "test user",
                UserName = "test user username"
            };

            var game = new Game
            {
                Id = new Guid("39dadaf7-373c-4562-94ad-4df6ae1f1719"),
                Name = "Game name"
            };

            var updateCommentCommand = new CommentViewModel
            {
                Content = "good game test good game",
                UserId = user.Id,
                GameId = game.Id
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<UpdateCommentCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Comment
             {
                 Content = "good game test good game",
                 UserId = user.Id,
                 GameId = game.Id
             });

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.UpdateComment(guid, updateCommentCommand);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Update_Comment_Should_Return_UpdatedComment()
        {

            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var user = new User
            {
                Id = new Guid("9155dc31-8e4b-46ef-ae91-97d81fc4afa8"),
                FirstName = "test user",
                UserName = "test user username"
            };

            var game = new Game
            {
                Id = new Guid("39dadaf7-373c-4562-94ad-4df6ae1f1719"),
                Name = "Game name"
            };

            var updateCommentCommand = new CommentViewModel
            {
                Content = "good game test good game",
                UserId = user.Id,
                GameId = game.Id
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<UpdateCommentCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Comment
             {
                 Content = "good game test good game",
                 UserId = user.Id,
                 GameId = game.Id
             });

            _mockMapper.Setup(m => m.Map<CommentDto>(It.IsAny<Comment>()))
              .Returns(new CommentDto
              {
                  Content = "good game test good game",
                  UserName = user.UserName,
                  Gamename = game.Name
              });

            //Act
            var controller = new CommentsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            var result = await controller.UpdateComment(guid, updateCommentCommand);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(updateCommentCommand.Content, ((CommentDto)okResult.Value).Content);
            Assert.Equal(user.UserName, ((CommentDto)okResult.Value).UserName);
            Assert.Equal(game.Name, ((CommentDto)okResult.Value).Gamename);
        }
    }
}