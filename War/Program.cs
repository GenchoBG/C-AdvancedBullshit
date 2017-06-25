/*
 Problem 3 – Number Wars
There is one very popular card game for little children - "Voina". Most of us played this game before and it is well known for being pretty easy. So, in this task you will implement a slightly different version of the game.  
There are two players. Each of them have cards in their hands. Cards consist of a number and an English letter - something like "11f", "53g", "55g", "3k", "66666p". 
Every turn of the game, each of the players puts his top (longest been in deck) card on the field. The player with the bigger card (higher number) gets both cards and puts them in the bottom of his deck.
It is easy when there is a clear winner, but what happens when the cards’ numbers are equal. Then every player has to put 3 more cards on the field. Again check for winner, but this time you need to check for the bigger sum of letters at the end of the cards. Each letter represents their position in the English alphabet a -> 1, b -> 2, c -> 3 etc. The player with the biggest sum of these 3 cards collects all cards from the field and put them in his deck. If there is a draw, the players put 3 new cards from their decks. 
When you find the result, end the turn and all cards from the field go to the winner hand. Cards are added in descending order: 
Hand <- "111f", "111a", "99p", "77a", "55a", "8p"
The game ends under two conditions - if any of the players loses all his cards, he loses the game. After 1000000 turns, if both players still have cards, the player with more cards wins the game.
Input
On the first line you will receive the first players’ cards separated with a space.
On the second line you will receive the second players’ cards separated with a space.
Output
You need to print a single line with the winner or draw: "{Result} after {turns} turns"
Constraints
Each player will have N cards, where 1 < N < 1000
Each number will contain an integer with a single letter at the end
Time limit: 0.3 sec. Memory limit: 16 MB.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamFML
{
    public class Card
    {
        public Card(string input)
        {
            this.letter = input[input.Length - 1];
            this.number = int.Parse(input.Substring(0, input.Length - 1));
        }

        public int number { get; set; }

        public char letter { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var firstPlayerCards = new Queue<Card>(Console.ReadLine().Split().Select(x => new Card(x)));
            var secondPlayerCards = new Queue<Card>(Console.ReadLine().Split().Select(x => new Card(x)));
            var turn = 0;
            while (true)
            {
                turn++;
                var player1Card = firstPlayerCards.Dequeue();
                var player2Card = secondPlayerCards.Dequeue();
                var cardsForWinner = new List<Card>() { player1Card, player2Card };
                if (player1Card.number > player2Card.number)
                {
                    cardsForWinner = new List<Card>(cardsForWinner.OrderByDescending(c => c.number));
                    foreach (var card in cardsForWinner)
                    {
                        firstPlayerCards.Enqueue(card);
                    }
                }
                else if (player2Card.number > player1Card.number)
                {
                    cardsForWinner = new List<Card>(cardsForWinner.OrderByDescending(c => c.number));
                    foreach (var card in cardsForWinner)
                    {
                        secondPlayerCards.Enqueue(card);
                    }
                }
                else
                {
                    while (true)
                    {
                        var player1tempcards = new List<Card>() { firstPlayerCards.Dequeue(), firstPlayerCards.Dequeue(), firstPlayerCards.Dequeue() };
                        var player2tempcards = new List<Card>() { secondPlayerCards.Dequeue(), secondPlayerCards.Dequeue(), secondPlayerCards.Dequeue() };
                        cardsForWinner = cardsForWinner.Concat(player1tempcards).ToList();
                        cardsForWinner = cardsForWinner.Concat(player2tempcards).ToList();
                        var player1Sum = GetSumFrom3Cards(player1tempcards);
                        var player2Sum = GetSumFrom3Cards(player2tempcards);
                        if (player1Sum > player2Sum)
                        {
                            cardsForWinner = new List<Card>(cardsForWinner.OrderByDescending(c => c.number));
                            foreach (var card in cardsForWinner)
                            {
                                firstPlayerCards.Enqueue(card);
                            }
                            break;
                        }
                        else if (player1Sum < player2Sum)
                        {
                            cardsForWinner = new List<Card>(cardsForWinner.OrderByDescending(c => c.number));
                            foreach (var card in cardsForWinner)
                            {
                                secondPlayerCards.Enqueue(card);
                            }
                            break;
                        }
                    }
                }
                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
                if (turn >= 1000000)
                {
                    break;
                }
            }
            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {turn} turns");
            }
            else
            {
                Console.WriteLine($"Second player wins after {turn} turns");
            }
        }

        private static int GetSumFrom3Cards(List<Card> playertempcards)
        {
            int sum = 0;
            foreach (var card in playertempcards)
            {
                sum += card.letter - 96;
            }
            return sum;
        }
    }
}
