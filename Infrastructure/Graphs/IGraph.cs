using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Graphs
{
    public interface IGraph
    {
        void AddConnection(string fromNode, string toNode, int distance);
    }
}
