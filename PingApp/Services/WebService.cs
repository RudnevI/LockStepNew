using Microsoft.Owin.Hosting;
using PingApp.Web;
using System;

namespace PingApp.Services
{
    public class WebService
    {
        private IDisposable _dsp;
        public void Start()
        {
            try
            {
                _dsp = WebApp.Start<Startup>("localhost:7000");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            if(!ReferenceEquals(_dsp, null))
            {
                _dsp.Dispose();
            }
            Dispose(true);
        }

        public void Dispose(bool dispose)
        {
            GC.Collect();
        }
    }
}
