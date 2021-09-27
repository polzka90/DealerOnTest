using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap.Models
{
    public class Rover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public char PositionZ { get; set; }
        public string Command { get; set; }
    }
}
