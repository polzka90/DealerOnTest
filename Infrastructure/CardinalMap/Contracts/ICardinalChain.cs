using Infrastructure.CardinalMap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap.Contracts
{
    public interface ICardinalChain
    {
        void MoveLeft();
        void MoveRight();
        void MoveFront(CoordinatePoint coordinatePoint);
        void SetCurrentCardinalPoint(char point);
        void SetLimit(int x, int y);
        char GetCurrentCardinalPoint();
    }
}
