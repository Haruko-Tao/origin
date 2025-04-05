using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;

public enum GuessingPlayer
{
    Human,
    Machine
}
public class LuckyStrike
{
    private readonly int max;
    private readonly int maxTries;
    private readonly GuessingPlayer guessingPlyayer;

    public LuckyStrike(int max = 100, int maxTries = 5, GuessingPlayer guessinPlayer = GuessingPlayer.Human)
    {
        this.max = max;
        this.maxTries = maxTries;
        this.guessingPlyayer = guessinPlayer;
    }

    public void Start()
    {
        if (guessingPlyayer == GuessingPlayer.Human)
        {
            HumanGuesses();
        }
        else
        {
            MachineGuesses();
        }
    }

    private void MachineGuesses()
    {
        Console.WriteLine("Enter a number thet's going to be guessed by a computer");

        int guessedNumber = -1;
        while (guessedNumber == -1)
        {
            int parseNumber = int.Parse(Console.ReadLine());
            if (parseNumber >= 0 && parseNumber <= this.max)
            {
                guessedNumber = parseNumber;
            }
        }

        int lastGuess = -1;
        int min = 0;
        int max = this.max;
        int tries = 0;

        while (lastGuess != guessedNumber && tries < maxTries)
        {
            lastGuess = (max + min) / 2;
            Console.WriteLine($"Did you guess this number - {lastGuess}?");
            Console.WriteLine("If yes, enter 'y', if you number is greater - enter 'g', if less - 'l'");

            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Console.WriteLine("Super! I guessed your number, man!");
                break;
            }
            else if (answer == "g")
            {
                min = lastGuess;
            }
            else
            {
                max = lastGuess;
            }

            if (lastGuess == guessedNumber)
            {
                Console.WriteLine("Don't cheat, man!");
            }

            tries++;
            if (tries == maxTries)
            {
                Console.WriteLine("No tries anymore :( I lost!");
            }
        }
    }

    private void HumanGuesses()
    {
        Random radn = new Random();
        int guessedNumber = radn.Next(0, max);

        int lastGuess = -1;
        int tries = 0;
        while (lastGuess != guessedNumber && tries < maxTries)
        {
            Console.WriteLine("Guess the number!");
            lastGuess = int.Parse(Console.ReadLine());

            if (lastGuess == guessedNumber)
            {
                Console.WriteLine("Congrats! You guessed the number!");
                break;
            }
            else if (lastGuess < guessedNumber)
            {
                Console.WriteLine("My number is greater");
            }
            else
            {
                Console.WriteLine("My namber is less!");
            }

            tries++;

            if (tries == maxTries)
            {
                Console.WriteLine("You lost!");
            }
        }
    }
}