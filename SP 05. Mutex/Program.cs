// lock/monitor - lock mechanism
// Mutex, Semaphore, SemaphoreSlim - Signaling mechanism

#region Mutex - Mutual exclusion (Internal thread)
//Mutex mutex = new Mutex();

//int numb = 1;
//for (int i = 0; i < 5; i++)
//{
//    Thread thread = new(Count);
//    thread.Name = $"Thread number {i}";
//    thread.Start();
//}
//Console.ReadKey();

//void Count()
//{
//    mutex.WaitOne();
//    for (int i = 0; i< 10; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {numb++}");
//    }
//    mutex.ReleaseMutex();
//}
#endregion

#region Global Mutex - Mutual exclusion (External thread)

string MutexName = "Rasilla";
using var mutex = new Mutex(false, MutexName);

if (!mutex.WaitOne(30000))
{
    Console.WriteLine("Other instance is running...");
    Thread.Sleep(1000);
    return;
}
else
{
    Console.WriteLine("My Code is running");
    Console.ReadKey();
    mutex.ReleaseMutex();
}

#endregion
