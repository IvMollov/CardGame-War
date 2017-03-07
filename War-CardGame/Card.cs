using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_CardGame
{
    public class Card
    {
        public enum CardSuite { clubs, diamonds, hearts, spades };
        public enum CardValue
        {
            two = 2, three = 3, four = 4, five = 5,
            six = 6, seven = 7, eigth = 8, nine = 9,
            ten = 10, jack = 11, queen = 12, king = 13,
            ace = 14
        };
        private CardSuite suit;
        private int value;

        public Card(CardSuite suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }
        public CardSuite Suit
        {
            get
            {
                return this.suit;
            }
        }
        public int Value
        {
            get
            {
                return this.value;
            }
        }

    }
}
