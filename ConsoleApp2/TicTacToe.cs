using System.Threading.Channels;

namespace ConsoleApp2;

public class TicTacToe
{

    static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
    static char currenPlayer = 'X';

    public void Start(bool gameRunning)
    {
        GameRunning();
    }

    private void GameRunning()
    {
        int moves = 0;
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            PrintBoard();

            Console.WriteLine($"Игрок {currenPlayer}, выбирает ячейку ( 0 - 8): ");
            int choise = int.Parse(Console.ReadLine());

            board[choise] = currenPlayer;
            moves++;

            if (CheckWin()) // Проверка победы
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Игрок {currenPlayer} победил! 🎉");
                gameRunning = false;
            }
            else if (moves == 9) // Ничья, если поле заполнено
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Ничья! 🤝");
                gameRunning = false;
            }
            else
            {
                currenPlayer = (currenPlayer == 'X') ? 'O' : 'X'; // Смена игрока
            }
        }
        //Вывод игрового поля
        static void PrintBoard()
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        static bool CheckWin()
        {
            int[,] winPatterns =
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Горизонтали
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Вертикали
                { 0, 4, 8 }, { 2, 4, 6 } // Диагонали
            };

            for (int i = 0; i < winPatterns.GetLength(0); i++) // Перебираем строки
            {
                int a = winPatterns[i, 0];
                int b = winPatterns[i, 1];
                int c = winPatterns[i, 2];

                if (board[a] == currenPlayer && board[b] == currenPlayer && board[c] == currenPlayer)
                {
                    return true; // Победа!
                }
            }
            return false; // Победы нет
        }
    }
}
    