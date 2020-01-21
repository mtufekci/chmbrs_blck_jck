using System.Collections.Generic;
using System.Linq;
using Chambers.BlackJack.Common.Domain;

namespace Chambers.BlackJack.Common
{
    public class ScoreCalculator
    {
        public short CalculateScore(List<Card> cards)
        {
            short score = 0;
            
            score = CalculateScoreOfNoneAceCards(cards);

            score = CalculateScoreOfAces(score, cards);

            return score;
        }
        
        private short CalculateScoreOfNoneAceCards(List<Card> cards) => (short)cards.Where(c => c.Face != Face.Ace).Sum(n => n.Value);
        
        private short CalculateScoreOfAces(short score, List<Card> cards)
        {
            foreach (Card ace in cards.Where(c => c.Face == Face.Ace))
            {
                /*
                 * When the player hits, the dealer deals them another card.
                 * If the total of the cards is worth 21 or more, the player is bust and has lost.
                 */
                if ((score + 11) <= 20)
                {
                    score += 11;
                    continue;
                }
                score += 1;
            }

            return score;
        }

    }
}