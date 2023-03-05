using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHand;
using FluentAssertions;

namespace PokerHandTest
{
    public class GameTest
    {
        [Fact]
        public void Game_DrawCards_Both_Player_Should_Get_Cards()
        {
            var black = new Player("Black");
            var white = new Player("White");

            var players = new List<Player>()
            {
                black,
                white
            };

            var sut = new Game(players);

            sut.Players[0].Deck.Count.Should().Be(5);
            sut.Players[1].Deck.Count.Should().Be(5);
        }

        [Fact]
        public void Game_DrawCards()
        {
            var black = new Player("Black");
            var white = new Player("White");

            var players = new List<Player>()
            {
                black,
                white
            };

            var sut = new Game(players);
            var winner = sut.DrawCards();

            winner.Should().NotBeNullOrWhiteSpace();
        }
    }
}
