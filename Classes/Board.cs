namespace SODV1202_Connect4.Classes
{
    class Board
    {
        public int Columns { get; }
        public int Rows { get; }
        public int SequenceToWin { get; }
        public int MaxPlayers { get; }
        private Player DefaultPlayer { get; } = new Player("", ""); //default player to use in the board when there is no player
        public Player[,] Layer { get; set; }
        /// <summary>
        /// This class is the board of the game. The configuration of the match.
        /// </summary>
        /// <param name="columns"> Number of columns on the board.</param>
        /// <param name="rows">Number of rows on the board.</param>
        /// <param name="sequenceToWin">Number of sequence consecutive for win the match.</param>
        /// <param name="maxPlayers">Number of players.</param>
        public Board(int columns, int rows, int sequenceToWin, int maxPlayers)
        {
            Columns = columns;
            Rows = rows;
            SequenceToWin = sequenceToWin;
            MaxPlayers = maxPlayers;
            Layer = new Player[columns, rows];
        }
        public void ResetBoard()
        {
            Layer = new Player[Columns, Rows];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Layer[i, j] = DefaultPlayer;
                }
            }
        }

        public void DisplayBoard()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Board");
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($"{i,2} ");
            }
            Console.WriteLine();
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($"---");
            }
            Console.WriteLine();
            for (int j = 0; j < Rows; j++)
            {
                for (int i = 0; i < Columns; i++)
                {
                    Console.ForegroundColor = Layer[i, j].PlayerColor;
                    Console.Write($"{Layer[i, j].Symbol,2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------");
        }

        public void SelectColumnToPlay(Player player)
        {
            int column;
            bool validPosition = false;
            do
            {
                Console.ForegroundColor = player.PlayerColor;
                Console.WriteLine($"Player: {player.PlayerName} ({player.Symbol}) choose a column to play");
                Console.ForegroundColor = ConsoleColor.White;
                column = Convert.ToInt16(Console.ReadLine());
                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (Layer[column, i].Symbol == '#')
                    {
                        Layer[column, i] = player;
                        validPosition = true;
                        break;
                    }
                }
            } while (column > Columns || !validPosition);
        }
    }
}
