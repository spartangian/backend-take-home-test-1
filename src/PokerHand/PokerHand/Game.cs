using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    //Game
    public class Game : IGame
    {
        public List<Player> Players { get; }
        private PokerDealer _dealer;
        private PokerHandEvaluator _evaluator;

        public Game(List<Player> players)
        {
            Players = players;
            _dealer = PokerDealer.GetInstance;
            _evaluator = new PokerHandEvaluator();
            DealCards();
        }

        private void DealCards()
        {
            Players.ForEach(player => player.Deck = _dealer.Deal());
        }

        public string DrawCards()
        {
            var winner = _evaluator.EvaluateCards(Players);

            return winner;
        }

    }
}
