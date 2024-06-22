using System.Drawing;

namespace SODV1202_Connect4.Classes
{
	abstract class Player
    {
        protected Player(string name, char symbol, System.ConsoleColor color)
        {
            PlayerName = name;
            PlayerSymbol = symbol;
            PlayerColor = color;
        }

        protected Player (string name, char symbol)
        {
            PlayerName = name;
            PlayerSymbol = symbol;
            PlayerColor = ConsoleColor.White; // select default color if one is not chosen
        }
        public string PlayerName { get; protected set; } // changed all to protected
        public char PlayerSymbol { get; set; }
        public System.ConsoleColor PlayerColor { get; protected set; }
        protected int Wins { get; set; } = 0;
        protected int Losses { get;  set; } = 0;
        public bool IsAI { get; protected set; } = false;


        public string DisplayStats()
        {
            return $"Wins: {Wins}\nLosses: {Losses}";
        }
        public void PlayerAddWin()
        {
            Wins++;
        }
        public void PlayerAddLoss()
        {
            Losses++;
        }
        
    }
}
