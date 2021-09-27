using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Graphs
{
    public interface IGraphSearch
    {
        IDictionary<string, double> FindAllRouteFromTheStart(Graph graph, string startingPoint);
        string GetDistanceRoute(Graph graph, string[] points);
        int GetNumberOfTripsWithMaximumStop(Graph graph, string startPoint, string endPoint, int numberOfStop);

        int GetNumberOfTripsWithExactlyStop(Graph graph, string startPoint, string endPoint, int numberOfStop);

        double GetBetterDistance(Graph graph, string startPoint, string endPoint);
    }
}
