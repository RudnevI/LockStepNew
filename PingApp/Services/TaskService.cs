using log4net;
using log4net.Config;
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
        private readonly static ILog log = LogManager.GetLogger("LOGGER");

        

        static TaskService()
        {
            XmlConfigurator.Configure();
        }

        public static Task Start()
        {
            return Task.Factory.StartNew(async () =>
            {
                double successCount;
                double failureCount;
                double overallCount;
                while (true)
                {
                    successCount = 0;
                    failureCount = 0;
                    overallCount = 0;

                    for (int i = 1; i <= 3; i++)
                    {
                        var url = $"{host}api/Check/{i}";
                        try
                        {
                            var response = await client.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var text = await response.Content.ReadAsStringAsync();
                                Console.WriteLine(text);
                                log.Info($"success response: {text}");
                                successCount++;
                                
                            }
                            else
                            {
                                var text1 = await response.Content.ReadAsStringAsync();
                                Console.WriteLine(text1);
                                log.Info($"error response: {text1}");
                                failureCount++;
                            }
                            overallCount++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Хост: {url} Ошибка: {e.Message}");
                        }

                    }

                    Console.WriteLine($"Success: {successCount/overallCount};");

                    Console.WriteLine($"Failure: {failureCount/overallCount};");

                    Thread.Sleep(10000);
                }
            });
        }
    }
}
