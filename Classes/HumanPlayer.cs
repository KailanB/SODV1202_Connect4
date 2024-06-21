namespace SODV1202_Connect4.Classes
{
    class HumanPlayer : Player
    {

        public HumanPlayer(string name, char c, System.ConsoleColor color) : base(name, c, color)
        {
        }

        public override string ToString() { return $"{PlayerName} - {PlayerSymbol}"; }


    }

    
}