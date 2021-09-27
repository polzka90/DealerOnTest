using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Graphs
{
    public class Graph : IGraph
    {
        internal IDictionary<string, Point> Points { get; private set; }

        public Graph()
        {
            Points = new Dictionary<string, Point>();
        }
        public Graph(string[] points)
        {
            Points = new Dictionary<string, Point>();
            foreach(var point in points)
            {
                this.AddPoint(point);
            }
        }
        public void AddPoint(string name)
        {
            if(!Points.ContainsKey(name))
            Points.Add(name, new Point(name));
        }

        public void AddConnection(string fromNode, string toNode, int distance)
        {
            Points[fromNode].AddConnection(Points[toNode], distance);
        }

        public double GetConnectionDistance(string point, string connection)
        {
            return Points[point].GetConnectionDistance(Points[connection]);
        }
    }
}
