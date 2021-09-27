using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.MarsRovers.Models.Commands
{
    public class RoverCommand
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public char PositionZ { get; set; }
        public string Command { get; set; }
    }
}
