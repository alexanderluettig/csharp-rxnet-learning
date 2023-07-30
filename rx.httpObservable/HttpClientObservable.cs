using System.Reactive.Disposables;

namespace rx.httpObservable
{
    public class HttpClientObservable<T> : IObservable<T>
    {
        private readonly string _uri = string.Empty;

        public HttpClientObservable(string uri)
        {
            _uri = uri;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Task.Run(async () =>
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(_uri);
                var data = await response.Content.ReadAsAsync<T>();

                if (response.IsSuccessStatusCode)
                {
                    observer.OnNext(data);
                    observer.OnCompleted();
                }
                else
                {
                    observer.OnError(new Exception("Error with StatusCode: " + response.StatusCode));
                }
            }, cancellationTokenSource.Token);

            return Disposable.Create(() => cancellationTokenSource.Cancel());
        }
    }
}