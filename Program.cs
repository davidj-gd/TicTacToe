

class TicTacToe
{
    private static char[,] board = new char [3, 3];
    private static char currentPlayer = 'X';

    static void Main()
    {
        InitializeBoard();
        Console.WriteLine("LET'S PLAY TICTACTOEEEE");

        while (true)
        {
            Console.Clear();
            DisplayBoard();
            if (currentPlayer == 'X')
            {
                PlayerMove();
            }
            else
            {
                AIMove();
            }
            
            if(CheckWin())
            {
                DisplayBoard();
                Console.WriteLine($"Player {currentPlayer} won the game!");
                break;
            }

            if (CheckDraw())
            {
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                break;
            }
            SwitchPlayer();
        }
    }

    static void InitializeBoard()
    {
        for(int row = 0; row < 3; row++)
            for(int column = 0; column < 3; column++)
                board[row, column] = ' ';
    }

    static void DisplayBoard()
    {
        Console.WriteLine();
        for (int row = 0; row < 3; row++)
        {
            Console.Write(" ");
            for (int column = 0; column < 3; column++)
            {
                Console.Write(board[row, column]);
                if (column < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (row < 2) Console.WriteLine("---+---+---");
        }
        Console.WriteLine();
    }


    static void PlayerMove()
    {
        int row, column;
        while (true)
        {
            Console.Write($"Player {currentPlayer}, Choose a row! 1,2 or 3: ");
            if (!int.TryParse(Console.ReadLine(),out row) || row < 1 || row > 3)
            {
                Console.WriteLine("Please enter a valid row.");
                continue;
            }
            Console.Write($"Player {currentPlayer}, choose column 1, 2, or 3: ");
            if (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > 3)
            {
                Console.WriteLine("Please enter a valid column.");
                continue;
            }

            row--;
            column--;
            if (board[row, column] == ' ')
            {
                board [row, column] = currentPlayer;
                break;
            }
            else
            {
                Console.WriteLine("This spot is taken, try another one!");
            }
        }
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board [i, 1] == currentPlayer && board [i, 2] == currentPlayer)
                || (board[0, i] == currentPlayer && board [1, i] == currentPlayer && board [2, i] == currentPlayer))
                return true;
        }
        return false;
    }

    static bool CheckDraw()
    {
        foreach (char c in board)
            if (c == ' ') return false;
        return true;
    }

    static void AIMove()
    {
        System.Threading.Thread.Sleep(2000);
        Random random = new Random();
        int row, column;

        while (true)
        {
            row = random.Next(0, 3);
            column = random.Next(0, 3);

            if (board[row, column] == ' ')
            {
                board[row, column] = currentPlayer;
                Console.WriteLine($"AI placed {currentPlayer} at row {row + 1}, column {column + 1}");
                break;
            }
        }
    }
    
}