using Application.UseCases.MarsRovers.Models.Commands;
using Application.UseCases.MarsRovers.Models.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MarsRovers
{
    public interface IMarsRoversCommandHandler : IRequestHandler<MarsRoversCommand, MarsRoversOutput> { }
}
