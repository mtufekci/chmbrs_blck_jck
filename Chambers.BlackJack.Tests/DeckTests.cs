using System.Linq;
using Chambers.BlackJack.Common.Domain;
using FluentAssertions;
using Xunit;

namespace Chambers.BlackJack.Tests
{
    public class DeckTests
    {
        private Deck _deck;
        private readonly int _numberOfCards = 52;

        [Fact]
        public void Deck_Should_Have_52_Cards()
        {
            Given_Deck();
            Then_Deck_Should_Contain_52_Cards();
        }

        [Fact]
        public void Deck_Should_Contains_Unique_Cards()
        {
            Given_Deck();
            Then_Deck_Should_Contain_Unique_Cards();
        }

        [Fact]
        public void Deck_Should_Give_Away_One_Card_At_A_Time()
        {
            Given_Deck();
            When_The_Card_Is_Taken();
            Then_Deck_Should_Contain_One_Less_Card();
        }
        
        private void Given_Deck()
        {
            _deck = new Deck();
        } 
        
        private void When_The_Card_Is_Taken()
        {
            _deck.TakeACard();
        }
        
        private void Then_Deck_Should_Contain_One_Less_Card()
        {
            _deck.Cards.Count.Should().Be(_numberOfCards - 1);
        }

        private void Then_Deck_Should_Contain_Unique_Cards()
        {
            _deck.Cards
                .Select(n => _deck.Cards.
                    Where(x => x != n)
                    .Contains(n))
                .Count()
                .Should()
                .Be(_numberOfCards);
        }

        private void Then_Deck_Should_Contain_52_Cards()
        {
            _deck.Cards.Count.Should().Be(_numberOfCards);
        }
    }
}