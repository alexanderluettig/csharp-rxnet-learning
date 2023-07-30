using System.Reactive.Linq;
using System.Reactive.Subjects;

#region Subject

var subject = new Subject<int>();
subject.Subscribe(e => Console.WriteLine("Observer1: " + e));
subject.OnNext(1);
subject.OnNext(2);

Console.ReadLine();

subject.Subscribe(e => Console.WriteLine("Observer2: " + e));
subject.OnNext(3);

#endregion

#region BehaviorSubject

// BehaviorSubject stores the latest value and emits it to any new subscribers
var behaviorSubject = new BehaviorSubject<int>(0);
behaviorSubject.Subscribe(e => Console.WriteLine("B_Observer1: " + e));
behaviorSubject.OnNext(1);
behaviorSubject.OnNext(2);

behaviorSubject.Subscribe(e => Console.WriteLine("B_Observer2: " + e));
behaviorSubject.OnNext(3);

#endregion

#region ReplaySubject

// ReplaySubject stores all the values and emits them to any new subscribers
// The first parameter is the buffer size
// The second parameter is the window size
var replaySubject = new ReplaySubject<int>(2, TimeSpan.FromSeconds(1));
replaySubject.Subscribe(e => Console.WriteLine("R_Observer1: " + e));
replaySubject.OnNext(1);
replaySubject.OnNext(2);

replaySubject.Subscribe(e => Console.WriteLine("R_Observer2: " + e));
replaySubject.OnNext(3);

#endregion

#region AsyncSubject

// AsyncSubject stores the last value and emits it to any new subscribers
// only when the subject is completed

var asyncSubject = new AsyncSubject<int>();
asyncSubject.Subscribe(e => Console.WriteLine("A_Observer1: " + e));
asyncSubject.OnNext(1);
asyncSubject.OnNext(2);

asyncSubject.Subscribe(e => Console.WriteLine("A_Observer2: " + e));
asyncSubject.OnNext(3);
asyncSubject.OnCompleted();

#endregion

Console.WriteLine("Press any key to exit");
Console.ReadLine();

var foo = new Foo();
// foo.Loaded += Console.WriteLine;
// foo.Load();

foo.Loaded.Subscribe(Console.WriteLine);
foo.Load();

class Foo
{
    // public event Action<string> Loaded;
    public IObservable<string> Loaded => loadedSubject.AsObservable();

    private readonly ISubject<string> loadedSubject = new Subject<string>();

    public void Load()
    {
        // Loaded?.Invoke("");
        loadedSubject.OnNext("Data");
    }
}