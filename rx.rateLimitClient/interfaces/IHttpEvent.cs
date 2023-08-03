namespace rx.rateLimitClient.Interfaces
{
    public interface IHttpEvent
    {
        string Endpoint { get; init; }
        HttpMethod Method { get; init; }
        (string key, string value)[] Parameters { get; init; }
    }
}