namespace SODV1202_Connect4.Classes
{
	abstract class PlayerSuper
	{
		protected PlayerSuper(string name, char c, System.ConsoleColor color)
		{
			PlayerName = name;
			PlayerSymbol = c;
			PlayerColor = color;
		}
		public string PlayerName { get; protected set; }
        public char PlayerSymbol { get; protected set; }
        public System.ConsoleColor PlayerColor { get; protected set; }
        public int Wins { get; protected set; } = 0;
        public int Losses { get; protected set; } = 0;

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
