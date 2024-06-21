using SODV1202_Connect4.Classes;
using System.Reflection;

namespace SODV1202_Connect4.Classes
{
    class GameManager
    {
        public List<PlayerSuper> PlayerList = new List<PlayerSuper>();
        public List<Games> GamesList = new List<Games>();
        public void AddPlayer()
        {
            string playerName = "0"; // created default values because program was not liking empty string or char lol
            char symbol = '0';
            bool choosing = true;
            System.ConsoleColor color;
            Console.WriteLine("Enter 0 to exit process");
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
            PlayerList.Add(new HumanPlayer(playerName, symbol, color)); // add player to list
            Console.ForegroundColor = color;
            Console.WriteLine($"New player added: {PlayerList[PlayerList.Count-1]}"); // display newest player added
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
                        case 10:  return ConsoleColor.Red;
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

