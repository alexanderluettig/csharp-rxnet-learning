namespace rx.rateLimitClient.Interfaces
{
    public interface IReactiveHttpClient
    {
        void Add(IEnumerable<IHttpEvent> events);
        void Add(IHttpEvent events);
    }
}