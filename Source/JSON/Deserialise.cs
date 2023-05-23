using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HangMan.Source.JSON;

public static class JsonParser
{
	public static string[]? Deserialise()
	{
		Model? item;

		string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/words.json");
		using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
			item = System.Text.Json.JsonSerializer.Deserialize<Model>(json);
        }

		return item?.WordList ?? null!;
	}
}
