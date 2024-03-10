namespace TicTacToe
{
    class Program
    {
        // The board is represented by a char array
        // Доска представлена массивом символов
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        static int position;
        
        // The current player is represented by a char
        // Текущий игрок представлен символом
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            // The game ends when the game is won
            // Игра заканчивается, когда игра выиграна
            bool gameWon = false;

            // Loop until the game is won
            // Цикл до выигрыша игры
            while (!gameWon)
            {
                // Draw the board, get a position, and make a move 
                // Нарисовать доску, получить позицию и сделать ход
                DrawBoard();
                position = GetPosition();
                if (IsValidMove())
                {
                    MakeMove();
                    
                    // Check if the game is won and switch the player
                    // Проверить, выиграл ли игрок и переключить игрока
                    gameWon = CheckWin();
                    if (!gameWon)
                        SwitchPlayer();
                }
                else
                {
                    // The move was invalid, so ask again
                    // Ход был недействителен, поэтому спросите еще раз
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            // Draw the board one last time and print the winner
            // Нарисуйте доску еще раз и напечатайте победителя
            DrawBoard();
            if (gameWon)
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            // Print the winner
            // Напечатать победителя
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine($"__|___|___");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine($"__|___|___");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");

        }

        static int GetPosition()
        {
            Console.WriteLine($"Player {currentPlayer} choose a position (1-9): ");
            position = int.Parse(Console.ReadLine()) - 1;
            return position;
        }

        static bool IsValidMove()
        {
            // Check if the position is valid
            // Проверить, действительна ли позиция
            return position >=0 && position <= 9 && board[position] != 'X' && board[position] != 'O';
        }

        static void MakeMove()
        {
            // Make the move
            // Сделать ход
            board[position] = currentPlayer;
        }

        static bool CheckWin()
        {
            // Check if the current player has won
            // Проверить, выиграл ли текущий игрок
            return
                (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer ||
                 board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer ||
                 board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer ||
                 board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer ||
                 board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer ||
                 board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer ||
                 board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer ||
                 board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);
        }

        static void SwitchPlayer()
        {
            // Switch the current player
            // Переключить текущего игрока
           currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
             
        }

        }
    }
