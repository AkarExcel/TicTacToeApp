using System;
using System.Threading;

namespace TicTacToeApp
{
    class Program
    {
        /// <summary>
        /// This is the value definition for the Game
        /// this game is built on the CLI
        /// </summary>
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;

        /// <summary>
        /// Draw create the board on the console
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");

        }
        /// <summary>
        /// Check if either player has won, losed or tied
        /// </summary>
        /// <returns></returns>
        static int CheckWin()
        {
            if (spaces[0] == spaces[1] &&
                spaces[1] == spaces[2] || //row 1
                spaces[3] == spaces[4] &&
                spaces[4] == spaces[5] || //row 2
                spaces[6] == spaces[7] &&
                spaces[7] == spaces[8] || //row 3
                spaces[0] == spaces[3] &&
                spaces[3] == spaces[6] || //column 1
                spaces[1] == spaces[4] &&
                spaces[4] == spaces[7] || //column 2
                spaces[2] == spaces[5] &&
                spaces[5] == spaces[8] || //column 3
                spaces[0] == spaces[4] && 
                spaces[4] == spaces[8] || //diagonal 1
                spaces[2] == spaces[4] &&
                spaces[4] == spaces[6] // diagonal 2
                )
            {
                return 1;
            }
            else if(spaces[0] != '1' &&
                    spaces[1] != '2' &&
                    spaces[2] != '3' &&
                    spaces[3] != '4' &&
                    spaces[4] != '5' &&
                    spaces[5] != '6' &&
                    spaces[6] != '7' &&
                    spaces[7] != '8' &&
                    spaces[8] != '9' 
                   )
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
        /// <summary>
        /// This function draws a X in the game board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }
        /// <summary>
        /// This function Draws an O on the game board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }
        /// <summary>
        /// Main Game loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 is X and Player 2 is O" + "\n");
            
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1;
                if (spaces[choice] != 'X' && spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry the Row {0} is already Filled  {1}".ToUpper(), choice+1, spaces[choice]);
                    Console.WriteLine("Please Wait the Board will reload in 2 secs".ToUpper());
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                flag = CheckWin();
            } 
            while (flag == 0);

            Console.Clear();
            if (flag == 1)
            {

                Console.WriteLine("Player {0} Won",((player%2)+1));
            }
            else
            {
                Console.WriteLine("Game Draw");
            }
            Console.ReadLine();
        }
    }
}
