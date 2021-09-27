using Application.UseCases.Trains.Models.Commands;
using Application.UseCases.Trains.Models.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Trains
{
    public interface ITrainsCommandHandler : IRequestHandler<TrainsCommand, TrainsOutput>
    {
    }
}
