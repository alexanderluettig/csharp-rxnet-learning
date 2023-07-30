using System.Reactive.Linq;

var observable = Observable.Interval(TimeSpan.FromSeconds(1)).Publish();
observable.Connect();

observable.Subscribe(e => Console.WriteLine("Observer1: " + e));

Console.ReadLine();

observable.Subscribe(e => Console.WriteLine("Observer2: " + e));

Console.ReadLine();