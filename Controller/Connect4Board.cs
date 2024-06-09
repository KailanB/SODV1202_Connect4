using SODV1202_Connect4.Classes;

namespace SODV1202_Connect4.Controller
{
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
        Board Board { get; set; }
        private List<Player> _playerList { get; set; } = new List<Player>();
        private readonly int MaxAllowedPlayers = 3;
        private readonly int MinAllowedPlayers = 2;



        public void ShowMainMenu()
        {
            int optionSelected;
            do
            {
                MainMenu();
                optionSelected = Convert.ToInt16(Console.ReadLine());
                SelectedOption(optionSelected);
            } while (optionSelected != 0);
        }
        private void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------- MENU -------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Remove player");
            Console.WriteLine("3. Show players");
            Console.WriteLine("4. Create board");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------------");
            Console.Write("Select an option: ");
        }

        private void SelectedOption(int option)
        {
            switch (option)
            {
                case 1:
                    AddPlayer();
                    break;
                case 2:
                    break;
                case 3:
                    ShowPlayers();
                    break;
                case 4:
                    CreateBoardMenu();
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

        #region Player
        private void AddPlayer()
        {
            if (_playerList.Count < MaxAllowedPlayers)
            {
                Console.WriteLine("User name (Name and Lastname):");//TODO validate non duplicated username
                string userName = Console.ReadLine();
                Console.WriteLine("Player name (Surname without blank spaces):");//TODO validate non duplicated playername
                string playerName = Console.ReadLine().Replace(" ", string.Empty).Trim();
                Console.WriteLine("Symbol (Only one letter):");
                char symbol;
                char.TryParse(Console.ReadLine(), out symbol);//TODO validate non duplicated symbol or at least with the same color
                //Console.WriteLine("Select a color:");//TODO implement color selection
                Player player = new Player(userName, playerName);
                player.Symbol = symbol;
                player.PlayerColor = ConsoleColor.White;//Default color
                _playerList.Add(player);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Only can be {MaxAllowedPlayers} players");
            }
        }

        private void DeletePlayer() { }

        private void ShowPlayers()
        {
            Console.WriteLine("Player list:");
            foreach (Player player in _playerList)
            {
                Console.ForegroundColor = player.PlayerColor;
                string humanPlayer = player.IsAIUser() ? "AI" : "Human";
                Console.WriteLine($"{player.ToString()} ({humanPlayer})");
            }
        }


        #endregion
        private void CreateBoardMenu()
        {
            if (_playerList.Count >= MinAllowedPlayers)
            {
                //TODO the columns, rows, sequenceToWin can be configured in the future to make a more dynamic game
                CreateBoard(7, 6, 4, _playerList.Count);
            }
            else
            {
                Console.WriteLine($"You need at least {MinAllowedPlayers} players to init a new game");
            }
        }

        private void CreateBoard(int columns, int rows, int sequenceToWin, int maxPlayers)
        {
            Board = new Board(columns, rows, sequenceToWin, maxPlayers);
            Board.ResetBoard();
            Board.DisplayBoard();
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
}
