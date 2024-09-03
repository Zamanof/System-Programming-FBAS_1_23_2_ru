// Thread -> ThreadPool -> TPL -> syntax sugar + love = async await

Console.WriteLine($"Main method start in thread {Thread.CurrentThread.ManagedThreadId}"); // 1

//SomeMethod();
SomeMethodAsync();

Console.WriteLine($"Main method end in thread {Thread.CurrentThread.ManagedThreadId}"); // 1
Console.ReadKey();
void SomeMethod()
{
    Console.WriteLine($"Some method start in thread {Thread.CurrentThread.ManagedThreadId}"); //1
    Task.Run(() =>
    {
        Console.WriteLine($"Some method task start in thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        Console.WriteLine($"Some method task end in thread {Thread.CurrentThread.ManagedThreadId}");

    });
    Console.WriteLine($"Some method end in thread {Thread.CurrentThread.ManagedThreadId}"); //1
}

async void SomeMethodAsync()
{
    Console.WriteLine($"Some Async method start in thread {Thread.CurrentThread.ManagedThreadId}"); // 1
    await Task.Run(() =>
    {
        Console.WriteLine($"Some Async method task start in thread {Thread.CurrentThread.ManagedThreadId} IsThreadPool {Thread.CurrentThread.IsThreadPoolThread}");
        Thread.Sleep(10000);
        Console.WriteLine($"Some Async method task end in thread {Thread.CurrentThread.ManagedThreadId} IsThreadPool {Thread.CurrentThread.IsThreadPoolThread}");

    });
    Console.WriteLine($"Some Async method end in thread {Thread.CurrentThread.ManagedThreadId} IsThreadPool {Thread.CurrentThread.IsThreadPoolThread}"); // 1
}
