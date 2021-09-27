using Application.UseCases.Trains.Models.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Trains.Models.Commands
{
    public class TrainsCommand : IRequest<TrainsOutput>
    {
        public List<TrainsRoute> Routes { get; set; }
    }
}
