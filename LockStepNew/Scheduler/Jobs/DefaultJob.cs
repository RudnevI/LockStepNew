using LockStepNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockStepNew.Scheduler.Jobs
{
    public class DefaultJob
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Start()
        {
            Console.WriteLine("OK");
        }
    }
}