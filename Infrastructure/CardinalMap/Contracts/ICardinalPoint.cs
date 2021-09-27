using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap.Contracts
{
    public interface ICardinalPoint
    {
        ICardinalPoint GetRight();
        ICardinalPoint GetLeft();
        void SetRight(ICardinalPoint next);
        void SetLeft(ICardinalPoint previous);
        char GetName();
        int GetValue();
    }
}
