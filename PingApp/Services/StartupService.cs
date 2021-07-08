using System;

namespace PingApp.Services
{
    public class StartupService : IDisposable
    {

        private readonly WebService _web;

        public StartupService()
        {
            _web = new WebService();
        }

        public void Start() 
        {
           
            TaskService.Start();
            _web.Start();
        }

        public  void Stop()
        {
            Dispose();
            _web.Stop();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        public void Dispose(bool dispose)
        {
            _web.Dispose();
            GC.Collect();
        }
    }
}
