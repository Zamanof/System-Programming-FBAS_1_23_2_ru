using System.Net;

namespace SP_07._Main_Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string url = @"https://habr.com/ru/articles/";
            //WebClient webClient = new();
            //var txt = await webClient.DownloadStringTaskAsync(url);
            //Console.WriteLine(txt);

            int a = 5; int b = 6;
            Console.WriteLine(await returnValueAsync(a, b));
        }

        static async Task<int> returnValueAsync(int a, int b)
        {
            Thread.Sleep(10000);
            return a + b;
        } 
    }
}
