using SODV1202_Connect4.Interfaces;

namespace SODV1202_Connect4.Classes
{
    class AIPlayer : Player
    {
        public IDifficulty Difficulty { get; }
        public AIPlayer(string name, char c, System.ConsoleColor color, IDifficulty difficulty) : base(name, c, color)
        {
            Difficulty = difficulty;
            IsAI = true;
        }

        public override string ToString() { return $"AI {PlayerName} - {PlayerSymbol}"; }
    }
}