namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var game = new LuckyStrike(guessinPlayer: GuessingPlayer.Machine);
        game.Start();

        Console.ReadLine();
        Console.ReadLine();

    }
}