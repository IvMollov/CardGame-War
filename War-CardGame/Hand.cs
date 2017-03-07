using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_CardGame
{
    public class Hand
    {
        public static List<string> Round(List<Card> firstPlayerDeck, List<Card> secondPlayerDeck)
        {

            List<string> log = new List<string>();
            int indexFirstPlayer = firstPlayerDeck.Count;
            int indexSecondPlayer = secondPlayerDeck.Count;
            int warIndex = 0;
            while (secondPlayerDeck.Count > 0 && firstPlayerDeck.Count > 0)
            {
                if (indexFirstPlayer < 1)
                {
                    indexFirstPlayer = firstPlayerDeck.Count;
                }
                if (indexSecondPlayer < 1)
                {
                    indexSecondPlayer = secondPlayerDeck.Count;
                }
                if (firstPlayerDeck[firstPlayerDeck.Count - indexFirstPlayer].Value > secondPlayerDeck[secondPlayerDeck.Count - indexSecondPlayer].Value)
                {
                    firstPlayerDeck.Add(secondPlayerDeck[secondPlayerDeck.Count - indexSecondPlayer]);
                    secondPlayerDeck.RemoveAt(secondPlayerDeck.Count - indexSecondPlayer);
                    log.Add("First player wins!");
                }
                else if (firstPlayerDeck[firstPlayerDeck.Count - indexFirstPlayer].Value < secondPlayerDeck[secondPlayerDeck.Count - indexSecondPlayer].Value)
                {
                    secondPlayerDeck.Add(firstPlayerDeck[firstPlayerDeck.Count - indexFirstPlayer]);
                    firstPlayerDeck.RemoveAt(firstPlayerDeck.Count - indexFirstPlayer);
                    log.Add("Second player wins!");
                }
                else
                {
                    warIndex = 2;
                    while (true)
                    {
                        if (indexFirstPlayer - 1 - warIndex < 1)
                        {
                            indexFirstPlayer = firstPlayerDeck.Count;
                        }
                        if (indexSecondPlayer - 1 - warIndex < 1)
                        {
                            indexSecondPlayer = secondPlayerDeck.Count;
                        }
                        if (firstPlayerDeck[firstPlayerDeck.Count - (indexFirstPlayer - warIndex)].Value > secondPlayerDeck[secondPlayerDeck.Count - (indexSecondPlayer - warIndex)].Value)
                        {

                            for (int i = 0; i <= warIndex; i++)
                            {
                                firstPlayerDeck.Add(secondPlayerDeck[secondPlayerDeck.Count - (indexSecondPlayer - i)]);
                                secondPlayerDeck.RemoveAt(secondPlayerDeck.Count - (indexSecondPlayer - i));
                            }
                            log.Add("War! And First player wins!");
                            break;
                        }
                        else if (firstPlayerDeck[firstPlayerDeck.Count - (indexFirstPlayer - warIndex)].Value < secondPlayerDeck[secondPlayerDeck.Count - (indexSecondPlayer - warIndex)].Value)
                        {
                            for (int i = 0; i <= warIndex; i++)
                            {
                                secondPlayerDeck.Add(firstPlayerDeck[firstPlayerDeck.Count - (indexFirstPlayer - i)]);
                                firstPlayerDeck.RemoveAt(firstPlayerDeck.Count - (indexFirstPlayer - i));
                            }
                            log.Add("War! And Second player wins!");
                            break;
                        }
                        warIndex += 2;
                    }
                }
                indexFirstPlayer = indexFirstPlayer - 1 - warIndex;
                indexSecondPlayer = indexSecondPlayer - 1 - warIndex;
                warIndex = 0;
            }
            return log;
        }
    }
}
