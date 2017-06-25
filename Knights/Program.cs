/*
 * 
 * Problem 2 – Knight Game
Chess is the oldest game, but it is still popular these days. For this task we will use only one chess piece – the Knight. 
The knight moves to the nearest square but not on the same row, column, or diagonal. (This can be thought of as moving two squares horizontally, then one square vertically, or moving one square horizontally then two squares vertically— i.e. in an "L" pattern.) 
The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 
You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights, so there will be no knights left that can attack another knight. 
Input
On the first line, you will receive the N size of the board
On the next N lines you will receive strings with Ks and 0s.
Output
Print a single integer with the minimum amount of knights that needs to be removed
Constraints
Size of the board will be 0 < N < 30
Time limit: 0.3 sec. Memory limit: 16 MB.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_Advanced_Exam
{


    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            var counter = 0;
            while (true)
            {
                var kone = new List<Horse>();

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            kone.Add(new Horse(row, col));
                        }
                    }
                }
                
                foreach (var kon in kone)
                {
                    kon.CalculateJertvi(board);
                }

                kone = kone.OrderByDescending(k => k.Jertvi).ToList();
                var murtvec = kone.First();
                if (murtvec.Jertvi == 0 || kone.Count == 0)
                {
                    break;
                }

                kone.Remove(murtvec);
                counter++;
                board[murtvec.Row][murtvec.Col] = 'R';
            }

            Console.WriteLine(counter);
        }
    }

    public class Horse
    {
        public int Jertvi { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public Horse(int row, int col)
        {
            this.Jertvi = 0;
            this.Row = row;
            this.Col = col;
        }

        public void CalculateJertvi(char[][] board)
        {
            this.Jertvi = 0;
            Bullshit(board);
        }

        public void Bullshit(char[][] board)
        {
            try
            {
                if (board[this.Row + 1][this.Col - 2] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row + 1}][{Col - 2}]");
                }
            }
            catch (Exception) { }
            try
            {
                if (board[this.Row + 1][this.Col + 2] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row + 1}][{Col + 2}]");
                }

            }
            catch (Exception) { }
            try
            {
                if (board[this.Row + 2][this.Col - 1] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row + 2}][{Col - 1}]");
                }
            }
            catch (Exception) { }
            try
            {
                if (board[this.Row + 2][this.Col + 1] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row + 2}][{Col + 1}]");
                }
            }
            catch (Exception) { }
            try
            {
                if (board[this.Row - 1][this.Col - 2] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row - 1}][{Col - 2}]");
                }
            }
            catch (Exception) { }
            try
            {
                if (board[this.Row - 1][this.Col + 2] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row - 1}][{Col + 2}]");
                }
            }
            catch (Exception) { }
            try
            {
                if (board[this.Row - 2][this.Col + 1] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row - 2}][{Col + 1}]");
                }
            }
            catch (Exception) { }
            try
            {
                if (board[this.Row - 2][this.Col - 1] == 'K')
                {
                    this.Jertvi++;
                    //Console.WriteLine($"[{Row}][{Col}] => [{Row - 2}][{Col - 1}]");
                }
            }
            catch (Exception) { }
        }
    }
}

