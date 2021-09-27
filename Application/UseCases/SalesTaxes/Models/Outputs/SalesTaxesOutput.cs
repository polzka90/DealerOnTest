using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.SalesTaxes.Models.Outputs
{
    public class SalesTaxesOutput
    {
        public bool IsValid { get; set; }
        public List<string> ErrorNessages { get; set; }
        public object Result { get; set; }
    }
}
