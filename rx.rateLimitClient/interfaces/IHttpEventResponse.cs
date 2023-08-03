namespace rx.rateLimitClient.Interfaces
{
    internal interface IHttpEventResponse
    {
        string Endpoint { get; init; }
        HttpMethod Method { get; init; }
        HttpResponseMessage Response { get; init; }
    }
}