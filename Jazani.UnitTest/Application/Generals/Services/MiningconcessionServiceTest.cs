using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Miningconcessions;
using Jazani.Application.Generals.Dtos.Miningconcessions.Profiles;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementatios;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class MiningconcessionServiceTest
    {
        Mock<IMiningconcessionRepository> _mockMiningconcessionRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<MiningconcessionService>> _mockILogger;

        IMapper? _mapper;
        Fixture? _fixture;

        public MiningconcessionServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MiningconcessionProfile>();
              
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockMiningconcessionRepository = new Mock<IMiningconcessionRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<MiningconcessionService>>();
        }



        [Fact]
        public async void returnMiningconcessiontDtoWhenFindByIdAsync()
        {

            // Arrange
            Miningconcession miningconcession = _fixture.Create<Miningconcession>();

            _mockMiningconcessionRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(miningconcession);


            // Act
            IMiningconcessionService? miningconcessionService = new MiningconcessionService(_mockMiningconcessionRepository.Object, _mapper, _mockILogger.Object);

            MiningconcessionDto? miningconcessionDto = await miningconcessionService.FindByIdAsync(miningconcession.Id);

            // Assert
            Assert.Equal(miningconcession.Description, miningconcessionDto.Description);
        }


        [Fact]
        public async void returnMiningconcessionDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Miningconcession> investments = _fixture.CreateMany<Miningconcession>(5)
                .ToList();

            _mockMiningconcessionRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);

            // Act
            IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockMiningconcessionRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<MiningconcessionDto> investmentDtos = await miningconcessionService.FindAllAsync();

            // Assert
            Assert.Equal(investments.Count, investmentDtos.Count);
        }


        [Fact]
        public async void returnMiningconcessionDtoWhenCreateAsync()
        {

            // Arrage
            Miningconcession miningconcession = new()
            {
                Id = 1,
                Code= "101",
                Name="Mining",
                Description = "mining",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockMiningconcessionRepository
                .Setup(r => r.SaveAsync(It.IsAny<Miningconcession>()))
                .ReturnsAsync(miningconcession);


            // Act
            MiningconcessionSaveDto investmentSaveDto = new()
            {
                Description = miningconcession.Description,
            };

            IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockMiningconcessionRepository.Object, _mapper, _mockILogger.Object);

            MiningconcessionDto miningconcessionDto = await miningconcessionService.CreateAsync(investmentSaveDto);


            // Assert
            Assert.Equal(miningconcession.Description, miningconcessionDto.Description);
        }


        [Fact]
        public async void returnMiningconcessionDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            Miningconcession miningconcession = new()
            {
                Id = id,
                Code = "101",
                Name = "Miningconcession",
                Description = "miningconcession",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockMiningconcessionRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(miningconcession);

            _mockMiningconcessionRepository
                .Setup(r => r.SaveAsync(It.IsAny<Miningconcession>()))
                .ReturnsAsync(miningconcession);

            // Act
            MiningconcessionSaveDto investmentSaveDto = new()
            {
                Description = miningconcession.Description
            };

            IMiningconcessionService? miningconcessionService = new MiningconcessionService(_mockMiningconcessionRepository.Object, _mapper, _mockILogger.Object);

            MiningconcessionDto miningconcessionDto = await miningconcessionService.EditAsync(id, investmentSaveDto);


            // Assert
            Assert.Equal(miningconcession.Id, miningconcessionDto.Id);
        }

        [Fact]
        public async void returnMiningconcessionDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Miningconcession miningconcession = new()
            {
                Id = id,
                State = false,
                RegistrationDate = DateTime.Now
            };


            _mockMiningconcessionRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(miningconcession);

            _mockMiningconcessionRepository
                .Setup(r => r.SaveAsync(It.IsAny<Miningconcession>()))
                .ReturnsAsync(miningconcession);


            // Act
            IMiningconcessionService miningconcessionService = new MiningconcessionService(_mockMiningconcessionRepository.Object, _mapper, _mockILogger.Object);

            MiningconcessionDto miningconcessionDto = await miningconcessionService.DisabledAsync(id);


            // Assert
            Assert.Equal(miningconcession.State, miningconcessionDto.State);
        }


    }
}

