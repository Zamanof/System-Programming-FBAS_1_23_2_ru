var grandFatherTask = new Task<int>(()=>
{
    var fatherTask = Task.Factory.StartNew(() =>
    {
        var grandsonTask = Task.Factory.StartNew(() =>
        {
            TaskMethod("grandsonTask", 8);
        }, TaskCreationOptions.AttachedToParent);
        TaskMethod("fatherTask", 5);
    }, TaskCreationOptions.AttachedToParent);

    return TaskMethod("grandFatherTask", 3);
});

grandFatherTask.Start();
Console.WriteLine(grandFatherTask.Result);
Console.WriteLine("End");

int TaskMethod(string message, int second)
{
    Console.WriteLine($"Start {message} task!");
    Console.WriteLine($@"Task - {message} is running. Id - {Thread.CurrentThread.ManagedThreadId}, IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}");
    Thread.Sleep(second * 1000);
    //throw new Exception(message);
    Console.WriteLine($"End {message} task!");
    return second * 10;
}
