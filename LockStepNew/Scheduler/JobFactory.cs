using Hangfire;
using LockStepNew.Scheduler.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LockStepNew.Scheduler
{
    public class JobFactory

        
    {

        public void ScheduleJob()
        {
            StartJob("DefaultJob", (DefaultJob job) => job.Start(), Cron.Minutely());
        }

        private void StartJob<T>(string jobId, Expression<Action<T>>methodCall, string cronExpression)
        {
            if (methodCall is null)
                throw new ArgumentNullException(nameof(methodCall));
            if (cronExpression is null)
                throw new ArgumentNullException(nameof(cronExpression));

            try
            {
                RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression);
            }
            catch(Exception)
            {

            }
        }

        private void RemoveJobIfExists(string jobId)
        {
            if (jobId is null)
                throw new ArgumentNullException(nameof(jobId));
            try
            {
                RecurringJob.RemoveIfExists(jobId);
            }
            catch(Exception)
            {

            }
        }
    }
}