namespace SODV1202_Connect4.Classes
{
    abstract class Games
    {
        protected Games(string name)
        {
            GameName = name;
        }
        public string GameName { get; protected set; }
        public int MaxPlayers { get; protected set; }
        public int MinPlayers { get; protected set; }

        public abstract void Play(List<PlayerSuper> playerList);
        public abstract void ResetGame();
        public abstract void DisplayGame(List<PlayerSuper> playerList);
        public abstract void DisplayGameRules();
        public abstract bool CheckForWin();

        public override string ToString()
        {
            return GameName;
        }

    }
}
