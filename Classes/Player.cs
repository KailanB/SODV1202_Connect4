namespace SODV1202_Connect4.Classes
{
	abstract class Player
	{
		protected Player(string name, char c, System.ConsoleColor color)
		{
			PlayerName = name;
			PlayerSymbol = c;
			PlayerColor = color;
		}
		public string PlayerName { get; protected set; }
        public char PlayerSymbol { get; set; }
        public System.ConsoleColor PlayerColor { get; protected set; }
        public int Wins { get; protected set; } = 0;
        public int Losses { get; protected set; } = 0;
        public bool IsAI { get; set; } = false;

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
