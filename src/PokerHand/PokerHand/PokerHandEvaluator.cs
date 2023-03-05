using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public class PokerHandEvaluator
    {
        public string EvaluateCards(List<Player> players)
        {
            var winner = "";
            //starts at the highest combo
            if(!string.IsNullOrWhiteSpace(winner = EvaluateFlush(players)))
                return winner;

            if (!string.IsNullOrWhiteSpace(winner = EvaluateTrio(players)))
                return winner;

            if (!string.IsNullOrWhiteSpace(winner = EvaluateTwoPair(players)))
                return winner;

            if(!string.IsNullOrWhiteSpace(winner = EvaluatePair(players)))
                return winner;
            
            if (!string.IsNullOrEmpty(winner = EvaluateHighCard(players)))
                return winner;

            return winner;
        }

        private string EvaluateTrio(List<Player> players)
        {
            var trios = new Dictionary<int, Player>();

            foreach(var player in players)
            {
                var hand = from card in player.Deck
                           group card by card.Rank into combination
                           where combination.Count() > 2
                           select combination;

                if(hand.Count() > 0)
                    trios.Add(hand.Max().Key, player);

            }

            if (trios.Count > 0)
            {
                var winnerKey = trios.Max(a => a.Key);
                var winner = trios[winnerKey];

                return $"{winner.Name} wins... higher three of a kind";
            }

            return "";
        }

        private string EvaluateHighCard(List<Player> players)
        {
            var playerAndDeckInOrder = new Dictionary<Stack<Card>, Player>();
            var dictBySymbol = new Dictionary<string, Player>();
            var dictByRank = new Dictionary<int, string>();
            var previousPlayerDeck = new Stack<Card>();

            foreach (var player in players)
            {
                //put the player's deck in order
                var cardsInOrder = player.Deck.Select(x => x).OrderBy(x => x.Rank);
                var cardStack = new Stack<Card>(cardsInOrder);
                var previousPlayer = player;

                foreach (var c in cardStack)
                {
                    if (!dictByRank.ContainsKey(c.Rank))
                    {
                        dictBySymbol.Add(c.Symbol, player);
                        dictByRank.Add(c.Rank, c.Symbol);
                        cardStack.Pop();
                        break;
                    }
                    else
                    {
                        dictByRank.Remove(c.Rank);
                        dictBySymbol.Add(previousPlayerDeck.First().Symbol, previousPlayer);
                        dictByRank.Add(previousPlayerDeck.First().Rank, previousPlayerDeck.First().Symbol);
                        previousPlayerDeck.Pop();
                    }
                }

                previousPlayerDeck = cardStack;
            }

            var winnerKey = dictByRank.OrderByDescending(x => x.Key);
            var winner = dictBySymbol[winnerKey.First().Value];

            return $"{winner.Name} wins. High card: {winnerKey.First().Value}";
        }

        private string EvaluateTwoPair(List<Player> players)
        {
            var twoPair = new Dictionary<int, Player>();

            foreach (var player in players)
            {
                var hand = (from card in player.Deck
                             group card by card.Rank into combination
                             where combination.Count() == 2
                             select combination);

                if (hand.Count() > 1)
                    twoPair.Add(hand.First().Key + hand.Last().Key, player);

            }

            if (twoPair.Count > 1)
            {
                var winnerKey = twoPair.Max(a => a.Key);
                var winner = twoPair[winnerKey];

                return $"{winner.Name} wins... higher two pair";
            }

            return "";
        }

        private string EvaluatePair(List<Player> players)
        {
            var pairByRank = new Dictionary<int, string>();
            var pairBySymbol = new Dictionary<string, Player>();

            foreach (var player in players)
            {
                var hands = from card in player.Deck
                            group card by card.Rank into combination
                            where combination.Count() == 2
                            select combination;

                if (hands.Count() > 0)
                {
                    pairByRank.Add(hands.Max().First().Rank, hands.Max().First().Symbol);
                    pairBySymbol.Add(hands.Max().First().Symbol, player);
                }
            }

            if (pairByRank.Count() == 0)
                return "";

            var lower = pairByRank.Min(x => x.Value);
            var loser = pairBySymbol[lower];
            var higher = pairByRank.Max(x => x.Value);
            var winner = pairBySymbol[higher];

            return $"{winner.Name} wins... higher pair: ({higher} > {lower})";
        }

        private string EvaluateFlush(List<Player> players)
        {
            var flushes = new Dictionary<string, Player>();
            var flushesByRank = new Dictionary<int, string>();
            string loserKey = "";
            string winnerKey = "";

            foreach(var player in players)
            {
                var hand = from card in player.Deck
                            group card by card.Suit into combination
                            where combination.Count() == 5
                            select combination;

                if (hand.Count() > 0)
                {
                    var t = player.Deck.Select(x => x).OrderBy(x => x.Rank).Last();
                    flushes.Add(t.Symbol, player);
                    flushesByRank.Add(t.Rank, t.Symbol);                    
                }
                    
            }

            if(flushes.Count() > 1)
            {
                loserKey = flushesByRank.Min(x => x.Value);
                var loser = flushes[loserKey];
                winnerKey = flushesByRank.Max(x => x.Value);
                var winner = flushes[winnerKey];

                return $"{winner.Name} wins... higher flush ({winnerKey} > {loserKey})";
            }
            else if(flushes.Count() == 1)
            {
                winnerKey = flushesByRank.Max(x => x.Value);
                var winner = flushes[winnerKey];

                return $"{winner.Name} wins... flush";
            }

            return "";

        }

    }
}
