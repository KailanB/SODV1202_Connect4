using SODV1202_Connect4.Classes;
using SODV1202_Connect4.Controller;
using System.Buffers;
using System.ComponentModel.Design;



class NEWProgram
{
    static void Main()
    {
        GameManager gameManager = new GameManager();
        
        Console.WriteLine("Welcome!");

        Games connect4Game = new Connect4Game("Connect 4");
        gameManager.GamesList.Add(connect4Game);
        List<PlayerSuper> currentPlayerList = new List<PlayerSuper>();

        PlayerSuper player1 = new HumanPlayer("Sandra Vera", '*', ConsoleColor.DarkBlue);
        currentPlayerList.Add(player1);
        PlayerSuper player2 = new HumanPlayer("Kailan Bates", '&', ConsoleColor.DarkYellow);
        currentPlayerList.Add(player2);


        //connect4Game.ResetGame();
        //connect4Game.DisplayGame(currentPlayerList);



        //connect4Game.Play(currentPlayerList);


        int optionSelected;
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------- MENU -------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Remove player");
            Console.WriteLine("3. Show players");
            Console.WriteLine("4. Show Games List");
            Console.WriteLine("5. Create New Player");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------------");
            Console.Write("Select an option: ");
            optionSelected = Convert.ToInt16(Console.ReadLine());
            switch (optionSelected)
            {
                case 1:
                    //AddPlayer();
                    // this should display a list of all players within the gameManager.PlayerList
                    // then a user can add an existing player from THAT list to the currentPlayerList to play games
                    // we need 2 separate lists because we do not want player objects lost forever
                    // gameManager.PlayerList stores ALL players, currentPlayerList list stores players currently trying to play
                    break;
                case 2:
                    // this should run a for each loop searching for the player name string to remove from currentPlayerList
                    // this should NOT be removing a player from gameManager.PlayerList. ONLY from currentPlayerList
                    break;
                case 3:
                    foreach (PlayerSuper p in currentPlayerList)
                    {
                        Console.ForegroundColor = p.PlayerColor; // change color to player color
                        Console.WriteLine(p);
                        Console.ForegroundColor = ConsoleColor.Gray; // return color   
                    }
                    break;
                case 4:
                    do
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("------------- Games -------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        for(int i = 0; i < gameManager.GamesList.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {gameManager.GamesList[i]}");
                        }
                        Console.WriteLine("0. Exit");
                        Console.Write("Select an option: ");
                        optionSelected = Convert.ToInt16(Console.ReadLine());
                        if ((optionSelected <= gameManager.GamesList.Count) && optionSelected != 0)
                        {
                            if (currentPlayerList.Count > gameManager.GamesList[optionSelected - 1].MaxPlayers) // check for valid number of players. There's probably a better way to do this but I am getting tired for today XD
                            {
                                Console.WriteLine("Too many players for this game type! Connect 4 is a 2 player game.");
                            }
                            else if (currentPlayerList.Count < gameManager.GamesList[optionSelected - 1].MinPlayers)
                            {
                                Console.WriteLine("Too few players for this game type! Connect 4 is a 2 player game.");
                            }
                            else
                            {
                                gameManager.GamesList[optionSelected - 1].ResetGame(); // set with default symbols
                                gameManager.GamesList[optionSelected - 1].Play(currentPlayerList); // send list of players to play the game
                            }
                        }
                        else if (optionSelected != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option!!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    } while (optionSelected != 0);
                    Console.Clear();
                    optionSelected = 1; // change optionSelected to something other than 0 so that loop does not break and we go back to the main menu
                    break;
                case 5:
                    // foreach loop check for existing name within the gameManager.PlayerList for duplicate name or symbols
                    // create new player and to gameManager.PlayerList this list should store ALL players
                    // currentPlayerList stores CURRENT players trying to play the game, this list will add and remove players from the gameManager.PlayerList as necessary for game being player
                    break;
                case 0:
                    Console.WriteLine("Good bye!. Thank you for play our game.");
                    Console.WriteLine("Copyright 2024. KaSa Studio. All rights reserved.");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option!!!!");
                    break;
            }
        } while (optionSelected != 0);


        //Connect4Board board = new Connect4Board();
        //board.ShowMainMenu();
    }
}




