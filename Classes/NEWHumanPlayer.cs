using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace SODV1202_Connect4.Classes
{
    class HumanPlayer : PlayerSuper
    {

        public HumanPlayer(string name, char c, System.ConsoleColor color) : base(name, c, color)
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

        public override string ToString() { return $"{PlayerName} - {PlayerSymbol}"; }


    }

    
}