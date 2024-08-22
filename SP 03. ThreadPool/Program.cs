ThreadPool.QueueUserWorkItem(AsyncOperations, "Hello");
ThreadPool.QueueUserWorkItem(o =>
{
    SomeOperations();
});
Console.WriteLine("Main method start...");

Console.WriteLine($"Main method thread Id: {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Main method thread isBackground: {Thread.CurrentThread.IsBackground}");
Console.WriteLine($"Main method thread isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");

//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);

//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);


Console.WriteLine("Main method end...");
//Console.ReadKey();
void AsyncOperations(object state)
{
    Console.WriteLine("\tAsyncOperations method start...");
    Console.WriteLine($"\t{state.ToString()}");
    Thread.Sleep(10);
    Console.WriteLine($"\tAsyncOperations thread Id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\tAsyncOperations thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\tAsyncOperations thread isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\tAsyncOperations method end...");
}

void SomeOperations()
{
    Console.WriteLine("\t\tSomeOperations method start...");
    Thread.Sleep(10);
    Console.WriteLine($"\t\tSomeOperations thread Id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\t\tSomeOperations thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\t\tSomeOperations thread isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\t\tSomeOperations method end...");
}

