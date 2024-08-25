#region Albahari Tricks
//for (int i = 0; i < 10; i++)
//{
//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    })
//        .Start();
//}


//for (int i = 0; i < 10; i++)
//{
//    int tmp = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(tmp);
//    })
//        .Start();
//}

//string text = "Nadir";
//Thread thread1 = new(() =>
//{
//    string first = text;
//    Console.WriteLine(first);
//});
//text = "Atilla";
//Thread thread2 = new(() =>
//{
//    string second = text;
//    Console.WriteLine(second);
//});
//thread1.Start();
//thread2.Start();
#endregion

// Critical Section - koqda potoki obrashayutsya k obshey pamyati

#region Critical Section problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Counter.Count++;
//        }
//    });
//}

//foreach (Thread thread in threads)
//{
//    thread.Start();
//}

//Console.WriteLine(Counter.Count);

//foreach (Thread thread in threads)
//{
//    thread.Join();
//}

//Console.WriteLine(Counter.Count);
#endregion

#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            if (Counter.Count % 2 != 0)
//            {
//                Interlocked.Increment(ref Counter.CountOdd);
//            }
//            Interlocked.Increment(ref Counter.Count);
//        }
//    });

//}

//foreach (Thread thread in threads)
//{
//    thread.Start();
//}
//foreach (Thread thread in threads)
//{
//    thread.Join();
//}
//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.CountOdd);


#endregion

#region Monitor
//Thread[] threads = new Thread[5];
//object obj = new object();

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Monitor.Enter(obj);
//            try
//            {
//                if (Counter.Count % 2 != 0)
//                {
//                    Counter.CountOdd++;
//                }
//                Counter.Count++;
//            }
//            finally
//            {
//                Monitor.Exit(obj);
//            }
//        }
//    });
//}

//foreach (Thread thread in threads)
//{
//    thread.Start();
//}

//foreach (Thread thread in threads)
//{
//    thread.Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.CountOdd);
#endregion

#region lock
//Thread[] threads = new Thread[5];
//object obj = new object();

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            lock(obj)
//            {
//                if (Counter.Count % 2 != 0)
//                {
//                    Counter.CountOdd++;
//                }
//                Counter.Count++;
//            }
//        }
//    });
//}

//foreach (Thread thread in threads)
//{
//    thread.Start();
//}

//foreach (Thread thread in threads)
//{
//    thread.Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.CountOdd);
#endregion

#region deadlock
//object object1 = new();
//object object2 = new();

//Thread thread1 = new(ObliviousMethod);
//Thread thread2 = new(BlindMethod);
//thread1.Start();
//thread2.Start();
//while (true) { };

//void ObliviousMethod()
//{
//    Console.WriteLine("ObliviousMethod start");
//    lock (object1)
//    {
//        Thread.Sleep(1000);
//        lock (object2)
//        {

//        }
//    }
//    Console.WriteLine("ObliviousMethod end");
//}


//void BlindMethod()
//{
//    Console.WriteLine("BlindMethod start");
//    lock (object2)
//    {
//        Thread.Sleep(1000);
//        lock (object1)
//        {

//        }
//    }
//    Console.WriteLine("BlindMethod end");
// }
#endregion
class Counter
{
    public static int Count = 0;
    public static int CountOdd = 0;
}