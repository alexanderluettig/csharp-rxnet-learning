namespace rx.rateLimitClient
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Starting Http Client...");

            var uri = "https://api.chucknorris.io/jokes/";
            var categories = new[] {
  "animal",
  "career",
  "celebrity",
  "dev",
  "explicit",
  "fashion",
  "food",
  "history",
  "money",
  "movie",
  "music",
  "political",
  "religion",
  "science",
  "sport",
  "travel"
};

            var client = new ReactiveHttpClient(uri, 5, TimeSpan.FromSeconds(5));

            for (int i = 0; i < 10; i++)
            {
                var randomCategory = new Random().Next(0, categories.Length);
                client.Add(new HttpEvent("/random", HttpMethod.Get, new (string key, string value)[] { ("category", categories[randomCategory]) }));

                if (i == 9)
                {
                    i = 0;
                    Console.ReadLine();
                }
            }
        }
    }
}