using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Areas.Scheduler
{
    public class Tasks : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(Tasks));
        private static readonly object smsLock = new object();//并发锁
        public Tasks()
        {

        }
        /// <summary> 
        /// Called by the <see cref="IScheduler" /> when a
        /// <see cref="ITrigger" /> fires that is associated with
        /// the <see cref="IJob" />.
        /// </summary>
        public virtual void Execute(IJobExecutionContext context)
        {
            try
            {
                lock (smsLock)
                {
                    JobDataMap data = context.JobDetail.JobDataMap;
                    //定时任务携带的参数
                    int jobSays = data.GetInt("wid");
                   
                  //使定时任务结束
                        SchedulerController.Sche(jobSays, 1);
                   
                }

            }
            catch (Exception e)
            {
                //Log4Net.Error(typeof(Tasks), "同步粉丝接口错误:" + e.Message, e);
                SchedulerController.Sche(0, 1);
            }
        }
    }
}