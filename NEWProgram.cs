﻿using SODV1202_Connect4.Classes;
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
        PlayerSuper player2 = new HumanPlayer("Kailan", '&', ConsoleColor.DarkYellow);
        currentPlayerList.Add(player2);

        gameManager.PlayerList.Add(player1);
        gameManager.PlayerList.Add(player2);

        //connect4Game.ResetGame();
        //connect4Game.DisplayGame(currentPlayerList);



        //connect4Game.Play(currentPlayerList);


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
            Console.WriteLine("3. Show players");
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
                        // this displays a list of all players within the gameManager.PlayerList
                        // then a user can add an existing player from THAT list to the currentPlayerList to play games
                        // we need 2 separate lists because we do not want player objects lost forever
                        // gameManager.PlayerList stores ALL players, currentPlayerList list stores players currently trying to play
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("------------- Registered Players -------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            int count = 0; // counter to make sure we are displaying at least one player. If not output message no players available
                            for (int i = 0; i < gameManager.PlayerList.Count; i++)
                            {
                                //if (PlayerList.Find(player => player.PlayerName == playerName) != null)

                                if (currentPlayerList.Find(player => player.PlayerName == gameManager.PlayerList[i].PlayerName) == null)
                                {
                                    Console.WriteLine($"{i + 1}. {gameManager.PlayerList[i]}");
                                    count++;
                                }
                                else Console.WriteLine($"{i + 1} (Currently Playing) {gameManager.PlayerList[i]}");

                            }
                            if (count == 0) Console.WriteLine("No players available to add. \nSelect 0 to exit.");
                            if (count > 0) Console.Write("Select player to add: ");
                            optionSelected = Console.ReadLine();
                            if (int.TryParse(optionSelected, out selectionToInt)) // input validation so that game does not crash if user inputs something other than an integer. Otherwise switch function crashes
                            {
                                if ((selectionToInt <= gameManager.PlayerList.Count) && selectionToInt != 0)
                                {
                                    Console.WriteLine($"{gameManager.PlayerList[selectionToInt - 1]} added to currently playing.");
                                    currentPlayerList.Add(gameManager.PlayerList[selectionToInt - 1]);
                                }
                                else if (selectionToInt != 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid number selection!!!!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Please select a valid number from 0 to {gameManager.GamesList.Count}.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (optionSelected != "0");
                        Console.Clear();
                        optionSelected = ""; // change optionSelected to something other than 0 so that loop does not break and we go back to the main menu

                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("------------- Registered Players -------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        do
                        {
                            for (int i = 0; i < currentPlayerList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {currentPlayerList[i]}");
                            }

                            Console.WriteLine("0. Exit");
                            if (currentPlayerList.Count > 0) Console.Write("Select player to remove: ");
                            if (currentPlayerList.Count == 0) Console.WriteLine("No players to remove, \nSelect 0 to exit.");
                            optionSelected = Console.ReadLine();
                            if (int.TryParse(optionSelected, out selectionToInt)) // input validation so that game does not crash if user inputs something other than an integer. Otherwise switch function crashes
                            {
                                if ((selectionToInt <= currentPlayerList.Count) && selectionToInt != 0)
                                {
                                    currentPlayerList.Remove(currentPlayerList[selectionToInt - 1]);
                                }
                                else if (selectionToInt != 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid number selection!!!!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }  
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Please select a valid number from 0 to {gameManager.GamesList.Count}.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        } while (optionSelected != "0");

                        Console.Clear();
                        optionSelected = "";
                        break;
                    case 3:
                        foreach (PlayerSuper p in currentPlayerList)
                        {
                            Console.ForegroundColor = p.PlayerColor; // change color to player color
                            Console.WriteLine(p);
                            Console.ForegroundColor = ConsoleColor.Gray; // return color     
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 4:
                        do
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("------------- Games -------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            for (int i = 0; i < gameManager.GamesList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {gameManager.GamesList[i]}:");
                                gameManager.GamesList[i].DisplayGameRules();
                            }
                            Console.WriteLine("0. Exit");
                            Console.Write("Select an option: ");
                            //optionSelected = Convert.ToInt16(Console.ReadLine());
                            optionSelected = Console.ReadLine(); 
                            if (int.TryParse(optionSelected, out selectionToInt)) // input validation so that game does not crash if user inputs something other than an integer. Otherwise switch function crashes
                            {
                                if ((selectionToInt <= gameManager.GamesList.Count) && selectionToInt != 0)
                                {
                                    if (currentPlayerList.Count > gameManager.GamesList[selectionToInt - 1].MaxPlayers) // check for valid number of players. There's probably a better way to do this but I am getting tired for today XD
                                    {
                                        Console.WriteLine("Too many players for this game type! Connect 4 is a 2 player game.");
                                    }
                                    else if (currentPlayerList.Count < gameManager.GamesList[selectionToInt - 1].MinPlayers)
                                    {
                                        Console.WriteLine("Too few players for this game type! Connect 4 is a 2 player game.");
                                    }
                                    else
                                    {
                                        gameManager.GamesList[selectionToInt - 1].ResetGame(); // set with default symbols
                                        gameManager.GamesList[selectionToInt - 1].Play(currentPlayerList); // send list of players to play the game
                                    }
                                }
                                else if (selectionToInt != 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid option!!!!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else Console.WriteLine($"Please select a valid number from 0 to {gameManager.GamesList.Count}.");

                        } while (optionSelected != "0");
                        Console.Clear();
                        optionSelected = ""; // change optionSelected to something other than 0 so that loop does not break and we go back to the main menu
                        break;
                    case 5:
                        gameManager.AddPlayer();
                        break;
                    case 6:
                        foreach (PlayerSuper p in gameManager.PlayerList)
                        {
                            Console.ForegroundColor = p.PlayerColor; // change color to player color
                            Console.WriteLine(p);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option!!!!");
                        break;
                }
            }
            else Console.WriteLine("Invalid option, choose a number please.");

        } while (optionSelected != "0");


        //Connect4Board board = new Connect4Board();
        //board.ShowMainMenu();
    }
}




