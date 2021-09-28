using Application.UseCases.MarsRovers;
using Application.UseCases.MarsRovers.Models.Commands;
using Application.UseCases.MarsRovers.Models.Outputs;
using FluentAssertions;
using Infrastructure.CardinalMap;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting.UseCase
{
    public class MarsRoversCommandHandlerTest
    {
        private readonly MarsRoversCommandHandler marsRoversCommandHandler;
        private readonly Mock<ILogger<MarsRoversCommandHandler>> logger;
        public MarsRoversCommandHandlerTest()
        {
            logger = new Mock<ILogger<MarsRoversCommandHandler>>();
            marsRoversCommandHandler = new MarsRoversCommandHandler(logger.Object, new CardinalMap(
                new CardinalChain()
                ));
        }

        [Fact]
        public async Task ShouldBeReturnAValidOutputAndCorrectResult()
        {
            MarsRoversCommand marsRoversCommand = new MarsRoversCommand()
            {
                LimitX = 5,
                LimitY = 5,
                Rovers = new List<RoverCommand>()
                {
                    new RoverCommand()
                    {
                        PositionX = 1,
                        PositionY = 2,
                        PositionZ = 'N',
                        Command = "LMLMLMLMM"
                    }
                }
            };
            var output = await marsRoversCommandHandler.Handle(marsRoversCommand, new System.Threading.CancellationToken());

            output.IsValid.Should().BeTrue();
            output.ErrorNessages.Should().BeNullOrEmpty();

            output.Result.Should().NotBeNull();

            MarsRoversResultOutput marsRoversResultOutput = (MarsRoversResultOutput)output.Result;

            marsRoversResultOutput.Rovers.Should().NotBeNullOrEmpty();
            marsRoversResultOutput.Rovers.Count.Should().BeGreaterThan(0);

            var rover = marsRoversResultOutput.Rovers.FirstOrDefault();

            rover.Position.Should().Be("1 3 N");

        }
    }
}
