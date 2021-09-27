using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp.Models
{
    public class TrainsRouteRequest
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public int Distance { get; set; }
    }
}
