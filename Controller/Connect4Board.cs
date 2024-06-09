using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SODV1202_Connect4.Controller
{
    class Connect4Board
    {
        /* potentially the Connect4Board could inherit from the class "games"? In this way more games could be added and a 
         * user could choose what game they want to play?
         */

        /*
         * Method to add player to a game session before it begins, in this way there could be multiple players
         * method would need a cap of 2 players
         * 
         * method to remove player from the game 
         * 
         * method to start game (must have 2 players, unless we add AI)
         */
        char[,] Board { get; set; }

        public Connect4Board()
        {
            Board = new char[6, 7];
        }

        public void ResetBoard()
        {
            Board = new char[6, 7];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = '#';
                }
            }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write($"{Board[i, j],2} ");
                }
                Console.WriteLine();
            }
        }
        /* 
         * method with a while loop for a game in progress and switch with cases for each column when a number is chosen
         */

        /* Method to quit a game early and reset, possibly just type reset?
         */

        /* Methods to check for a game win
         * horizontal
         * vertical and 
         * diagonal 
         */
    }
}
