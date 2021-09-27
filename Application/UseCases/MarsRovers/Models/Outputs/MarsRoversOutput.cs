using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.MarsRovers.Models.Outputs
{
    public class MarsRoversOutput
    {
        public bool IsValid { get; set; }
        public List<string> ErrorNessages { get; set; }
        public object Result { get; set; }
    }
}
