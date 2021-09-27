using Infrastructure.CardinalMap.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CardinalMap
{
    public class CardinalPoint : ICardinalPoint
    {
        private ICardinalPoint nextCardinalPoint;
        private ICardinalPoint previousCardinalPoint;
        private char _name;
        private int _value;
        public CardinalPoint(char name, int value)
        {
            _name = name;
            _value = value;
        }

        public char GetName()
        {
            return _name;
        }
        public int GetValue()
        {
            return _value;
        }
        public ICardinalPoint GetRight()
        {
            return nextCardinalPoint;
        }
        public ICardinalPoint GetLeft()
        {
            return previousCardinalPoint;
        }
        public void SetRight(ICardinalPoint next)
        {
            nextCardinalPoint = next;
        }
        public void SetLeft(ICardinalPoint previous)
        {
            previousCardinalPoint = previous;
        }
    }
}
