using System;
using System.Collections.Generic;
using System.Linq;

namespace Chambers.BlackJack.Common.Domain
{
    public class Deck
    {
        private readonly Random _random;
        public Stack<Card> Cards { get; private set; }

        public Deck()
        {
            _random = new Random();
            Reset();
        }
        
        public Card TakeACard() => Cards.Pop();
        
        private void Reset()
        {
            var cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                    .Select(f => new Card
                    {
                        Suit = (Suit) s,
                        Face = (Face) f
                    }));
            cards = Shuffle(cards);
            Cards = new Stack<Card>(cards);
        }
        
        private IEnumerable<Card> Shuffle(IEnumerable<Card> cards) => cards.OrderBy(n => _random.Next());
    }
}