using SODV1202_Connect4.Interfaces;

namespace SODV1202_Connect4.Classes.AI
{
    internal class AIEasy : IDifficulty
    {
        public string GetDescription()
        {
            return "This Easy AI will make random moves";
        }

        public int Connect4BoardMove(Connect4Game board)
        {
            List<int> availableColumns = [];
            for (int i = 0; i < board.GetColumns(); i++)
            {
                availableColumns.Add(i);
            }
            Random rnd = new Random();
            bool freeSlot = false;
            int randomColumn;
            do
            {
                randomColumn = rnd.Next(0, availableColumns.Count);
                for (int i = board.GetRows() - 1; i >= 0; i--)
                {

                    if (board.GetConnect4Board()[i, availableColumns[randomColumn]].PlayerSymbol == '#')
                    {
                        freeSlot = true;
                        break;
                    }
                }
                if (!freeSlot)
                {
                    availableColumns.Remove(randomColumn);
                }
                if (availableColumns.Count == 0)
                {
                    return -1;
                }
            } while (!freeSlot);
            return randomColumn + 1;
        }
    }
}
