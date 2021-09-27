using Application.UseCases.SalesTaxes.Models.Commands;
using Application.UseCases.SalesTaxes.Models.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.SalesTaxes
{
    public interface ISalesTaxesCommandHandler : IRequestHandler<SalesTaxesCommand, SalesTaxesOutput>
    {
    }
}
