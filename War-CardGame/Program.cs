using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            List<Card> fullDeck = deck.GetDeck();
            List<Card> firstPlayerDeck = deck.GetFirstPlayerDeck(fullDeck);
            List<Card> secondPlayerDeck = deck.GetSecondPlayerDeck(firstPlayerDeck, fullDeck);

            List<string> log = Hand.Round(firstPlayerDeck, secondPlayerDeck);

            for (int i = 0; i < log.Count; i++)
            {
                Console.WriteLine("Round[{0}]: {1}", i + 1, log[i]);
            }

            Console.ReadLine();
        }
    }
}
