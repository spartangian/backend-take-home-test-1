using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHand
{
    public class Player
    {
        public Player() { }
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Card> Deck { get; set; }
        public string PlayerHand { get; set; }
        public int GetScore()
        {
            int score = 0;
            Deck.ForEach(x => score += x.TotalValue);
            return score;
        }
    }
}
