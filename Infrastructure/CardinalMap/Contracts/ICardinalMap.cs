using Infrastructure.CardinalMap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap.Contracts
{
    public interface ICardinalMap
    {
        void ExecuteRoverCommand(Rover rover);
        void SetLimit(int x, int y);

    }
}
