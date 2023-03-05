using System.Collections.Generic;
using PokerHand.Characters;

namespace PokerHand
{
    public class Player : Character
    {
        public Player(string name) : base(name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Card> Deck { get; set; }
    }
}
