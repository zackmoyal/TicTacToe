using System;

namespace TicTacToeProject
{
    public class TicTacToe
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to tic tac toe.");
            PlayGame();
            Console.WriteLine("Thanks for playing!");
        }

        public static void PlayGame()
        {
            char[,] board = new char[3, 3];          // Game board, 3x3 character array
            int[,] moveBoard = new int[3, 3];        // Move board, 3x3 int array
            int moves = 0;                           // Number of moves played so far (none)
            bool turnX = true;                       // is it X's turn?
            int move;                                // variable for user input

            SetupBoard(board, moveBoard);

            while (moves < 9)
            {
                DisplayBoard(board);
                Console.WriteLine($"Player {(turnX ? 'X' : 'O')}, enter your move (1-9): ");
                if (int.TryParse(Console.ReadLine(), out move) && IsValidMove(move, moveBoard))
                {
                    MakeMove(board, moveBoard, move, turnX);
                    if (CheckWinner(board))
                    {
                        DisplayBoard(board);
                        Console.WriteLine($"Player {(turnX ? 'X' : 'O')} wins!");
                        return;
                    }
                    turnX = !turnX;
                    moves++;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
            DisplayBoard(board);
            Console.WriteLine("It's a tie!");
        }

        private static void SetupBoard(char[,] board, int[,] moveBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                    moveBoard[i, j] = 0;
                }
            }
        }

        private static void DisplayBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidMove(int move, int[,] moveBoard)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            return moveBoard[row, col] == 0;
        }

        private static void MakeMove(char[,] board, int[,] moveBoard, int move, bool turnX)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            board[row, col] = turnX ? 'X' : 'O';
            moveBoard[row, col] = 1;
        }

        private static bool CheckWinner(char[,] board)
        {
            return CheckRows(board) || CheckColumns(board) || CheckDiagonals(board);
        }

        private static bool CheckRows(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] &&
                    board[i, 1] == board[i, 2] &&
                    board[i, 0] != '-')
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckColumns(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] &&
                    board[1, i] == board[2, i] &&
                    board[0, i] != '-')
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckDiagonals(char[,] board)
        {
            if (board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2] &&
                board[0, 0] != '-')
            {
                return true;
            }
            if (board[0, 2] == board[1, 1] &&
                board[1, 1] == board[2, 0] &&
                board[0, 2] != '-')
            {
                return true;
            }
            return false;
        }
    }
}