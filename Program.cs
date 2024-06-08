



class Connect4Board
{
    /* potentially the Connect4Board could inherit from the class "games"? In this way more games could be added and a 
     * user could choose what game they want to play?
     */

    /*
     * Method to add player to a game session before it begins, in this way there could be multiple players
     * method would need a cap of 2 players
     * 
     * method to remove player from the game 
     * 
     * method to start game (must have 2 players, unless we add AI)
     */
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
    /* 
     * method with a while loop for a game in progress and switch with cases for each column when a number is chosen
     */

    /* Method to quit a game early and reset, possibly just type reset?
     */

    /* Methods to check for a game win
     * horizontal
     * vertical and 
     * diagonal 
     */
}

class Columns
{

    // counter field get, private set.
    /* 
     * separate class for columns so that a board size could potentially be variable
     * a user could define number or rows and columns on the board and the program
     * would create column objects for that number
     * 
     * Columns will need a counter that goes up every time a user add a symbol to that column
     * that way the program can track which symbol on the board needs to be changed
     * If column 3 has 2 symbols stacked already then it would have  a counter of 2,
     * then the symbol to be changed would be in row[number of rows - counter + 1].
     * 
     * there should also be a column list that contains all columns, in this way
     * we can easily access the correct column when the user enters, 1,2 3.. etc.
     * 
     * method to reset counters on game reset
     */ 
}

class Players
{
    // player name 
    // player symbol
    // player wins
    // player losses

    /*
     * method to display player stats, number of wins / losses
     */

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



