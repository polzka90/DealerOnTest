using Infrastructure.CardinalMap.Contracts;
using Infrastructure.CardinalMap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap
{
    public class CardinalMap : ICardinalMap
    {
        private readonly ICardinalChain _cardinalChain;

        private const char MoveCommand = 'M';
        private const char LeftCommand = 'L';
        private const char RightCommand = 'R';

        public CardinalMap(ICardinalChain cardinalChain)
        {
            _cardinalChain = cardinalChain;
        }

        public void ExecuteRoverCommand(Rover rover)
        {
            var commands = rover.Command.ToCharArray();
            _cardinalChain.SetCurrentCardinalPoint(rover.PositionZ);

            CoordinatePoint coordinatePoint = new CoordinatePoint()
            {
                PositionX = rover.PositionX,
                PositionY = rover.PositionY
            };


            foreach(char c in commands)
            {
                if (c == MoveCommand)
                    _cardinalChain.MoveFront(coordinatePoint);
                else if (c == LeftCommand)
                    _cardinalChain.MoveLeft();
                else
                    _cardinalChain.MoveRight();
            }
            rover.PositionX = coordinatePoint.PositionX;
            rover.PositionY = coordinatePoint.PositionY;
            rover.PositionZ = _cardinalChain.GetCurrentCardinalPoint();

        }

        public void SetLimit(int x, int y)
        {
            _cardinalChain.SetLimit(x, y);
        }
    }
}
