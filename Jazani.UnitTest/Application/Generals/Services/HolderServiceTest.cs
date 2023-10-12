using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Application.Generals.Dtos.Holders.Profiles;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementatios;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class HolderServiceTest
    {

            Mock<IHolderRepository> _mockHolderRepository;
            Mock<Microsoft.Extensions.Logging.ILogger<HolderService>> _mockILogger;

            IMapper? _mapper;
            Fixture? _fixture;
            
            public HolderServiceTest()
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
                {
                    c.AddProfile<HolderProfile>();
   
                });

                _mapper = mapperConfiguration.CreateMapper();

                _fixture = new Fixture();
                _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


                _mockHolderRepository = new Mock<IHolderRepository>();

                _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<HolderService>>();
            }



            [Fact]
            public async void returnHolderDtoWhenFindByIdAsync()
            {

                // Arrange
                Holder holder = _fixture.Create<Holder>();

                _mockHolderRepository
                    .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(holder);


                // Act
                IHolderService? holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

                HolderDto? holderDto = await holderService.FindByIdAsync(holder.Id);

                // Assert
                Assert.Equal(holder.Name, holderDto.Name);
            }


            [Fact]
            public async void returnHolderDtoWhenFindAllAsync()
            {
                // Arrage
                IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5)
                    .ToList();

                _mockHolderRepository
                    .Setup(r => r.FindAllAsync())
                    .ReturnsAsync(holders);

                // Act
                IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

                IReadOnlyList<HolderDto> holderDtos = await holderService.FindAllAsync();

                // Assert
                Assert.Equal(holders.Count, holderDtos.Count);
            }


            [Fact]
            public async void returnHolderDtoWhenCreateAsync()
            {

                // Arrage
                Holder holder = new()
                {
                    Id = 1,
                    Name = "Creado by SS",
                    LastName = "SS",
                    Maidenname = "SSS",
                    Districtid = '5',
                    State = true,
                    RegistrationDate = DateTime.Now
                };       

                _mockHolderRepository
                    .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                    .ReturnsAsync(holder);


                // Act
                HolderSaveDto holderSaveDto = new()
                {
                    Name=holder.Name,
                    LastName=holder.LastName,
                    Maidenname=holder.Maidenname,
                    Districtid=holder.Districtid,
                };

                IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

                HolderDto holderDto = await holderService.CreateAsync(holderSaveDto);


                // Assert
                Assert.Equal(holder.Name, holderDto.Name);
            }


            [Fact]
            public async void returnHolderDtoWhenEditAsync()
            {

                // Arrage
                int id = 1;

                Holder holder = new()
                {
                    Id = id,
                    Name = "Creado by SSS",
                    LastName = "SSS",
                    Maidenname = "SSSS",
                    Districtid = '6',
                };


                _mockHolderRepository
                    .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(holder);

                _mockHolderRepository
                    .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                    .ReturnsAsync(holder);

                // Act
                HolderSaveDto holderSaveDto = new()
                {
                    Name = holder.Name,
                    LastName = holder.LastName,
                    Maidenname = holder.Maidenname,
                    Districtid = holder.Districtid,
                };

                IHolderService? holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

                HolderDto holderDto = await holderService.EditAsync(id, holderSaveDto);


                // Assert
                Assert.Equal(holder.Id, holderDto.Id);
            }


            [Fact]
            public async void returnHolderDtoWhenDisabledAsync()
            {

                // Arrage
                int id = 1;

                Holder holder = new()
                {
                    Id = id,
                    State = false,
                    RegistrationDate = DateTime.Now
                };


                _mockHolderRepository
                    .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(holder);

                _mockHolderRepository
                    .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                    .ReturnsAsync(holder);


                // Act
                IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

                HolderDto holderDto = await holderService.DisabledAsync(id);


                // Assert
                Assert.Equal(holder.State, holderDto.State);
            }
    }
}
