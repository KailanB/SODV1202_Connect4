namespace SODV1202_Connect4.Classes
{
    class Connect4Game : Games
    {
        private int Rows { get; set; } = 6;
        private int Columns { get; set; } = 7;

        private char[,] Connect4Board = new char[6, 7];

        private bool EndGame { get; set; } = false;

        public Connect4Game(string name) : base(name)
        {
            MaxPlayers = 2;
            MinPlayers = 2;
        }

        public override void Play(List<PlayerSuper> playerList)
        {
            int playerNumber = 0;
            do
            {
                Console.Clear();
                DisplayGame(playerList);
                PlayerSuper currentPlayer = playerList[playerNumber];
                SelectColumnToPlay(currentPlayer);
                if (playerNumber >= MaxPlayers - 1)
                {
                    playerNumber = 0;
                }
                else
                {
                    playerNumber++;
                }
                Console.Clear(); // added another clear that way multiple boards are not displayed
                DisplayGame(playerList);
                if (CheckForWin())  // check for winner and EndGame true to break loop
                {
                    EndGame = true;
                    Console.WriteLine($"Game Over! {currentPlayer.PlayerName} wins!");
                    currentPlayer.PlayerAddWin(); // increase players score
                    foreach (PlayerSuper p in playerList) // add a loss for every other player
                    {
                        if (p != currentPlayer)
                        {
                            p.PlayerAddLoss();
                        }
                    }

                }


            } while (!EndGame);
            EndGame = false; // switch to false again so that game can be played again
        }

        public void SelectColumnToPlay(PlayerSuper player)
        {
            int column;
            bool validPosition = false;
            do
            {
                Console.ForegroundColor = player.PlayerColor;
                Console.WriteLine($"Player: {player.PlayerName} ({player.PlayerSymbol}) choose a column to play");
                Console.ForegroundColor = ConsoleColor.White;
                column = Convert.ToInt16(Console.ReadLine());
                if (column <= Columns & (column > 0)) // correct column validation
                {
                    for (int i = Rows - 1; i >= 0; i--) // start from the bottom of the board checking for a valid row to play in
                    {
                        if (Connect4Board[i, column - 1] == '#') // changed the order of i / column to reflect standard Rows / Columns layout
                        {
                            Connect4Board[i, column - 1] = player.PlayerSymbol; // changed to column -1 to adjust for user input being 1 to 7 now instead of 0 to 6 
                            validPosition = true;
                            break;
                        }
                    }
                }
                else Console.WriteLine("Invalid column");

            } while (column > Columns || !validPosition);
        }

        public override void ResetGame()
        {
            for (int i = 0; i < Rows ; i++)
            {
                for (int j = 0; j < Columns ; j++)
                {
                    Connect4Board[i, j] = '#';
                }
            }
        }
        public override void DisplayGame(List<PlayerSuper> playerList)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Board");
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($"{i + 1,2} ");
            }
            Console.WriteLine();
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($"---");
            }
            Console.WriteLine();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Connect4Board[i, j] != '#') // check that the current symbol is not default
                    {
                        foreach (PlayerSuper p in playerList) 
                        {
                            if (Connect4Board[i, j] == p.PlayerSymbol)//if not default find player with matching symbol
                            {
                                Console.ForegroundColor = p.PlayerColor; // change color to player color
                                Console.Write($"{Connect4Board[i, j],2} "); // write symbol with correct color
                                Console.ForegroundColor = ConsoleColor.Gray; // return color to default
                            }
                        }
                    }
                    else // else if symbol is default write standard
                    {
                        Console.Write($"{Connect4Board[i, j],2} ");
                    }
                       
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------");
        }
        public override void DisplayGameRules()
        {
            // I figured we could have a basic console output explaining the rules of the game as an option in the main menu
        }
        public override bool CheckForWin()
        {
            for (int i = 0; i < Rows; i++) // validate winner for vertical (column) wins
            {
                for (int j = 0; j < Columns - 3; j++)
                {
                    if (((Connect4Board[i, j] == Connect4Board[i, j + 1]) & (Connect4Board[i, j + 1] == Connect4Board[i, j + 2]) & (Connect4Board[i, j + 2] == Connect4Board[i, j + 3])) & Connect4Board[i, j] != '#')
                    {
                        Console.WriteLine("test vetical");
                        return true;
                        // we can incorporate a SequenceToWin value method later
                    }

                }
            }

            for (int i = 0; i < Rows - 3; i++) // validate winner for horizontal (rows) wins
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (((Connect4Board[i, j] == Connect4Board[i + 1, j]) & (Connect4Board[i + 1, j] == Connect4Board[i + 2, j]) & (Connect4Board[i + 2, j] == Connect4Board[i + 3, j])) & Connect4Board[i, j] != '#')
                    {
                        Console.WriteLine("test horizontal");
                        return true;
                    }

                }
            }
            for (int i = 0; i < Rows - 3; i++) // check diagonals for win
            {
                for (int j = 0; j < Columns - 3; j++)
                {
                    if (((Connect4Board[i, j] == Connect4Board[i + 1, j + 1]) & (Connect4Board[i + 1, j + 1] == Connect4Board[i + 2, j + 2]) & (Connect4Board[i + 2, j + 2] == Connect4Board[i + 3, j + 3])) & Connect4Board[i, j] != '#')
                    {
                        return true;
                    }
                    if (((Connect4Board[i, j + 3] == Connect4Board[i + 1, j + 2]) & (Connect4Board[i + 2, j + 1] == Connect4Board[i + 2, j + 1]) & (Connect4Board[i + 2, j + 1] == Connect4Board[i + 3, j])) & Connect4Board[i, j + 3] != '#')
                    {
                        return true;
                    }
                }
            }

            return false;
        }



    }
}
