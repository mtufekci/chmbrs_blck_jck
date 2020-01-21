namespace Chambers.BlackJack.Models
{
    public class ResultModel
    {
        public PlayerStatusModel PlayerStatus { get; set; }
        public PlayerStatusModel DealerStatus { get; set; }
        public GameStatus GameStatus { get; set; }

        public ResultModel()
        {
            PlayerStatus = new PlayerStatusModel
            {
                Status = WiningStatus.InGame
            };
            DealerStatus = new PlayerStatusModel
            {
                Status = WiningStatus.InGame
            };
            GameStatus = GameStatus.OnPlay;
        }
    }
}
