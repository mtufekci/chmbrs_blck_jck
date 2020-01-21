using Chambers.BlackJack.Common;

namespace Chambers.BlackJack.Models
{
    public class PlayerStatusModel
    {
        public short Score { get; set; }
        public WiningStatus Status { get; set; }
    }
}