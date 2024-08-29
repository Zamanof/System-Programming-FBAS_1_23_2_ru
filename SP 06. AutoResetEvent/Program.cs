AutoResetEvent _workEvent = new AutoResetEvent(false);
AutoResetEvent _mainEvent = new AutoResetEvent(false);

Thread thread = new Thread(() =>
{
    SomeProcess(1);
});
thread.Start();
Console.WriteLine("Waiting SomeProcess");

_workEvent.WaitOne();

// 2. start
Console.WriteLine("Starting Some Process");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main process - {i}");
    Thread.Sleep(TimeSpan.FromSeconds(1));
}

// 2. End
_mainEvent.Set();

Console.WriteLine("Worker is doing some job");
_workEvent.WaitOne();

Console.WriteLine("Complete");

void SomeProcess(int seconds)
{
    // 1. Start
    Console.WriteLine("Starting some process");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine("Ok");
    // 1. End
    _workEvent.Set();

    Console.WriteLine("Main thread is working");
    _mainEvent.WaitOne();
    
    // 3. Start
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Some process - {i}");
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }

    // 3. End
    _workEvent.Set();

}