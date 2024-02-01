using System;

abstract class Choice
{
    public abstract string Name { get; }

    public abstract bool Beats(Choice otherChoice);
}

class Rock : Choice
{
    public override string Name => "Rock";

    public override bool Beats(Choice otherChoice)
    {
        return otherChoice is Scissors;
    }
}

class Paper : Choice
{
    public override string Name => "Paper";

    public override bool Beats(Choice otherChoice)
    {
        return otherChoice is Rock;
    }
}

class Scissors : Choice
{
    public override string Name => "Scissors";

    public override bool Beats(Choice otherChoice)
    {
        return otherChoice is Paper;
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose: Rock, Paper, or Scissors (type 'exit' to end)");
            string playerChoiceName = Console.ReadLine().ToLower();

            if (playerChoiceName == "exit")
            {
                break;
            }

            Choice playerChoice = GetChoiceByName(playerChoiceName);
            if (playerChoice == null)
            {
                Console.WriteLine("Invalid choice. Please choose Rock, Paper, or Scissors.");
                continue;
            }

            Choice computerChoice = GetComputerChoice();
            Console.WriteLine($"Computer chose: {computerChoice.Name}");

            string result = DetermineWinner(playerChoice, computerChoice);
            Console.WriteLine($"Result: {result}\n");
        }

        Console.WriteLine("Thanks for playing!");
    }

    static Choice GetComputerChoice()
    {
        Choice[] choices = { new Rock(), new Paper(), new Scissors() };
        Random random = new Random();
        int index = random.Next(choices.Length);
        return choices[index];
    }

    static Choice GetChoiceByName(string choiceName)
    {
        switch (choiceName)
        {
            case "rock":
                return new Rock();
            case "paper":
                return new Paper();
            case "scissors":
                return new Scissors();
            default:
                return null;
        }
    }

    static string DetermineWinner(Choice playerChoice, Choice computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return "It's a tie!";
        }
        else if (playerChoice.Beats(computerChoice))
        {
            return "You win!";
        }
        else
        {
            return "Computer wins!";
        }
    }
}
