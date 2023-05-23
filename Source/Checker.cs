namespace HangMan.Source;

public static class Checker
{
	private static List<char> _word = new List<char>();

	public static void BuildList(string word)
	{
		for (int i = 0; i < word.Length; i++)
			_word.Add('_');
	}

	public static void PrintWord()
	{
		foreach (char c in _word)
			Console.Write($"{c} ");
	}

	public static void ComputeCharacters(char guess, string word)
	{
		bool foundOnce = false;

		for (int i = 0; i < word.Length; i++)
		{
			if (word[i] == guess)
			{
				_word[i] = guess;
				foundOnce = true;
			}
		}

		if (!foundOnce)
			Game.Lives--;
		
		if (!_word.Contains('_'))
			Game.Won = true;
	}
}
