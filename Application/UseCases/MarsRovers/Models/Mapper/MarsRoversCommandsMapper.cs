using Application.UseCases.MarsRovers.Models.Commands;
using Infrastructure.CardinalMap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.MarsRovers.Models.Mapper
{
    public static class MarsRoversCommandsMapper
    {
        public static Rover RoverCommandMap(this RoverCommand rover)
        {
            return new Rover()
            {
                Command = rover.Command,
                PositionX = rover.PositionX,
                PositionY = rover.PositionY,
                PositionZ = rover.PositionZ
            };
        }
    }
}
