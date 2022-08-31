using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Genres.Commands.CreateGenre;
using GameZone.Application.Genres.Commands.DeleteGenre;
using GameZone.Application.Genres.Queries.GetGenreById;
using GameZone.Application.Genres.Queries.GetGenresList;
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
    public class GenreControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<GenresController>> _mockLogger = new Mock<ILogger<GenresController>>();
        private static IMapper _mapper;
        public GenreControllerFixture()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new GenreProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public async Task Get_All_Genres_GetAllGenresListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGenresListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            await controller.GetGenres();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetGenresListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Genre_By_Id_GetGenreByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            
            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            await controller.GetById(new Guid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Genre_By_Id_GetGenreByIdQueryWithCorrectGenreIdIsCalled()
        {
            //Arrange
            var genreId = new Guid();

            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetGenreByIdQuery, CancellationToken>(async (q, c) =>
               {
                   genreId = q.Id;
                   return await Task.FromResult(
                       new Genre
                       {
                           Id = q.Id,
                           Name = "Action"
                       });
               });

            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);
            
            //Assert
            Assert.Equal(genreId, guid);
        }

        [Fact]
        public async Task Get_Genre_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Genre
                {
                    Id = guid,
                    Name = "Action"
                });

            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Genre_By_Id_ShouldReturnFoundGenre()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var genre = new Genre
            {
                Id = guid,
                Name="Action"
            };

            var mappedGenre = _mapper.Map<GenreDto>(genre);

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGenreByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(genre);
            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            //Assert.Same(mappedGenre, (GenreDto)okResult.Value);
            //Assert.True(mappedGenre.Equals((GenreDto)okResult.Value));
            Assert.Equal(mappedGenre.Id, ((GenreDto)okResult.Value).Id);
            Assert.Equal(mappedGenre.Name, ((GenreDto)okResult.Value).Name);
        }

        [Fact]
        public async Task CallPost_ReturnsGenreDto()
        {
            //Arrange
            var createGenreCommand = new GenreViewModel
            {
                Name = "Action"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateGenreCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Genre
                {
                    Name = "Action"
                });

            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.CreateGenre(createGenreCommand);
            var createdAtActionResult = result as CreatedAtActionResult;
            //var genre = createdAtActionResult.Value;

            //Assert
            Assert.Equal(createGenreCommand.Name, ((GenreDto)createdAtActionResult.Value).Name);
        }

        [Fact]
        public async Task Delete_Genre_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var genre = new Genre
            {
                Id = guid,
                Name="Action"
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeleteGenreCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(genre.Id);

            //Act
            var controller = new GenresController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.DeleteGenre(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }
    }
}