using System.Collections.Generic;
using Chambers.BlackJack.Common.Domain;
using FluentAssertions;
using Xunit;

namespace Chambers.BlackJack.Tests
{
    public class HandTests
    {
        private Hand _hand;

        [Theory]
        [MemberData(nameof(Data))]
        public void Score_Should_Calculated_Correctly(List<Card> cards, short expectedScore)
        {
            Given_Hand();
            Given_Cards(cards);
            var score = When_Calculate_Score(); 
            score.Should().Be(expectedScore);
            _hand.IsBust().Should().Be(expectedScore > 20);
        }

        private void Given_Hand()
        {
            _hand = new Hand();
        }

        private short When_Calculate_Score()
        {
            return _hand.Score;
        }

        private void Given_Cards(List<Card> cards)
        {
           cards.ForEach(n=> _hand.AddCard(n));
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Card>
                    {
                        new Card {Face = Face.Ace, Suit = Suit.Clubs},
                        new Card {Face = Face.Jack, Suit = Suit.Clubs},
                        new Card {Face = Face.Five, Suit = Suit.Clubs},
                    },
                    16
                },                
                new object[]
                {
                    new List<Card>
                    {
                        new Card {Face = Face.Ace, Suit = Suit.Clubs},
                        new Card {Face = Face.Ace, Suit = Suit.Hearts}
                    },
                    12
                },                
                new object[]
                {
                    new List<Card>
                    {
                        new Card {Face = Face.Ace, Suit = Suit.Clubs},
                        new Card {Face = Face.Queen, Suit = Suit.Diamonds},
                        new Card {Face = Face.Nine, Suit = Suit.Spades}
                    },
                    20
                },
                new object[]
                {
                    new List<Card>
                    {
                        new Card {Face = Face.Ace, Suit = Suit.Clubs},
                        new Card {Face = Face.Jack, Suit = Suit.Diamonds},
                        new Card {Face = Face.Queen, Suit = Suit.Diamonds},
                    },
                    21
                },  
            };        
        
    }
}