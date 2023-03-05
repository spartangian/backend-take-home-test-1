using System.Collections.Generic;

namespace PokerHand
{
    public interface IGame
    {
        List<Player> Players { get; }

        string DrawCards();
    }
}