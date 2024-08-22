//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

//Thread thread1 = new Thread(() =>
//{
//    for (int i = 0; i < 10000; i++)
//    {
//        Console.WriteLine($"\t My own thread: {Thread.CurrentThread.ManagedThreadId} - {i} " +
//            $"- {Thread.CurrentThread.IsBackground}");
//    }
//});

//Thread thread2 = new Thread(Some);

//thread1.IsBackground = true;
//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;
//thread1.Start();
//thread2.Start();


//for (int i = 0; i < 100; i++)
//{
//    Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId} - {i} " +
//        $"{Thread.CurrentThread.IsBackground}");
//}

///*thread1.Join();*/ // ojidaniye vizivayeshoqo thread-a vizivayemoqo background thread-a



//void Some()
//{
//    for (int i = 0; i < 100; i++)
//    {
//        Console.WriteLine($"\t\t My Some method thread: {Thread.CurrentThread.ManagedThreadId} - {i} " +
//            $"- {Thread.CurrentThread.IsBackground}");
//    }
//}