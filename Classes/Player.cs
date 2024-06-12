namespace SODV1202_Connect4.Classes
{  
    class Player : User
    {
        // player name 
        // player symbol
        // player wins
        // player losses
        public char Symbol { get; set; } = '#';
        public System.ConsoleColor PlayerColor { get; set; } = ConsoleColor.Gray;
        public string PlayerName { get; set; }
        private int Wins { get; set; } = 0;
        private int Losses { get; set; } = 0;
        /// <summary>
        /// This class is the player and has inheritance of User class.
        /// </summary>
        /// <param name="userName"> First name and last name of player.</param>
        /// <param name="playerName">Nickname of player.</param>
        public Player(string userName, string playerName) : base(userName)
        {
            PlayerName = playerName;
        }
        public void PlayerWins()
        {
            Wins++;
        }

        public string ToString() { return $"{base.UserName} ({PlayerName}) - {Symbol}"; }

        /*
         * method to display player stats, number of wins / losses
         */

    }
}
