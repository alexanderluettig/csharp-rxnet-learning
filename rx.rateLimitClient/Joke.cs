namespace rx.rateLimitClient
{
    public class Joke
    {
        public required string[] Categories { get; set; }
        public required string Created_at { get; set; }
        public required string Icon_url { get; set; }
        public required string Id { get; set; }
        public required string Updated_at { get; set; }
        public required string Url { get; set; }
        public required string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}