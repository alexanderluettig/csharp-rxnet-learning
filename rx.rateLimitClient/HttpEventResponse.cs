using rx.rateLimitClient.Interfaces;

namespace rx.rateLimitClient
{
    internal class HttpEventResponse : IHttpEventResponse
    {
        public HttpEventResponse(string endpoint, HttpMethod method, HttpResponseMessage response)
        {
            Endpoint = endpoint;
            Method = method;
            Response = response;
        }

        public string Endpoint { get; init; }
        public HttpMethod Method { get; init; }
        public HttpResponseMessage Response { get; init; }
    }
}