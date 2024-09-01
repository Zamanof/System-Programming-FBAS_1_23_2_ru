// Continuations

#region Simple Contiunation
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 7));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}

//firstTask.Wait();

//Console.WriteLine("End of Program");


#endregion


#region Wait All
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 7));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}


//Task.WaitAll(firstTask, secondTask);

//Console.WriteLine("End of Program");


#endregion

#region Wait Any
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 7));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}


//Task.WaitAny(firstTask, secondTask);

//Console.WriteLine("End of Program");
#endregion


#region ContinueWith OnlyOnRanToCompletion

//var firstTask = new Task<int>(() => TaskMethod("First Task", 2));
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 5));
//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Continue Task result = {t.Result}. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//secondTask.ContinueWith((t) =>
//{
//    OtherMethod();
//    Console.WriteLine($@"Continue Task result = {t.Result} is running. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.NotOnCanceled);
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
//Task.WaitAll(firstTask, secondTask);

//Console.WriteLine("End of program");

//Console.ReadKey();
#endregion

#region ContinueWith OnlyOnFaulted

//try
//{
//    var firstTask = new Task<int>(() => TaskMethod("First Task", 2));
//    var secondTask = new Task<int>(() => TaskMethod("Second Task", 5));
//    secondTask.ContinueWith((t) =>
//    {
//        OtherMethod();
//        Console.WriteLine($@"Continue Task result = {t.Result} is running. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
//    }, TaskContinuationOptions.OnlyOnFaulted);
//    secondTask.Start();
//    firstTask.ContinueWith((t) =>
//    {
//        Console.WriteLine($@"Continue Task result = {t.Result}. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
//    }, TaskContinuationOptions.OnlyOnRanToCompletion);


//    firstTask.Start();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Main thread - {i}");
//        Thread.Sleep(10);
//    }
//    Task.WaitAll(firstTask, secondTask);

//    Console.WriteLine("End of program");

//    Console.ReadKey();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion


#region ContinueWith with thread

//var firstTask = new Task<int>(() => TaskMethod("First Task", 2));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Continue Task result = {t.Result}. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);


//firstTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
//Task.WaitAll(firstTask);

//Console.WriteLine("End of program");

//Console.ReadKey();
#endregion


#region ContinueWith ExecuteSynchronously

//var firstTask = new Task<int>(() => TaskMethod("First Task", 2));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Continue Task result = {t.Result}. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.ExecuteSynchronously);


//firstTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
//Task.WaitAll(firstTask);

//Console.WriteLine("End of program");

//Console.ReadKey();
#endregion


#region Task.Status
/*
        Created,
        WaitingForActivation
        WaitingToRun
        Running
        WaitingForChildrenToComplete
        RanToCompletion
        Canceled
        Faulted
 */
//var firstTask = new Task<int>(() => TaskMethod("First Task", 1));
//try
//{

//    Console.WriteLine(firstTask.Status);
//    firstTask.Start();
//    Console.WriteLine(firstTask.Status);



//    while (true)
//    {
//        Console.WriteLine(firstTask.Status);
//        Thread.Sleep(100);
//        if (firstTask.IsCompleted) break;
//    }

//    firstTask.Wait();
//    Console.WriteLine(firstTask.Status);

//    Console.WriteLine("End of program");
//}
//catch (Exception)
//{

//    Console.WriteLine(firstTask.Status);
//}


//Console.ReadKey();
#endregion

#region Continuatuon
var firstTask = new Task<int>(() => TaskMethod("First Task", 2));
firstTask.Start();
while (true)
{
    // 1
    //if (firstTask.IsCompleted)
    //{
    //    OtherMethod(); break;
    //}

    if (firstTask.Status == TaskStatus.RanToCompletion)
    {
        Task.Run(OtherMethod);
        break;
    }
}
Console.ReadKey();
#endregion

int TaskMethod(string message, int second)
{
    Console.WriteLine($"Start {message} task!");
    Console.WriteLine($@"Task - {message} is running. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
    Thread.Sleep(second * 1000);
    //throw new Exception(message);
    Console.WriteLine($"End {message} task!");
    return second * 10;
}

void OtherMethod()
{
    Console.WriteLine("Other method is running");
    Console.WriteLine($@"Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
}