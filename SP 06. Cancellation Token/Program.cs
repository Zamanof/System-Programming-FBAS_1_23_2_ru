#region Interrupt
//Thread thread = new Thread(Download);

//thread.Start();

//var key = Console.ReadKey();

//if (key.Key == ConsoleKey.Enter)
//{
//    Console.WriteLine("Dowbloading process cancel...");
//    thread.Interrupt();
//}

//void Download()
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {
//        Console.WriteLine($"{i} %");
//        Thread.Sleep(100);
//        Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion

#region Cancellation Token with return

//using CancellationTokenSource cts = new();

//CancellationToken token = cts.Token;

//ThreadPool.QueueUserWorkItem(o =>
//{
//    Download(token);
//});

//while (true)
//{
//    var key = Console.ReadKey();

//    if(key.Key == ConsoleKey.Enter)
//    {
//        cts.Cancel();
//        Thread.Sleep(1000);
//        Console.WriteLine("Downloading process cancel...");
//        Thread.Sleep(1000);
//        Console.ReadKey();
//    }

//}

//void Download(CancellationToken token)
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {
//        Console.WriteLine($"{i} %");
//        Thread.Sleep(1000);
//        Console.Clear();

//        if (token.IsCancellationRequested)
//        {

//            return;
//        }
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion

#region Cancellation Token with exception
//using CancellationTokenSource cts = new();

//CancellationToken token = cts.Token;

//ThreadPool.QueueUserWorkItem(o =>
//{
//    try
//    {
//        Download(token);
//    }
//    catch (OperationCanceledException ex) 
//    {
//        Console.WriteLine(ex.Message);
//        Console.WriteLine("Downloading process cancel...");
//    }

//});

//while (true)
//{
//    var key = Console.ReadKey();

//    if (key.Key == ConsoleKey.Enter)
//    {
//        cts.Cancel();
//        Thread.Sleep(1000);
//        Console.ReadKey();
//    }

//}

//void Download(CancellationToken token)
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {
//        token.ThrowIfCancellationRequested();
//        Console.WriteLine($"{i} %");
//        Thread.Sleep(1000);
//        Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion