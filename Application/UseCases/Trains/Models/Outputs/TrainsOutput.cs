using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Trains.Models.Outputs
{
    public class TrainsOutput
    {
        public bool IsValid { get; set; }
        public List<string> ErrorNessages { get; set; }
        public object Result { get; set; }
    }
}
