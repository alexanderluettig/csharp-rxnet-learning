using rx.playground;

var consumer = new Consumer(10, TimeSpan.FromSeconds(1));

for (int i = 0; i < 100; i++)
{
    consumer.Add(i);
}

Console.ReadLine();
