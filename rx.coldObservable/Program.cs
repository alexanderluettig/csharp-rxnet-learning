using System.Reactive.Linq;

var observable = Observable.Interval(TimeSpan.FromSeconds(1));

// Starts counting up
observable.Subscribe(count => Console.WriteLine($"Observer 1: {count}"));

Console.ReadLine();

// Starts counting up but from 0 instead of the current count of the first observer
observable.Subscribe(count => Console.WriteLine($"Observer 2: {count}"));

Console.ReadLine();