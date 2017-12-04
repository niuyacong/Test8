using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.Scheduler
{
    public class SchedulerController : Controller
    {
        //
        // GET: /Scheduler/Scheduler/

        public ActionResult Index()
        {
            return View();
        }
        public static void Sche(int id, int flag)
        {
            try
            {
                //定时任务也可以放在Global.axas中
                ISchedulerFactory sf = new StdSchedulerFactory();
                IScheduler sched = sf.GetScheduler();
                DateTimeOffset runTime = DateBuilder.EvenMinuteDateAfterNow();//.EvenMinuteDate(DateTimeOffset.UtcNow);

                //短信
                IJobDetail job = JobBuilder.Create<Tasks>()
                    .WithIdentity("smsjob" + id, "smsgroup1" + id)
                    .UsingJobData("wid", id)
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule(
                    a => a.WithIntervalInSeconds(30).Build()
                    )
                    .WithIdentity("trigger1" + id, "smsgroup1" + id)
                    .StartAt(runTime)
                    .Build();

                if (flag == 0)
                {
                    sched.ScheduleJob(job, trigger);
                    sched.Start();
                }
                else
                {

                    sched.Shutdown();
                }
            }
            catch (Exception ex)
            {
                //Log4Net.Error("report error:" + ex.ToString());
            }
        }
    }
}
