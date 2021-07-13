using LockStep.Library.Domain.Finance;
using LockStepNew.Models;
using LockStepNew.Scheduler.Services;
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
            List<Payment> unprocessedPayments = context.Payments.Include("Book").Where(p => p.Status == 0).ToList();

            EmailServicePayments service = new EmailServicePayments();

            unprocessedPayments.ForEach(p => {

                p.Status = 1;
                context.SaveChanges();
                service.Send(p.Email, $"Ваш заказ №{p.Id}", p.Book.Name);
                
            });

            

            Console.WriteLine("OK");
        }
    }
}