using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.SalesTaxes.Models.Outputs
{
    public class SalesTaxesResultOutput
    {
        public List<SalesTaxesItem> Items { get; set; }
        public double SalesTaxes { get; set; }
        public double Total { get; set; }
    }
}
