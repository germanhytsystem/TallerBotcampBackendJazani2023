using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders.Profiles;
using Jazani.Application.Generals.Dtos.Investmentconcepts.Profiles;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Application.Generals.Dtos.Investments.Profiles;
using Jazani.Application.Generals.Dtos.Investmenttypes.Profiles;
using Jazani.Application.Generals.Dtos.Measureunits.Profiles;
using Jazani.Application.Generals.Dtos.Miningconcessions.Profiles;
using Jazani.Application.Generals.Dtos.Periodtypes.Profiles;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementatios;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class InvestmentServiceTest
    {

        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>> _mockILogger;

        IMapper? _mapper;
        Fixture? _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<InvestmentconceptProfile>();
                c.AddProfile<MiningconcessionProfile>();
                c.AddProfile<PeriodtypeProfile>();
                c.AddProfile<MeasureunitProfile>();
                c.AddProfile<InvestmenttypeProfile>();
                c.AddProfile<HolderProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockInvestmentRepository = new Mock<IInvestmentRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>>();
        }



        [Fact]
        public async void returnInvestmentDtoWhenFindByIdAsync()
        {

            // Arrange
            Investment investment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);


            // Act
            IInvestmentService? investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto? investmentDto = await investmentService.FindByIdAsync(investment.Id);

            // Assert
            Assert.Equal(investment.Description, investmentDto.Description);
        }


        [Fact]
        public async void returnInvestmentDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5)
                .ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);

            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.FindAllAsync();

            // Assert
            Assert.Equal(investments.Count, investmentDtos.Count);
        }


        [Fact]
        public async void returnInvestmentDtoWhenCreateAsync()
        {

            // Arrage
            Investment investment = new()
            {
                Id = 1,
                Description = "s",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                Description = investment.Description,
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.CreateAsync(investmentSaveDto);


            // Assert
            Assert.Equal(investment.Description, investmentDto.Description);
        }


        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = id,
                Description = "s",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                Description = investment.Description
            };

            IInvestmentService? investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.EditAsync(id, investmentSaveDto);


            // Assert
            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void returnInvestmentDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = id,
                Description = "s",
                State = false,
                RegistrationDate = DateTime.Now
            };


            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.DisabledAsync(id);


            // Assert
            Assert.Equal(investment.State, investmentDto.State);
        }


    }
}
