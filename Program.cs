


class Connect4Board
{
    char[,] Board { get; private set; }

    public Connect4Board()
    {

    }

    public ResetBoard()
    {
        Board = new char[6, 7];
        for (int i = 0; i < Board.GetLength(0))
        {
            for (int j = 0; j < Board.GetLength(1))
            {
                Board[i][j] = "#";
            }
        }
    }

    public DisplayBoard()
    {
        for (int i = 0; i < Board.GetLength(0))
        {
            for (int j = 0; j < Board.GetLength(1))
            {
                Console.WriteLine($"{Board[i, j], 2});   
            }
        }
    }
}






class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Team!");
    }
}




