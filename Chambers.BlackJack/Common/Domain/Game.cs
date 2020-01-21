using System;
using Chambers.BlackJack.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Chambers.BlackJack.Common.Domain
{
    public class Game
    {
        private Dealer _dealer;
        private Player _player;
        private bool IsInPlay => Status != GameStatus.Completed;
        public GameStatus Status { get; private set; }

        public Game()
        {
            Reset();
        }

        private void Reset()
        {
            Status = GameStatus.OnPlay;
            _dealer = new Dealer();
            _player = new Player();
        }
        
        public ResultModel Start()
        {
            if (_dealer != null || _player != null) Reset();
            
            Reset();
            _player.Hit(_dealer.Deal());
            _player.Hit(_dealer.Deal());
            _dealer.Hit();
            _dealer.Hit();
            
            Status = GameStatus.OnPlay;
            return CheckStatus();
        }

        public ResultModel Hit()
        {
            if (IsInPlay)
            {
                _player.Hit(_dealer.Deal());

            }
            
            return CheckStatus();
        }

        public ResultModel Stick()
        {
            if (IsInPlay)
            {
                while (_dealer.Score < 17)
                {
                    _dealer.Hit();
                }
            }
            return CheckWinner();
        }

        private ResultModel CheckWinner()
        {
            var model = CheckStatus();
            if (!_player.IsBust && !_dealer.IsBust)
            {
                if (_player.Score > _dealer.Score)
                {
                    SetDealerLost(model);
                }
                
                else if (_player.Score < _dealer.Score)
                {
                    SetPlayerLost(model);
                }
                else
                {
                    SetDraw(model);
                }
            }
            return model;
        }

        private ResultModel CheckStatus()
        {
            var model = new ResultModel
            {
                PlayerStatus = {Score = _player.Score}, 
                DealerStatus = {Score = _dealer.Score},
                GameStatus =  IsInPlay ? GameStatus.OnPlay : GameStatus.Completed
                
            };

            if (_player.IsBust)
            {
                SetPlayerLost(model);
                return model;
            }

            if (_dealer.IsBust)
            {
                SetDealerLost(model);
                return model;
            }
            return model;
        }

        private void SetPlayerLost(ResultModel model)
        {
            model.PlayerStatus.Status = WiningStatus.Lost;
            model.DealerStatus.Status = WiningStatus.Won;
            SetCompleted(model);
        }

        private void SetDealerLost(ResultModel model)
        {
            model.PlayerStatus.Status = WiningStatus.Won;
            model.DealerStatus.Status = WiningStatus.Lost;
            SetCompleted(model);
        }
        private void SetDraw(ResultModel model)
        {
            model.PlayerStatus.Status = WiningStatus.Draw;
            model.DealerStatus.Status = WiningStatus.Draw;
            SetCompleted(model);
        }

        private void SetCompleted(ResultModel model)
        {
            Status = GameStatus.Completed;
            model.GameStatus = Status;
        }
    }
}