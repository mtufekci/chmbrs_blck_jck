using System.Collections.Generic;

namespace Chambers.BlackJack.Common.Domain
{
    public class Hand
    {
        private readonly ScoreCalculator _scoreCalculator;
        private readonly List<Card> _cards;
        public Hand()
        {
            _scoreCalculator = new ScoreCalculator();
            _cards = new List<Card>();
        }
        
        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public short Score => _scoreCalculator.CalculateScore(_cards);

        public bool IsBust() => Score > 20;

    }
}