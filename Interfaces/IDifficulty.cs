using SODV1202_Connect4.Classes;

namespace SODV1202_Connect4.Interfaces
{
    internal interface IDifficulty
    {
        public string GetDescription();

        public int Connect4BoardMove(Connect4Game board);
    }
}
