using System.Diagnostics;

int operationCount = 500;
var watch = new Stopwatch();
watch.Start();
UseThread(operationCount);
watch.Stop();
Console.WriteLine($"Milliseconds {watch.ElapsedMilliseconds}");
watch.Reset();

watch.Start();
UseThreadPool(operationCount);
watch.Stop();
Console.WriteLine($"Milliseconds {watch.ElapsedMilliseconds}");

void UseThread(int operationCount)
{
    using(var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationCount; i++)
        {
            var thread = new Thread(() => {
                /*Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}")*/;
                Thread.Sleep(100);
                count.Signal();
            });
            thread.Start();
        }
        count.Wait();
        Console.WriteLine();
    }
}

void UseThreadPool(int operationCount)
{
    List<int> threads = new List<int>();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("ThreadPool...");
        for (int i = 0; i < operationCount; i++)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(100);
                //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                if (!threads.Contains(Thread.CurrentThread.ManagedThreadId))
                threads.Add(Thread.CurrentThread.ManagedThreadId);
                count.Signal();
            });          
        }
        count.Wait();
        Console.WriteLine($"Count of threads {threads.Count}");
    }
}
