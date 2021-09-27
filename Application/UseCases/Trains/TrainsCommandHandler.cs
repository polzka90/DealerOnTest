using Application.UseCases.Trains.Models.Commands;
using Application.UseCases.Trains.Models.Outputs;
using Infrastructure.Graphs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Trains
{
    public class TrainsCommandHandler : ITrainsCommandHandler
    {
        private readonly ILogger<TrainsCommandHandler> _logger;
        private readonly IGraphSearch _graphSearch;
        private Graph _graph;

        public TrainsCommandHandler(ILogger<TrainsCommandHandler> logger,
            IGraph graph,
            IGraphSearch graphSearch)
        {
            _logger = logger;
            _graphSearch = graphSearch;
            _graph = (Graph)graph;
        }
        public async Task<TrainsOutput> Handle(TrainsCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin trains handler");

            var output = new TrainsOutput();

            var result = new TrainsResultOutput();

            try
            {
                ConnectionsDefinition(command.Routes);

                result.Output1 = _graphSearch.GetDistanceRoute(_graph, new string[] { "A", "B", "C" });
                result.Output2 = _graphSearch.GetDistanceRoute(_graph, new string[] { "A", "D" });
                result.Output3 = _graphSearch.GetDistanceRoute(_graph, new string[] { "A", "D", "C" });
                result.Output4 = _graphSearch.GetDistanceRoute(_graph, new string[] { "A", "E", "B", "C", "D" });
                result.Output5 = _graphSearch.GetDistanceRoute(_graph, new string[] { "A", "E", "D" });
                result.Output6 = _graphSearch.GetNumberOfTripsWithMaximumStop(_graph, "C", "C", 3).ToString();
                result.Output7 = _graphSearch.GetNumberOfTripsWithExactlyStop(_graph, "A", "C", 4).ToString();
                result.Output8 = _graphSearch.GetBetterDistance(_graph, "A", "C").ToString();
                result.Output9 = _graphSearch.GetBetterDistance(_graph, "B", "B").ToString();
                output.IsValid = true;

                output.Result = result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Error on trains handler");
                output.ErrorNessages.Add(ex.ToString());
            }
            
            return output;
        }

        private void ConnectionsDefinition(List<TrainsRoute> routes)
        {
            foreach (var route in routes)
            {
                _graph.AddConnection(route.StartPoint, route.EndPoint, route.Distance);
            }
        }
    }
}
