using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PingApp.Services
{
    public class TaskService
    {
        static HttpClient client = new HttpClient();
        const string host = @"https://localhost:44369/";

        public static Task Start()
        {
            return Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    for (int i = 1; i <= 1000; i++)
                    {
                        var url = $"{host}api/Check/{i}";
                        try
                        {
                            var response = await client.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var text = await response.Content.ReadAsStringAsync();
                                Console.WriteLine(text);

                            }
                            var text1 = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(text1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Хост: {url} Ошибка: {e.Message}");
                        }

                    }
                    Thread.Sleep(10000);
                }
            });
        }
    }
}
