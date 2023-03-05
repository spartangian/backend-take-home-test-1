using FluentAssertions;
using PokerHand;
using PokerHand.Enums;

namespace PokerHandTest
{
    public class PokerHandTests
    {
        [Fact]
        public void PokerHand_HigherPair_Wins()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.S, 2, "2"),
                new Card(CardSuit.C, 2, "2"),
                new Card(CardSuit.S, 14, "A"),
                new Card(CardSuit.C, 11, "J"),
                new Card(CardSuit.C, 4, "4")

            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.H, 14, "A"),
                new Card(CardSuit.H, 2, "2"),
                new Card(CardSuit.D, 14, "A"),
                new Card(CardSuit.S, 3, "3"),
                new Card(CardSuit.S, 6, "6")
            };

            white.Deck = whiteCards;
            black.Deck = blackCards;

            var players = new List<Player> { white, black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be("white wins... higher pair: (AH > 2S)");
        }

        [Fact]
        public void PokerHand_HigherCard_Wins()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.S, 5, "5"),
                new Card(CardSuit.H, 2, "2"),
                new Card(CardSuit.D, 3, "3"),
                new Card(CardSuit.D, 13, "K"),
                new Card(CardSuit.C, 9, "9")
                
            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.H, 14, "A"),
                new Card(CardSuit.C, 2, "2"),
                new Card(CardSuit.H, 3, "3"),
                new Card(CardSuit.C, 8, "8"),
                new Card(CardSuit.S, 4, "4")
            };

            black.Deck = blackCards;
            white.Deck = whiteCards;

            var players = new List<Player> { white,black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be($"{white.Name} wins. High card: AH");

        }

        [Fact]
        public void PokerHand_HigherCard_Players_Has_Same_Rank()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.H, 2, "2"),
                new Card(CardSuit.D, 3, "3"),
                new Card(CardSuit.D, 13, "K"),
                new Card(CardSuit.S, 5, "5"),
                new Card(CardSuit.H, 9, "9"),
            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.H, 13, "K"),
                new Card(CardSuit.C, 2, "2"),
                new Card(CardSuit.H, 3, "3"),
                new Card(CardSuit.C, 8, "8"),
                new Card(CardSuit.S, 4, "4")
            };

            black.Deck = blackCards;
            white.Deck = whiteCards;

            var players = new List<Player> { white, black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be($"{black.Name} wins. High card: 9H");
        }

        [Fact]
        public void PokerHand_Flush_Wins()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.H, 2, "2"),
                new Card(CardSuit.S, 4, "4"),
                new Card(CardSuit.C, 4, "4"),
                new Card(CardSuit.D, 3, "3"),
                new Card(CardSuit.H, 4, "4"),
            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.S, 12, "Q"),
                new Card(CardSuit.S, 2, "2"),
                new Card(CardSuit.S, 3, "3"),
                new Card(CardSuit.S, 8, "8"),
                new Card(CardSuit.S, 14, "A")
            };

            black.Deck = blackCards;
            white.Deck = whiteCards;

            var players = new List<Player> { white, black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be($"white wins... flush");
        }

        [Fact]
        public void PokerHand_HigherFlush_Wins()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.C, 7, "7"),
                new Card(CardSuit.C, 3, "3"),
                new Card(CardSuit.C, 6, "6"),
                new Card(CardSuit.C, 11, "J"),
                new Card(CardSuit.C, 4, "4"),
            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.S, 12, "Q"),
                new Card(CardSuit.S, 2, "2"),
                new Card(CardSuit.S, 3, "3"),
                new Card(CardSuit.S, 8, "8"),
                new Card(CardSuit.S, 4, "4")
            };

            black.Deck = blackCards;
            white.Deck = whiteCards;

            var players = new List<Player> { white, black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be("white wins... higher flush (QS > JC)");
        }

        [Fact]
        public void PokerHand_Higher_Three_Wins()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.H, 2, "2"),
                new Card(CardSuit.D, 2, "2"),
                new Card(CardSuit.S, 2, "2"),
                new Card(CardSuit.C, 9, "9"),
                new Card(CardSuit.D, 13, "K"),
            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.H, 13, "K"),
                new Card(CardSuit.D, 3, "3"),
                new Card(CardSuit.H, 3, "3"),
                new Card(CardSuit.C, 3, "3"),
                new Card(CardSuit.S, 9, "9")
            };

            black.Deck = blackCards;
            white.Deck = whiteCards;

            var players = new List<Player> { white, black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be("white wins... higher three of a kind");
        }

        [Fact]
        public void PokerHand_Higher_Two_Pairs_Wins()
        {
            var white = new Player("white");
            var black = new Player("black");

            var blackCards = new List<Card>
            {
                new Card(CardSuit.H, 2, "2"),
                new Card(CardSuit.D, 2, "2"),
                new Card(CardSuit.S, 5, "5"),
                new Card(CardSuit.C, 5, "5"),
                new Card(CardSuit.D, 13, "K"),
            };

            var whiteCards = new List<Card>
            {
                new Card(CardSuit.H, 7, "7"),
                new Card(CardSuit.D, 7, "7"),
                new Card(CardSuit.H, 9, "9"),
                new Card(CardSuit.H, 5, "5"),
                new Card(CardSuit.S, 9, "9")
            };

            black.Deck = blackCards;
            white.Deck = whiteCards;

            var players = new List<Player> { white, black };

            var sut = new PokerHandEvaluator();
            var winner = sut.EvaluateCards(players);

            winner.Should().Be("white wins... higher two pair");
        }
    }
}