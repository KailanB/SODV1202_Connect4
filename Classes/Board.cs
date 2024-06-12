using System.Data.Common;

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
            Layer = new Player[rows, columns]; // this was declared backwards, rows are the first value and columns second in a multidimensional array
        }
        public void ResetBoard()
        {
            Layer = new Player[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
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
                Console.Write($"{i+1,2} "); // added i+1 to make board more user friendly. Column 0 is displayed as 1
            }
            Console.WriteLine();
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($"---");
            }
            Console.WriteLine();
            for (int i = 0; i < Rows; i++) // changed the j's to i's here since it was causing the display method to be inverted
            {
                for (int j = 0; j < Columns; j++) // array rows and columns were declared the other way around "Layer = new Player[columns, rows];" so swapped those for the time being 
                {
                                 //Console.Write($"{i}{j}  ");
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
                if(column <= Columns & (column > 0)) // correct column validation
                {
                    for (int i = Rows - 1; i >= 0; i--)
                    {
                        if (Layer[i, column-1].Symbol == '#') // changed the order of i / column to reflect standard Rows / Columns layout
                        {
                            Layer[i, column-1] = player; // changed to column -1 to adjust for user input being 1 to 7 now instead of 0 to 6 
                            validPosition = true;
                            break;
                        }
                    }
                }
                else Console.WriteLine("Invalid column");

            } while (column > Columns || !validPosition);
        }

        public bool ValidateWinner() // tested most of the validates. Further testing may be necessary 
        {
            for (int i = 0; i < Rows; i++) // validate winner for vertical (column) wins
            {
                for (int j = 0; j < Columns-3; j++) 
                {
                    if (((Layer[i, j].Symbol == Layer[i, j+1].Symbol) & (Layer[i, j+1].Symbol == Layer[i, j+2].Symbol) & (Layer[i, j+2].Symbol == Layer[i, j+3].Symbol)) & Layer[i, j].Symbol != '#')
                    {
                        return true;
                        // we can incorporate a SequenceToWin value method later
                    }
                    
                }
            }
            
            for (int i = 0; i < Rows-3; i++) // validate winner for horizontal (rows) wins
            {
                for(int j = 0; j < Columns; j++)
                {
                    if (((Layer[i, j].Symbol == Layer[i + 1, j].Symbol) & (Layer[i + 1, j].Symbol == Layer[i + 2, j].Symbol) & (Layer[i + 2, j].Symbol == Layer[i + 3, j].Symbol)) & Layer[i, j].Symbol != '#')
                    {
                        return true;
                    }
                    
                }
            }
            for (int i = 0; i < Rows-3; i++) // check diagonals for win
            {
                for (int j = 0; j < Columns-3; j++)
                {
                    if (((Layer[i, j].Symbol == Layer[i+1, j+1].Symbol) & (Layer[i+1, j+1].Symbol == Layer[i+2, j+2].Symbol) & (Layer[i+2, j+2].Symbol == Layer[i+3, j+3].Symbol)) & Layer[i, j].Symbol != '#')
                    {
                        return true;
                    }
                    if (((Layer[i, j+3].Symbol == Layer[i+1, j+2].Symbol) & (Layer[i+2, j+1].Symbol == Layer[i+2, j+1].Symbol) & (Layer[i+2, j+1].Symbol == Layer[i+3, j].Symbol)) & Layer[i, j+3].Symbol != '#')
                    {
                        return true;
                    }
                }
            }
            
            return false;


        }
    
    
    
    
    
    
    
    
    }

}
