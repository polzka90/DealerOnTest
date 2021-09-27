using Application.UseCases.MarsRovers.Models.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.MarsRovers.Models.Commands
{
    public class MarsRoversCommand : IRequest<MarsRoversOutput>
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }
        public List<RoverCommand> Rovers { get; set; }
    }
}
