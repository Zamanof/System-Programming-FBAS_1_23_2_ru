var task = Task.Run(() => 
    TaskReturnMethod("Task1", 5)
);

var result = task.Result;
Console.WriteLine(result);
Console.WriteLine("End of code");


int TaskReturnMethod(string message, int second)
{
    Console.WriteLine($@"Task - {message} is running.
Id - {Thread.CurrentThread.ManagedThreadId}
IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
    Task.Delay(second * 1000);
    return second * 10;
}
