using Application.UseCases.MarsRovers.Models.Commands;
using Application.UseCases.MarsRovers.Models.Mapper;
using Application.UseCases.MarsRovers.Models.Outputs;
using Infrastructure.CardinalMap.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.MarsRovers
{
    public class MarsRoversCommandHandler : IMarsRoversCommandHandler
    {
        private readonly ILogger<MarsRoversCommandHandler> _logger;
        private readonly ICardinalMap _cardinalMap;
        public MarsRoversCommandHandler(ILogger<MarsRoversCommandHandler> logger, ICardinalMap cardinalMap)
        {
            _logger = logger;
            _cardinalMap = cardinalMap;
        }
        public async Task<MarsRoversOutput> Handle(MarsRoversCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin mars rover handler");

            var output = new MarsRoversOutput();

            var result = new MarsRoversResultOutput();

            try
            {
                result.Rovers = new List<RoverResult>();

                var roversCommand = request.Rovers;

                _cardinalMap.SetLimit(request.LimitX, request.LimitY);

                foreach (var roverCommand in roversCommand)
                {
                    var rover = roverCommand.RoverCommandMap();
                    _cardinalMap.ExecuteRoverCommand(rover);

                    RoverResult roverResult = new RoverResult()
                    {
                        Position = rover.PositionX.ToString() + " " + rover.PositionY.ToString() + " " + rover.PositionZ
                    };

                    result.Rovers.Add(roverResult);
                }

                output.IsValid = true;

                output.Result = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on mars rover handler");
                output.ErrorNessages.Add(ex.ToString());
            }

            return output;
        }
    }
}
