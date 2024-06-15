using System.Data.Common;

namespace SODV1202_Connect4.Classes
{
    class AIPlayer : PlayerSuper
    {

        public AIPlayer(string name, char c, System.ConsoleColor color) : base(name, c, color)
        {

        }

        /*
        public void PlayerAddWin()
        {
            Wins++;
        }

        public void PlayerAddLoss()
        {
            Losses++;
        }
        */

        public override string ToString() { return $"AI {PlayerName} - {PlayerSymbol}"; }
    }
}