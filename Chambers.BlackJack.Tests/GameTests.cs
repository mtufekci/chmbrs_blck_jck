using Chambers.BlackJack.Common.Domain;
using Chambers.BlackJack.Models;
using FluentAssertions;
using Xunit;

namespace Chambers.BlackJack.Tests
{
    public class GameTests
    {
        private Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void Game_Should_Start_With_Status_InPlay()
        {
            _game.Start();
            _game.Status.Should().Be(GameStatus.OnPlay);
        }        
        
        [Fact]
        public void Player_Should_Have_Score_And_Status()
        {
            var result = _game.Start();
            result.PlayerStatus.Status.Should().Be(WiningStatus.InGame);
            result.PlayerStatus.Score.Should().BeGreaterThan(0);
        }     
        
        [Fact]
        public void Dealer_Should_Have_Score_And_Status()
        {
            var result = _game.Start();
            result.DealerStatus.Status.Should().Be(WiningStatus.InGame);
            result.DealerStatus.Score.Should().BeGreaterThan(0);
        }
    }
}