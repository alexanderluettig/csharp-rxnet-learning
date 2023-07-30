namespace rx.httpObservable
{
    public class ResponseObserver<T> : IObserver<T>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error: {0}", error.Message);
        }

        public void OnNext(T value)
        {
            Console.WriteLine("Received value: {0}", value);
        }
    }
}