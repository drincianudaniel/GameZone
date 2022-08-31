using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Platforms.Commands.CreatePlatform;
using GameZone.Application.Platforms.Commands.DeletePlatform;
using GameZone.Application.Platforms.Queries.GetPlatformById;
using GameZone.Application.Platforms.Queries.GetPlatformsList;
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
    public class PlatformControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<PlatformsController>> _mockLogger = new Mock<ILogger<PlatformsController>>();
        private static IMapper _mapper;
        public PlatformControllerFixture()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new PlatformProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public async Task Get_All_Platforms_GetAllPlatformsListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPlatformsListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            await controller.GetPlatforms();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetPlatformsListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Platform_By_Id_GetPlatformByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPlatformByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            await controller.GetById(new Guid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetPlatformByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Platform_By_Id_GetPlatformByIdQueryWithCorrectPlatformIdIsCalled()
        {
            //Arrange
            var platformId = new Guid();

            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetPlatformByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetPlatformByIdQuery, CancellationToken>(async (q, c) =>
               {
                   platformId = q.Id;
                   return await Task.FromResult(
                       new Platform
                       {
                           Id = q.Id,
                           Name = "PlayStation 4"
                       });
               });

            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);

            //Assert
            Assert.Equal(platformId, guid);
        }

        [Fact]
        public async Task Get_Platform_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetPlatformByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Platform
                {
                    Id = guid,
                    Name = "PlayStation 4"
                });

            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Platform_By_Id_ShouldReturnFoundPlatform()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var platform = new Platform
            {
                Id = guid,
                Name="PlayStation 4"
            };

            var mappedPlatform = _mapper.Map<PlatformDto>(platform);

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPlatformByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(platform);
            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            //Assert.Same(mappedGenre, (GenreDto)okResult.Value);
            //Assert.True(mappedGenre.Equals((GenreDto)okResult.Value));
            Assert.Equal(mappedPlatform.Id, ((PlatformDto)okResult.Value).Id);
            Assert.Equal(mappedPlatform.Name, ((PlatformDto)okResult.Value).Name);
        }

        [Fact]
        public async Task CallPost_ReturnsPlatformDto()
        {
            //Arrange
            var createPlatformCommand = new PlatformViewModel
            {
                Name = "PlayStation 4"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreatePlatformCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Platform
                {
                    Name = "PlayStation 4"
                });

            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.CreatePlatform(createPlatformCommand);
            var createdAtActionResult = result as CreatedAtActionResult;
            //var genre = createdAtActionResult.Value;

            //Assert
            Assert.Equal(createPlatformCommand.Name, ((PlatformDto)createdAtActionResult.Value).Name);
        }

        [Fact]
        public async Task Delete_Platform_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var platform = new Platform
            {
                Id = guid,
                Name="PlayStation 4"
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeletePlatformCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(platform.Id);

            //Act
            var controller = new PlatformsController(_mapper, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.DeletePlatform(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }
    }
}