using PingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace PingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory
                .Run(c =>
                {
                    c.SetDescription("Универсальный сервис.");
                    c.SetServiceName("UniversalService");
                    c.SetDisplayName("UniversalService");
                    c.Service<StartupService>(p =>
                    {
                        p.ConstructUsing(() => new StartupService());
                        p.WhenStarted(s => s.Start());
                        p.WhenStopped(s => s.Stop());
                    });
                });
        }
    }
}
