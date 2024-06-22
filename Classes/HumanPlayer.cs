namespace SODV1202_Connect4.Classes
{
    class HumanPlayer : Player
    {

        public HumanPlayer(string name, char c, System.ConsoleColor color) : base(name, c, color)
        {
        }


        public string CheckStats() // IMPLEMENT THIS METHOD
        {
            return $"{PlayerName} game stats:\nWins: {Wins}\nLosses: {Losses}\nTotal Games:{Wins + Losses}";
        }

        public override string ToString() { return $"{PlayerName} - {PlayerSymbol}"; }


    }

    
} 