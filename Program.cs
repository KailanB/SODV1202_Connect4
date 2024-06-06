


class Connect4Board
{
    char[,] Board { get; set; }

    public Connect4Board()
    {
        Board = new char[6, 7];
    }

    public void ResetBoard()
    {
        Board = new char[6, 7];
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1);  j++)
            {
                Board[i, j] = '#';
            }
        }
    }

    public void DisplayBoard()
    {
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Console.Write($"{Board[i, j], 2} ");   
            }
            Console.WriteLine();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Team!");

        Connect4Board board = new Connect4Board();
        board.ResetBoard();
        board.DisplayBoard();
       
    }
}



