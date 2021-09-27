using Application.UseCases.SalesTaxes.Models.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.SalesTaxes.Models.Commands
{
    public class SalesTaxesCommand : IRequest<SalesTaxesOutput>
    {
        public List<SalesTaxesItemCommand> Items { get; set; }
    }
}
