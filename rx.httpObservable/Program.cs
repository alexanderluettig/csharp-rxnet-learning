using System.Reactive.Disposables;
using System.Reactive.Linq;
using rx.httpObservable;

#region RandomJoke

var randomJokeUri = "https://api.chucknorris.io/jokes/random?category=dev";

Console.WriteLine("Getting random joke...");
var randomJokeObserver = new HttpClientObservable<Joke>(randomJokeUri);
randomJokeObserver
    .Subscribe(
        joke => Console.WriteLine(joke.Value),
        ex => Console.WriteLine("Error: " + ex.Message),
        () => Console.WriteLine("Random joke completed"));

// obs.Subscribe(new ResponseObserver<Joke>()); // same as above

#endregion

#region Categories

var categoriesUri = "https://api.chucknorris.io/jokes/categories";
var randomJokeUriWithoutCategory = "https://api.chucknorris.io/jokes/random?category=";

var categorieObserver = new HttpClientObservable<string[]>(categoriesUri);
categorieObserver
    .SelectMany(cats => cats)
    .SelectMany(cat => new HttpClientObservable<Joke>(randomJokeUriWithoutCategory + cat))
    .Subscribe(Console.WriteLine);

#endregion

#region inline Observable

var obs = Observable.Create<Joke>(observer =>
{
    var cancellationTokenSource = new CancellationTokenSource();

    Task.Run(async () =>
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(randomJokeUri);
        var data = await response.Content.ReadAsAsync<Joke>();

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
});

obs.Subscribe(new ResponseObserver<Joke>());

#endregion

Console.ReadLine();

// x.Dispose();
// Console.ReadLine();

