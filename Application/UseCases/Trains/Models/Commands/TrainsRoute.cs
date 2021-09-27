using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Trains.Models.Commands
{
    public class TrainsRoute
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public int Distance { get; set; }
    }
}
