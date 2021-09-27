using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Graphs
{
    internal class Point
    {
        IList<PointConnection> _pointsConnections;

        internal string Name { get; private set; }

        internal double DistanceFromStart { get; set; }

        internal IEnumerable<PointConnection> Connections
        {
            get { return _pointsConnections; }
        }

        internal Point(string name)
        {
            Name = name;
            _pointsConnections = new List<PointConnection>();
        }

        internal void AddConnection(Point targetNode, double distance)
        {
            _pointsConnections.Add(new PointConnection(targetNode, distance));
            
        }
        internal double GetConnectionDistance(Point targetNode)
        {
            double distance = 0;

            if (_pointsConnections.Where(c => c.TargetPoint == targetNode).Count() > 0)
                distance = _pointsConnections.FirstOrDefault(c => c.TargetPoint == targetNode).Distance;

            return distance;
        }
    }
}
