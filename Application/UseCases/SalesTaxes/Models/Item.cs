using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.SalesTaxes.Models
{
    public class Item
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
