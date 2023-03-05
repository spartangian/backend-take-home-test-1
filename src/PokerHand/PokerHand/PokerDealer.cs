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
            var playerDeck = new List<Card>();
            var shuffledCards = Shuffle();
            
            for(int i = 0; i < 5; i++)
            {
                playerDeck.Add(shuffledCards.Dequeue());
            }

            return playerDeck;
        }

        private Queue<Card> Shuffle()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var shuffledCards = _deck;

            for(int i = shuffledCards.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Card card = shuffledCards[i];
                shuffledCards[i] = shuffledCards[j];
                shuffledCards[j] = card;
            }

            var finalShuffledCards = new Queue<Card>(shuffledCards);
            return finalShuffledCards;
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
