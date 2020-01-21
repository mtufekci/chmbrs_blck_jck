using System.Collections.Generic;
using Chambers.BlackJack.Common;
using Chambers.BlackJack.Common.Domain;
using FluentAssertions;
using Xunit;

namespace Chambers.BlackJack.Tests
{
    public class ScoreCalculatorTests
    {
        private ScoreCalculator _calculator;

        [Theory]
        [MemberData(nameof(Data))]
        public void Score_Should_Calculated_Correctly(List<Card> cards, short expectedScore)
        {
            Given_Calculator();
            short score = When_Calculator_Calculate(cards);
            score.Should().Be(expectedScore);
        }

        private short When_Calculator_Calculate(List<Card> cards)
        {
           return _calculator.CalculateScore(cards);
        }

        private void Given_Calculator()
        {
            _calculator = new ScoreCalculator();
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
                }
            };
    }
}