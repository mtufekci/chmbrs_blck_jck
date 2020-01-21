namespace Chambers.BlackJack.Common.Domain
{
    public class Dealer 
    {
        private readonly Deck _deck;

        private readonly Hand _hand;

        public Dealer()
        {
            _deck = new Deck();
            _hand = new Hand();
        }

        public void Hit()
        {
            var card = Deal();
            _hand.AddCard(card);
        }

        public short Score => _hand.Score;
        
        public bool IsBust => _hand.IsBust();

        public Card Deal() => _deck.TakeACard();
    }
}
