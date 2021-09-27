using Infrastructure.CardinalMap.Contracts;
using Infrastructure.CardinalMap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap
{
    public class CardinalChain : ICardinalChain
    {
        private ICardinalPoint currentPoint;
        private const char North = 'N';
        private const char East = 'E';
        private const char Weast = 'W';
        private const char South = 'S';
        private int LimitX;
        private int LimitY;
        public CardinalChain()
        {
            var north = new CardinalPoint(North, 1);
            var east = new CardinalPoint(East, 1);
            var weast = new CardinalPoint(Weast, -1);
            var south = new CardinalPoint(South, -1);

            north.SetRight(east);
            north.SetLeft(weast);

            east.SetRight(south);
            east.SetLeft(north);

            weast.SetRight(north);
            weast.SetLeft(south);

            south.SetRight(weast);
            south.SetLeft(east);

            currentPoint = north;
        }

        public void MoveFront(CoordinatePoint coordinatePoint)
        {
            if ((currentPoint.GetName() == North || currentPoint.GetName() == South) && coordinatePoint.PositionY < LimitY)
                coordinatePoint.PositionY += currentPoint.GetValue();
            else if((currentPoint.GetName() == East || currentPoint.GetName() == Weast) && coordinatePoint.PositionX < LimitX)
                coordinatePoint.PositionX += currentPoint.GetValue();
        }

        public void MoveLeft()
        {
            currentPoint = currentPoint.GetLeft();
        }
        public void MoveRight()
        {
            currentPoint = currentPoint.GetRight();
        }
        public void SetCurrentCardinalPoint(char point)
        {
            while (currentPoint.GetName() != point)
                MoveRight();
        }

        public void SetLimit(int x, int y)
        {
            LimitX = x;
            LimitY = y;
        }

        public char GetCurrentCardinalPoint()
        {
            return currentPoint.GetName();
        }
    }
}
