using SODV1202_Connect4.Classes.AI;
using SODV1202_Connect4.Interfaces;

namespace SODV1202_Connect4.Classes
{
    class GameManager
    {
        private readonly int HumanPlayer = 1;
        private readonly int AIPlayer = 2;
        private string optionSelected;
        private int selectionToInt;
        public List<Player> PlayerList = new List<Player>();
        public List<Games> GamesList = new List<Games>();


        public void AddPlayer(List<Player> currentPlayerList)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------- Registered Players -------------");
                Console.ForegroundColor = ConsoleColor.White;
                int count = 0; // counter to make sure we are displaying at least one player. If not output message no players available
                for (int i = 0; i < PlayerList.Count; i++)
                {
                    if (currentPlayerList.Find(player => player.PlayerName == PlayerList[i].PlayerName) == null)
                    {
                        Console.WriteLine($"{i + 1}. {PlayerList[i]}");
                        count++;
                    }
                    else Console.WriteLine($"{i + 1} (Currently Playing) {PlayerList[i]}");

                }
                if (count == 0) Console.WriteLine("No players available to add.");
                Console.WriteLine("Press 0 to exit.");
                if (count > 0) Console.Write("Select player to add: ");
                
                optionSelected = Console.ReadLine();
                if (int.TryParse(optionSelected, out selectionToInt)) // input validation so that game does not crash if user inputs something other than an integer. Otherwise switch function crashes
                {
                    if ((selectionToInt <= PlayerList.Count) && selectionToInt != 0 && !currentPlayerList.Exists(p => p.PlayerName == PlayerList[selectionToInt - 1].PlayerName)) //Prevent the same player being added multiple times
                    {
                        Console.WriteLine($"{PlayerList[selectionToInt - 1]} added to currently playing.");
                        currentPlayerList.Add(PlayerList[selectionToInt - 1]);
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
                    Console.WriteLine($"Please select a valid number from 0 to {PlayerList.Count}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (optionSelected != "0");
            Console.Clear();
            optionSelected = "";
        }
        public void RemovePlayer(List<Player> currentPlayerList)
        {
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
                    Console.WriteLine($"Please select a valid number from 0 to {currentPlayerList.Count}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (optionSelected != "0");

            Console.Clear();
            optionSelected = "";
        }
        public void CreateNewPlayer()
        {
            string playerName = "0"; // created default values because program was not liking empty string or char lol
            char symbol = '0';
            int typeOfPlayer = HumanPlayer;
            int difficultyLevel = 1;
            bool choosing = true;
            IDifficulty difficulty = new AIEasy();//Set easy difficulty as default
            System.ConsoleColor color;
            Console.WriteLine("Enter 0 to exit process");
            Console.WriteLine("What type of player do you like to add?:");
            Console.WriteLine($"{HumanPlayer}. Human");
            Console.WriteLine($"{AIPlayer}. AI");

            while (choosing)
            {
                if (int.TryParse(Console.ReadLine(), out typeOfPlayer) && typeOfPlayer >= 0 && typeOfPlayer <= 2) // input validation for integer and option between 0, 1 and 2
                {
                    if (typeOfPlayer == 0) // allow user to exit
                    {
                        break;
                    }
                }
                else Console.WriteLine("Please select a valid number!"); // if int Parse fails, output fix for user
                if (typeOfPlayer == HumanPlayer)
                {
                    choosing = false;// break loop since proposed player type was NOT denied in foreach loop
                }
                else
                {
                    Console.WriteLine("Enter 0 to exit process");
                    Console.WriteLine("Select the difficulty of the AI:");
                    Console.WriteLine("1. Easy");
                    Console.WriteLine("2. Medium");
                    Console.WriteLine("3. Hard");
                    if (int.TryParse(Console.ReadLine(), out difficultyLevel) && difficultyLevel >= 0 && difficultyLevel <= 3) // input validation for integer and option between 0, 1, 2 and 3
                    {
                        if (difficultyLevel == 0) // allow user to exit
                        {
                            break;
                        }
                        try
                        {
                            if(difficultyLevel == 1) { difficulty = new AIEasy(); }
                            else if (difficultyLevel == 2) { difficulty = new AIMedium(); }
                            else if (difficultyLevel == 3) { difficulty = new AIHard(); }
                            Console.WriteLine(difficulty.GetDescription());
                            choosing = false;// break loop since proposed AI difficulty was NOT denied in foreach loop
                        }
                        catch(NotImplementedException ex) { Console.WriteLine(ex.Message); } //Catch the exception for the not implemented interfaces
                    }
                    else Console.WriteLine("Please select a valid number!"); // if int Parse fails, output fix for user
                }
            }
            choosing = true;
            Console.WriteLine("Player name: ");
            while (choosing)
            {
                playerName = Console.ReadLine().Replace(" ", string.Empty).Trim(); // name formatting
                if (playerName == "0") // allow user to exit at any time by using 0
                {
                    break;
                }
                // check all player names in the list with .Find 
                if (PlayerList.Find(player => player.PlayerName == playerName) != null) // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-8.0  Find element within a list
                {
                    // if .Find != null then a matching name was found and the user must try a different name
                    Console.WriteLine("Sorry, player name already taken! please try another");

                }
                else choosing = false; // break loop since proposed name was NOT denied in foreach loop

            }
            if (playerName == "0")
            {
                return;
            }

            choosing = true;
            Console.WriteLine("Symbol (Only one):");
            while (choosing)
            {

                if (char.TryParse(Console.ReadLine(), out symbol)) // input validation for single character
                {
                    if (symbol == '0') // allow user to exit
                    {
                        break;
                    }
                    // check all player symbols with .Find
                    if ((PlayerList.Find(player => player.PlayerSymbol == symbol) != null) || symbol == '#') // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-8.0  Find element within a list
                    {
                        Console.WriteLine("Sorry, player symbol already taken! please try another");
                    }
                    else choosing = false;// break loop since proposed symbol was NOT denied in foreach loop
                }
                else Console.WriteLine("Please select a SINGLE character!"); // if char Parse fails, output fix for user

            }
            if (symbol == '0')
            {
                return;
            }
            ColorList();
            color = SelectColor(); // duplicate colors allowed, no validation necessary 
            if (typeOfPlayer == 1)
            {
                PlayerList.Add(new HumanPlayer(playerName, symbol, color)); // add player to list
            }
            else
            {
                if (difficultyLevel == 2)
                {
                    difficulty = new AIMedium();
                }
                else if (difficultyLevel == 3)
                {
                    difficulty = new AIHard();
                }
                PlayerList.Add(new AIPlayer(playerName, symbol, color, difficulty)); // add aiplayer to list and inject the level of difficulty
            }
            Console.ForegroundColor = color;
            Console.WriteLine($"New player added: {PlayerList[PlayerList.Count - 1]}"); // display newest player added
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }

        

        private void ColorList()
        {

            Console.WriteLine("Select color: ");
            Console.WriteLine("1. White ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("2. Dark Blue ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("3. Dark Green ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("4. Dark Blue-Green ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("5. Dark Red ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("6. Dark Magenta ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("7. Dark Yellow ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("8. Blue ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("9. Green ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("10. Red ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("11. Magenta ");
        }

        private System.ConsoleColor SelectColor()
        {
            while (true)
            {
                string optionSelected;
                int color;
                optionSelected = Console.ReadLine();
                if (int.TryParse(optionSelected, out color)) // input validation so switch does not crash with non-integer inputs
                {
                    switch (color)
                    {
                        case 1: return ConsoleColor.White;
                        case 2: return ConsoleColor.DarkBlue;
                        case 3: return ConsoleColor.DarkGreen;
                        case 4: return ConsoleColor.DarkCyan;
                        case 5: return ConsoleColor.DarkRed;
                        case 6: return ConsoleColor.DarkMagenta;
                        case 7: return ConsoleColor.DarkYellow;
                        case 8: return ConsoleColor.Blue;
                        case 9: return ConsoleColor.Green;
                        case 10: return ConsoleColor.Red;
                        case 11: return ConsoleColor.Magenta;
                        default:
                            Console.WriteLine("Option is not valid. The color assigned for default is white.");
                            return ConsoleColor.White;
                    }
                }
                else Console.WriteLine("Invalid option please choose a valid number!");
            }




        }
    }
}

