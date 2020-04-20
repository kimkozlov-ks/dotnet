using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CheckScheduler
    { 
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Checker>().Build();

            ITrigger trigger = TriggerBuilder.Create()  
                .WithIdentity("trigger1", "group1")    
                .StartNow()                            
                .WithSimpleSchedule(x => x           
                    .WithIntervalInMinutes(1)        
                    .RepeatForever())                  
                .Build();                              

            await scheduler.ScheduleJob(job, trigger);      
        }
    }
}
