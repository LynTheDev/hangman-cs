using HangMan.Source.JSON;

namespace HangMan.Source;

public static class Game
{
	public static int Lives = 6;
	public static bool Won = false;

	public static void Main(string[] args)
    {
		string[]? words = JsonParser.Deserialise();
		
		string word = string.Empty;
		if (words is not null)
			word = words[Random.Shared.Next(0, words.Length)];
		
		Checker.BuildList(word);

		Console.Clear();
		Console.WriteLine("type \"giveup\" to quit or \"clear\" to clear window");

		while (true)
		{
			if (Lives == 0)
			{
				Console.WriteLine($"You lost..\nWith the word {word}");
				break;
			}

			Console.WriteLine($"Lives: {Lives}");
			Checker.PrintWord();

			Console.Write("\n> ");
			string? guess = Console.ReadLine();
			if (guess == null)
				continue;
			
			if (guess == "giveup")
			{
				Console.WriteLine($"Word was {word}.");
				break;
			}

			if (guess == "clear")
			{
				Console.Clear();
				continue;
			}

			char finalGuess;
			var success = char.TryParse(guess, out finalGuess);
			if (success)
			{
				Checker.ComputeCharacters(char.ToLower(finalGuess), word);

				if (Won)
				{
					Console.WriteLine($"You actually won!!!!");
					break;
				}
			}	
			else
			{
				Console.WriteLine("Illegal guess.");
				continue;
			}
		}
    }
}
