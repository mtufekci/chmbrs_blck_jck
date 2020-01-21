namespace Chambers.BlackJack.Common.Domain
{
    public class Player
    {
        public string Name { get; }
        
        private readonly Hand _hand;

        public Player()
        {
            Name = "player";
            _hand = new Hand();
        }

        public void Hit(Card card)
        {
            _hand.AddCard(card);
        }
        
        public short Score => _hand.Score;

        public bool IsBust => _hand.IsBust();
    }
}