using System;

namespace Week3ArraysSorting
{
    /// <summary>
    /// Board Game implementation for Assignment 2 Part A
    /// Demonstrates multi-dimensional arrays with interactive gameplay
    /// 
    /// Learning Focus: 
    /// - Multi-dimensional array manipulation (char[,])
    /// - Console rendering and user input
    /// - Game state management and win detection
    /// 
    /// Choose ONE game to implement:
    /// - Tic-Tac-Toe (3x3 grid)
    /// - Connect Four (6x7 grid with gravity)
    /// - Or something else creative using a 2D array! (I need to be able to understand the rules from your instructions)
    /// </summary>
    public class BoardGame
    {
        // Declaration of Tic-Tac-Toe Board
        private char[,] board = new char[3, 3];
        
        // Fields for game state
        private char currentPlayer = 'X';
        private bool gameOver = false;
        private string winner = "";
        private int turnNumber = 0;

        /// <summary>
        /// Constructor - Initialize the board game
        /// Set up your chosen game
        /// </summary>
        public BoardGame()
        {
            // Initialize board array
            // For Tic-Tac-Toe or Connect Four, fill with empty spaces or dots
            // ❌ ⭕ -> use for Tic-Tac-Toe if you'd like for each square/player and the white box from array example

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '.';
                }
            }
        }
        
        /// <summary>
        /// Main game loop - handles the complete game session
        /// TODO: Implement the full game experience
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("=== BOARD GAME (Part A) ===");
            Console.WriteLine();
            
            // Display game instructions
            DisplayInstructions();
            
            // Implement main game loop
            bool playAgain = true;
            
            while (playAgain)
            {
                // Reset game state for new game
                InitializeNewGame();
                
                // Play one complete game
                PlayOneGame();
                
                // Ask if player wants to play again
                playAgain = AskPlayAgain();
            }
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        
        /// Display game instructions and controls
        private void DisplayInstructions()
        {
            Console.WriteLine();
            
            //Tic-Tac-Toe Instructions:
            Console.WriteLine("TIC-TAC-TOE RULES:");
            Console.WriteLine("- Players take turns placing X and O");
            Console.WriteLine("- Enter row and column (0-2) when prompted");
            Console.WriteLine("- First to get 3 in a row wins!");
            
            Console.WriteLine();
        }
        
        /// <summary>
        /// Initialize/reset the game for a new round
        /// Reset board and game state
        /// </summary>
        private void InitializeNewGame()
        {
            // Clear the board array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '.';
                }
            }

            //Reset current player to 'X'
            currentPlayer = 'X';

            // Reset game over flag
            gameOver = false;

            // TODO: Clear winner
            winner = "";
        }
        
        /// <summary>
        /// Play one complete game until win/draw/quit
        /// TODO: Implement the core game loop
        /// </summary>
        private void PlayOneGame()
        {
            // TODO: Game loop structure:
            while (!gameOver)
            {
                RenderBoard();
                GetPlayerMove();
                CheckWinCondition();
                SwitchPlayer();
            }
        }
        
        /// <summary>
        /// Render the current board state to console
        /// TODO: Create clear, readable board display
        /// </summary>
        private void RenderBoard()
        {
            // Display your multi-dimensional array as a visual board
            // Requirements:
            // - Clear, human-readable format
            // - Show current board state
            // - Include row/column labels for easy reference

            Console.WriteLine("  A B C ");
            Console.WriteLine("--------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1);
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------");
        }
        
        /// <summary>
        /// Get and validate player move input
        /// Handle user input with validation
        /// </summary>
        private void GetPlayerMove()
        {
            // Prompt current player for their move
            // Validate input (in bounds, empty cell, etc.)
            // Keep asking until valid move is entered
            int row = -1;
            int column = -1;

            Console.WriteLine($"Enter the row and column you wish to place your {currentPlayer}");
            
            // Example input validation structure:
            bool validMove = false;
            while (!validMove)
            {
                Console.Write($"Player {currentPlayer}, enter your move: ");
                string input = Console.ReadLine();
                input = input.ToLower();

                // Parse and validate input

                //Convert row to int
                switch (input[0])
                {
                    case 'a':
                        row = 0;
                        break;
                    case 'b':
                        row = 1;
                        break;
                    case 'c':
                        row = 2;
                        break;
                    default:
                        break;
                }

                //Parse column as int
                column = input[1] - '1';

                //Validate input
                if (input.Length == 2)
                {
                    if (row >= 0 && row <= 2)
                    {
                        if (column >= 0 && column <= 2)
                        {
                            if (board[column, row] == '.')
                            {
                                //fill board with current input
                                board[column, row] = currentPlayer;
                                validMove = true;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("Invalid input, try again!");
            }
        }
        
        /// <summary>
        /// Check if current board state has a winner or draw
        /// Implement win detection logic
        /// </summary>
        private void CheckWinCondition()
        {
            // Check for win conditions specific to your game
            // For Tic-Tac-Toe:
            // - Check all rows, columns, and diagonals for 3 in a row
            if (board[1, 1] == currentPlayer)
            {
                if (board[0, 0] == currentPlayer && board[0, 0] == board[2, 2])
                {
                    winner = Char.ToString(currentPlayer);
                    Console.WriteLine($"{winner} is the winner!");
                    gameOver = true;
                    return;
                }
                else if (board[2, 0] == currentPlayer && board[2, 0] == board[0, 2])
                {
                    winner = Char.ToString(currentPlayer);
                    Console.WriteLine($"{winner} is the winner!");
                    gameOver = true;
                    return;
                }
            }
            //check for row or column win
            for (int i = 0; i <= 2; i++)
            {
                if (currentPlayer == board[i, 0])
                {
                    if (board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    {
                        winner = Char.ToString(currentPlayer);
                        Console.WriteLine($"{winner} is the winner!");
                        RenderBoard();
                        gameOver = true;
                        return;
                    }
                }
                if (currentPlayer == board[0, i])
                {
                    if (board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    {
                        winner = Char.ToString(currentPlayer);
                        Console.WriteLine($"{winner} is the winner!");
                        RenderBoard();
                        gameOver = true;
                        return;
                    }
                }

            }

            // - Check for draw (board full, no winner)
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (board[i, j] == '.')
                    {
                        return;
                    }
                }
            }
            Console.WriteLine("No winner, try again!");
            RenderBoard();
            gameOver = true;
        }
        
        /// <summary>
        /// Ask player if they want to play another game
        /// TODO: Simple yes/no prompt with validation
        /// </summary>
        private bool AskPlayAgain()
        {
            string again = ".";
            Console.WriteLine("Do you want to play again? y/n: ");
            again = Console.ReadLine();
            again = again.ToLower();
            bool isValid = false;

            while (!isValid)
            {
                if (again == "y")
                {
                    return true;
                }
                else if (again == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            return false;
        }
        
        /// <summary>
        /// Switch to the next player's turn
        /// Toggle between X and O
        /// </summary>
        private void SwitchPlayer()
        {
            //Switch currentPlayer between 'X' and 'O'            
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else if(currentPlayer == 'O')
            {
                currentPlayer = 'X';
            }
        }
        
        // TODO: Add helper methods as needed
        // Examples:
        // - IsValidMove(int row, int col)
        // - IsBoardFull()
        // - CheckRow(int row, char player)
        // - CheckColumn(int col, char player)
        // - CheckDiagonals(char player)
        // - DropToken(int column, char player) // For Connect Four
    }
}