using Application.UseCases.SalesTaxes.Models;
using Application.UseCases.SalesTaxes.Models.Commands;
using Application.UseCases.SalesTaxes.Models.Outputs;
using Infrastructure.Maths;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.SalesTaxes
{
    public class SalesTaxesCommandHandler : ISalesTaxesCommandHandler
    {
        private readonly ILogger<SalesTaxesCommandHandler> _logger;
        private readonly string[] BasicSalesTaxes = { "BOOK", "CHOCOLATE", "PILLS" };
        private const string Imported = "IMPORTED";
        public SalesTaxesCommandHandler(ILogger<SalesTaxesCommandHandler> logger)
        {
            _logger = logger;
        }
        public async Task<SalesTaxesOutput> Handle(SalesTaxesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin sales taxes handler");

            var output = new SalesTaxesOutput();

            var result = new SalesTaxesResultOutput();

            try
            {
                result.Items = new List<SalesTaxesItem>();

                List<Item> items = new List<Item>();

                items = request.Items.GroupBy(i => i.Description).Select(n => new Item
                {
                    Description = n.Key,
                    Quantity = n.Sum(i => i.Quantity),
                    Value = n.Sum(i => i.Value),
                }).ToList();

                double totalTax = 0;
                foreach (var i in items)
                {
                    double unitItemValue = i.Value / i.Quantity;
                    double basicTax = 0;
                    double importTax = 0;

                    if (!IsFoodOrBookOrMedicine(i.Description))
                        basicTax = unitItemValue * 0.1;

                    if (IsImported(i.Description))
                        importTax = unitItemValue * 0.05;

                    double itemTax = MathsUtils.Round(basicTax + importTax);
                    itemTax = MathsUtils.Round(itemTax + MathsUtils.RoundNearest(MathsUtils.Round((itemTax - Math.Truncate(itemTax)))));
                    totalTax += MathsUtils.Round(itemTax * i.Quantity);

                    i.Value = MathsUtils.Round((unitItemValue + itemTax) * i.Quantity);
                }

                result.Items = items.Select(i => new SalesTaxesItem
                {
                    Description = i.Description + ": " + i.Value + ( i.Quantity > 1 ?  "(" + i.Quantity + " @ " + i.Value/ i.Quantity + ")" : string.Empty )
                }).ToList();

                result.SalesTaxes = totalTax;

                result.Total = items.Sum(i => i.Value);

                output.IsValid = true;

                output.Result = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on sales taxes handler");
                output.ErrorNessages.Add(ex.ToString());
            }

            return output;
        }

        private bool IsFoodOrBookOrMedicine(string description)
        {
            return BasicSalesTaxes.Any(s => description.ToUpper().Contains(s));
        }
        private bool IsImported(string description)
        {
            return  description.ToUpper().Contains(Imported);
        }
    }
}
