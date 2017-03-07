using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_CardGame
{
    public class Deck
    {
        private List<Card> deck;
        private Random randomCard;
        public Deck()
        {
            this.randomCard = new Random();
        }

        public Random RandomCard
        {
            get
            {
                return this.randomCard;
            }
            private set
            {
                this.randomCard = new Random();
            }
        }
        public List<Card> GetDeck()
        {
            deck = new List<Card>();
            for (Card.CardSuite i = Card.CardSuite.clubs; i <= Card.CardSuite.spades; i++)
            {
                for (int j = (int)Card.CardValue.two; j <= (int)Card.CardValue.ace; j++)
                {
                    deck.Add(new Card(i, j));
                }
            }
            return deck;
        }
        public List<Card> GetFirstPlayerDeck(List<Card> fullDeck)
        {
            bool isInTheDecksPlayer;
            List<Card> firstPlayerDeck = new List<Card>();
            while (firstPlayerDeck.Count < 26)
            {
                int index = randomCard.Next(0, 52);
                isInTheDecksPlayer = IsInTheDeck(firstPlayerDeck, fullDeck[index]);
                if (!isInTheDecksPlayer)
                {
                    firstPlayerDeck.Add(fullDeck[index]);
                }
            }
            return firstPlayerDeck;
        }

        public List<Card> GetSecondPlayerDeck(List<Card> firstPlayerDeck, List<Card> fullDeck)
        {
            bool isInTheFirstPlayerDeck;
            List<Card> secondPlayerDeck = new List<Card>();
            foreach (var card in fullDeck)
            {
                isInTheFirstPlayerDeck = IsInTheDeck(firstPlayerDeck, card);
                if (!isInTheFirstPlayerDeck)
                {
                    secondPlayerDeck.Add(card);
                }
            }
            return secondPlayerDeck;
        }
        private bool IsInTheDeck(List<Card> playersDeck, Card card)
        {
            foreach (var item in playersDeck)
            {
                if (card == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
