using rx.rateLimitClient.Interfaces;

namespace rx.rateLimitClient
{
    internal class HttpEvent : IHttpEvent
    {
        public string Endpoint { get; init; }
        public HttpMethod Method { get; init; }
        public (string key, string value)[] Parameters { get; init; }

        public HttpEvent(string endpoint, HttpMethod method, (string key, string value)[] parameters)
        {
            Endpoint = endpoint;
            Method = method;
            Parameters = parameters;
        }
    }
}
