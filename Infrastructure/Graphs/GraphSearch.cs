using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Graphs
{
    public class GraphSearch : IGraphSearch
    {
        private const string NoRoute = "NO SUCH ROUTE";
        public string GetDistanceRoute(Graph graph, string[] points)
        {
            double result = 0;
            int items = points.Length;

            //string currentPoint = points.FirstOrDefault();
            for(var x = 0; x < items-1; x++)
            {
                double routeValue = 0;
                routeValue = graph.GetConnectionDistance(points[x], points[x + 1]);
                if (routeValue == 0)
                    return NoRoute;
                else
                    result += routeValue;
            }

            return result.ToString();
        }

        public int GetNumberOfTripsWithMaximumStop(Graph graph, string startPoint, string endPoint, int numberOfStop)
        {
            int result = 0;

            int stop = 1;

            
            Point startNode = graph.Points[startPoint];

            //RecursiveNumberOfTrips(graph, startNode, endPoint, numberOfStop);
            if (stop <= numberOfStop)
                foreach (var conection in startNode.Connections)
                {

                    if (conection.TargetPoint.Name == endPoint)
                        result += 1;
                    else
                        result += GetNumberOfTripsWithMaximumStop(graph, conection.TargetPoint.Name, endPoint, numberOfStop - 1);

                }

            return result;
        }

        public int GetNumberOfTripsWithExactlyStop(Graph graph, string startPoint, string endPoint, int numberOfStop)
        {
            int result = 0;

            int stop = 1;


            Point startNode = graph.Points[startPoint];

            //RecursiveNumberOfTrips(graph, startNode, endPoint, numberOfStop);
            if (stop <= numberOfStop)
                foreach (var conection in startNode.Connections)
                {

                    if (conection.TargetPoint.Name == endPoint && stop == numberOfStop)
                        result += 1;
                    else
                        result += GetNumberOfTripsWithExactlyStop(graph, conection.TargetPoint.Name, endPoint, numberOfStop - 1);

                }

            return result;
        }
        public double GetBetterDistance(Graph graph, string startPoint, string endPoint)
        {
            if(startPoint != endPoint)
            {
                var point = FindAllRouteFromTheStart(graph, startPoint);
                return point[endPoint];
            }
            else
            {
                List<double> routes = new List<double>();
                Point startNode = graph.Points[startPoint];

                foreach (var conection in startNode.Connections)
                {
                    var point = FindAllRouteFromTheStart(graph, conection.TargetPoint.Name);
                    routes.Add(conection.Distance + point[endPoint]);
                }

                return routes.Min();
            }
        }
        public IDictionary<string, double> FindAllRouteFromTheStart(Graph graph, string startingPoint)
        {
            BuildTheGraph(graph, startingPoint);
            return GetAllDistancesFromStart(graph);
        }

        private void BuildTheGraph(Graph graph, string startingPoint)
        {
            foreach (Point point in graph.Points.Values)
                point.DistanceFromStart = double.PositiveInfinity;
            graph.Points[startingPoint].DistanceFromStart = 0;

            bool finished = false;
            var queue = graph.Points.Values.ToList();
            while (!finished)
            {
                Point nextPoint = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));
                if (nextPoint != null)
                {
                    ProcessThePoint(nextPoint, queue);
                    queue.Remove(nextPoint);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessThePoint(Point point, List<Point> queue)
        {
            var pointConnections = point.Connections.Where(c => queue.Contains(c.TargetPoint));
            foreach (var connection in pointConnections)
            {
                double distance = point.DistanceFromStart + connection.Distance;
                if (distance < connection.TargetPoint.DistanceFromStart)
                    connection.TargetPoint.DistanceFromStart = distance;
            }
        }

        private IDictionary<string, double> GetAllDistancesFromStart(Graph graph)
        {
            return graph.Points.ToDictionary(n => n.Key, n => n.Value.DistanceFromStart);
        }
    }
}
