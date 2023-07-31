using rx.playground;

var _ = new Consumer();

for (int i = 0; i < 100; i++)
{
    Consumer.Add(i);
}

Console.ReadLine();
