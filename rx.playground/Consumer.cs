using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace rx.playground
{
    public class Consumer
    {
        private readonly ISubject<int> _subject = new Subject<int>();

        public Consumer(int buffersize = 1, TimeSpan interval = default)
        {
            _subject
                .Buffer(buffersize)
                .Zip(Observable.Interval(interval), (x, y) => x)
                .Subscribe(x =>
                {
                    foreach (var item in x)
                    {
                        Console.WriteLine(item);
                    }
                });
        }

        public void Add(int value) => _subject.OnNext(value);
    }
}