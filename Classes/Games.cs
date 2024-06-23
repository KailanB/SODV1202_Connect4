namespace SODV1202_Connect4.Classes
{
    abstract class Games
    {
        protected Games(string name)
        {
            GameName = name;
            MaxPlayers = 100; // default for games that do not have a player limit within the rules
        }

        protected Games(string name, int minPlayers, int maxPlayers)
        {
            GameName = name;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        public string GameName { get; protected set; }
        public int MaxPlayers { get; protected set; }
        public int MinPlayers { get; protected set; }

        public abstract void Play(List<Player> playerList);
        public abstract void ResetGame();
        protected abstract void DisplayGame(List<Player> playerList);
        public virtual string DisplayGameRules()
        {
            return $"   {GameName} requires a minimum of {MinPlayers} players and a maximum of {MaxPlayers} players.\n"; // spaces at the beginning are intentional so that it is indented under the displayed game
        }
        protected abstract bool CheckForWin();

        public override string ToString()
        {
            return GameName;
        }

    }
}
