using System.Reactive.Linq;
using System.Reactive.Subjects;
using rx.rateLimitClient.Interfaces;

namespace rx.rateLimitClient
{
    public sealed class ReactiveHttpClient : IReactiveHttpClient
    {
        private string Uri { get; init; }
        private readonly ISubject<IHttpEvent> InputObservable = new Subject<IHttpEvent>();
        private readonly ISubject<IHttpEventResponse> OutputObservable = new Subject<IHttpEventResponse>();
        private HttpClient HttpClient { get; } = new();

        public ReactiveHttpClient(string uri, int buffersize = 1, TimeSpan interval = default)
        {
            Uri = uri;
            HttpClient = new HttpClient();

            InputObservable
                .Buffer(buffersize)
                .Zip(Observable.Interval(interval), (x, y) => x)
                .Subscribe(x =>
                {
                    foreach (var item in x)
                    {
                        HandleEvent(item);
                    }
                });

            OutputObservable
                .Subscribe(HandleResponse);
        }

        public void Add(IEnumerable<IHttpEvent> events)
        {
            foreach (var item in events)
            {
                InputObservable.OnNext(item);
            }
        }

        public void Add(IHttpEvent events) => InputObservable.OnNext(events);

        private async void HandleEvent(IHttpEvent item)
        {
            var response = item.Method switch
            {
                HttpMethod.Get => await HttpClient.GetAsync(Uri + item.Endpoint),
                _ => throw new ArgumentException(nameof(item.Method))
            };

            OutputObservable.OnNext(new HttpEventResponse(item.Endpoint, item.Method, response));
        }

        private static async void HandleResponse(IHttpEventResponse item)
        {
            var joke = await item.Response.Content.ReadAsAsync<Joke>();
            Console.WriteLine(joke);
        }
    }
}