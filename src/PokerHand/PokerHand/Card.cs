using PokerHand.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHand
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public int TotalValue => (int)Enum.Parse(typeof(CardSuit), Suit.ToString()) + Rank;

        public Card() { }
        public Card(CardSuit suit, int rank, string symbol)
        {
            Suit= suit;
            Rank= rank;
            Symbol= $"{symbol}{suit}";
        }
    }
}
