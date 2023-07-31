using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace rx.playground
{
    public class Consumer
    {
        private readonly static ISubject<int> _subject = new Subject<int>();

        public Consumer()
        {
            _subject
                .Buffer(10)
                .Zip(Observable.Interval(TimeSpan.FromSeconds(1)), (x, y) => x)
                .Subscribe(x =>
                {
                    foreach (var item in x)
                    {
                        Console.WriteLine(item);
                    }
                });
        }

        public static void Add(int value) => _subject.OnNext(value);
    }
}