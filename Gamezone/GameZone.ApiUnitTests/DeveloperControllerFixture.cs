using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Developers.Commands.CreateDeveloper;
using GameZone.Application.Developers.Commands.DeleteDeveloper;
using GameZone.Application.Developers.Queries.GetDeveloperById;
using GameZone.Application.Developers.Queries.GetDevelopersList;
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
    public class DeveloperControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<DevelopersController>> _mockLogger = new Mock<ILogger<DevelopersController>>();
        private static IMapper _mapper;
        public DeveloperControllerFixture()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DeveloperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public async Task Get_All_Developers_GetAllDevelopersListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetDevelopersListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            await controller.GetDevelopers();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetDevelopersListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Developer_By_Id_GetDeveloperByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetDeveloperByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            await controller.GetById(new Guid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetDeveloperByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Developer_By_Id_GetDeveloperByIdQueryWithCorrectDeveloperIdIsCalled()
        {
            //Arrange
            var developerId = new Guid();

            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetDeveloperByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetDeveloperByIdQuery, CancellationToken>(async (q, c) =>
               {
                   developerId = q.Id;
                   return await Task.FromResult(
                       new Developer
                       {
                           Id = q.Id,
                           Name = "Ubisoft",
                           Headquarters = "Montreal"
                       });
               });

            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);

            //Assert
            Assert.Equal(developerId, guid);
        }

        [Fact]
        public async Task Get_Developer_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetDeveloperByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Developer
                {
                    Id = guid,
                    Name = "Ubisoft",
                    Headquarters = "Montreal"
                });

            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Developer_By_Id_ShouldReturnFoundPlatform()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var developer = new Developer
            {
                Id = guid,
                Name= "Ubisoft",
                Headquarters = "Montreal"
            };

            var mappedDeveloper = _mapper.Map<DeveloperDto>(developer);

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetDeveloperByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(developer);
            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            //Assert.Same(mappedGenre, (GenreDto)okResult.Value);
            //Assert.True(mappedGenre.Equals((GenreDto)okResult.Value));
            Assert.Equal(mappedDeveloper.Id, ((DeveloperDto)okResult.Value).Id);
            Assert.Equal(mappedDeveloper.Name, ((DeveloperDto)okResult.Value).Name);
            Assert.Equal(mappedDeveloper.Headquarters, ((DeveloperDto)okResult.Value).Headquarters);
        }

        [Fact]
        public async Task CallPost_ReturnsDeveloperDto()
        {
            //Arrange
            var createDeveloperCommand = new DeveloperViewModel
            {
                Name = "Ubisoft",
                HeadQuarters = "Montreal"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateDeveloperCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Developer
                {
                    Name = "Ubisoft",
                    Headquarters = "Montreal"
                });

            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            var result = await controller.CreateDeveloper(createDeveloperCommand);
            var createdAtActionResult = result as CreatedAtActionResult;
            //var genre = createdAtActionResult.Value;

            //Assert
            Assert.Equal(createDeveloperCommand.Name, ((DeveloperDto)createdAtActionResult.Value).Name);
            Assert.Equal(createDeveloperCommand.HeadQuarters, ((DeveloperDto)createdAtActionResult.Value).Headquarters);
        }

        [Fact]
        public async Task Delete_Platform_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var platform = new Developer
            {
                Id = guid,
                Name="Ubisoft",
                Headquarters = "Montreal"
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeleteDeveloperCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(platform.Id);

            //Act
            var controller = new DevelopersController(_mockMediator.Object, _mapper, _mockLogger.Object);
            var result = await controller.DeleteDeveloper(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }
    }
}