using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp.Models
{
    public class TrainsRequest
    {
        public List<TrainsRouteRequest> Routes { get; set; }
    }
}
