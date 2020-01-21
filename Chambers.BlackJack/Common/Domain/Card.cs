namespace Chambers.BlackJack.Common.Domain
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public short Value => GetValue();
        
        private short GetValue()
        {
            switch (Face)
            {
                case Face.Two:
                case Face.Three:
                case Face.Four:
                case Face.Five:
                case Face.Six:
                case Face.Seven:
                case Face.Eight:
                case Face.Nine:
                   return (short)Face;
                case Face.Ten:
                case Face.Jack:
                case Face.Queen:
                case Face.King:
                    return 10;
                default:
                    return 0;
            }
        }
        
    }
}