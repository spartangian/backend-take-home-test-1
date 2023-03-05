using PokerHand.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHand
{
    public sealed class PokerDealer
    {
        private static readonly PokerDealer instance = new PokerDealer();
        private Dictionary<string, int> _ranks = new Dictionary<string, int>();
        private List<Card> _deck = new List<Card>();

        private PokerDealer()
        {
            AssignRanksValue();
            foreach(var rank in _ranks)
            {
                foreach(CardSuit s in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                {
                    _deck.Add(new Card(s, rank.Value, rank.Key));
                }
            }
        }

        public static PokerDealer GetInstance
        {
            get 
            {
                return instance;
            }
        }

        public List<Card> Deal()
        {
            var rnd = new Random();
            var playerDeck = new List<Card>();
            
            for(int i = 0; i < 5; i++)
            {
                int pick = rnd.Next(_deck.Count);
                playerDeck.Add(_deck[pick]);

                _deck.RemoveAt(pick);
            }

            return playerDeck;
        }

        private void AssignRanksValue()
        {
            _ranks.Add("2", 2);
            _ranks.Add("3", 3);
            _ranks.Add("4", 4);
            _ranks.Add("5", 5);
            _ranks.Add("6", 6);
            _ranks.Add("7", 7);
            _ranks.Add("8", 8);
            _ranks.Add("9", 9);
            _ranks.Add("10", 10);
            _ranks.Add("J", 11);
            _ranks.Add("Q", 12);
            _ranks.Add("K", 13);
            _ranks.Add("A", 14);
        }
    }
}
