using SODV1202_Connect4.Classes;
using SODV1202_Connect4.Classes.AI;
using SODV1202_Connect4.Common;

namespace SODV1202_Connect4;
class Program
{
    static void Main()
    {
        // GameManager gameManager = new GameManager(); Games Manager does not need an object instance?? static class??
        
        Console.WriteLine("Welcome!");

        Games connect4Game = new Connect4Game("Connect 4");
        GameManager.GamesList.Add(connect4Game);
        List<Player> currentPlayerList = new List<Player>();

        Player player1 = new HumanPlayer("Sandra Vera", '*', ConsoleColor.DarkBlue);
        currentPlayerList.Add(player1);
        Player player2 = new HumanPlayer("Kailan", '&', ConsoleColor.DarkYellow);
        currentPlayerList.Add(player2);
        Player player3 = new AIPlayer("Easy Peasy", 'X', ConsoleColor.DarkRed, new AIEasy());

        GameManager.PlayerList.Add(player1);
        GameManager.PlayerList.Add(player2);
        GameManager.PlayerList.Add(player3);

        string optionSelected; // changed to string so that we can run input validation
        int selectionToInt;
        do
        {
            Console.Clear(); // added clear, might not work well?
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------- MENU -------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Remove player");
            Console.WriteLine("3. Show players currently active");
            Console.WriteLine("4. Show Games List");
            Console.WriteLine("5. Create New Player");
            Console.WriteLine("6. Show all registered players");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------------");
            Console.Write("Select an option: ");

            optionSelected = Console.ReadLine();
            if (int.TryParse(optionSelected, out selectionToInt)) // input validation so that game does not crash if user inputs something other than an integer. Otherwise switch function crashes
            {
                switch (selectionToInt)
                {
                    case 1:
                        GameManager.AddPlayer(currentPlayerList);
                        // this displays a list of all players within the gameManager.PlayerList
                        // then a user can add an existing player from THAT list to the currentPlayerList to play games
                        // we need 2 separate lists because we do not want player objects lost forever
                        // gameManager.PlayerList stores ALL players, currentPlayerList list stores players currently trying to play

                        break;
                    case 2:
                        GameManager.RemovePlayer(currentPlayerList);
                        break;
                    case 3:
                        foreach (Player p in currentPlayerList)
                        {
                            Console.ForegroundColor = p.PlayerColor; // change color to player color
                            Console.WriteLine(p);
                            Console.ForegroundColor = ConsoleColor.Gray; // return color     
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 4:
                        GameManager.SelectGameToPlay(currentPlayerList);
                        break;
                    case 5:
                        GameManager.CreateNewPlayer();
                        break;
                    case 6:
                        foreach (Player p in GameManager.PlayerList)
                        {
                            Console.ForegroundColor = p.PlayerColor; // change color to player color
                            Console.WriteLine(p);
                            Console.WriteLine(p.DisplayStats());
                            Console.ForegroundColor = ConsoleColor.Gray; // return color     
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Good bye!. Thank you for play our game.");
                        Console.WriteLine("Copyright 2024. KaSa Studio. All rights reserved.");
                        break;
                    default:
                        Messages.ShowErrorMessage("Invalid option!!!!");
                        break;
                }
            }
            else Console.WriteLine("Invalid option, choose a number please.");

        } while (optionSelected != "0");
    }
}




