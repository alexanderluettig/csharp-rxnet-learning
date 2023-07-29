using rx.httpObservable;

var uri = "https://api.chucknorris.io/jokes/random?category=dev";

var obs = new HttpClientObservable<Joke>(uri);
obs.Subscribe(x => Console.WriteLine(x.Value));

Console.ReadLine();
