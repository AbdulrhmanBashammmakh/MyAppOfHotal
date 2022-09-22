using Hangfire;
using Hangfire.SqlServer;
using MyAppOfHotal.App_Start;
using Owin;
using Microsoft.Owin.Host.SystemWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;

namespace MyAppOfHotal
{
    public class MvcApplication : System.Web.HttpApplication
    { 
        
        /*
        private IEnumerable<IDisposable> GetHangfireServers()
        {
           
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=.\\SQLEXPRESS; Database=HangfireTest; Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });

            yield return new BackgroundJobServer();
        }
            */
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



   //        HangfireAspNet.Use(GetHangfireServers);

            // Let's also create a sample background job
  //          BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));


        }
        public void Configuration(IAppBuilder app)
        {
   //         app.UseHangfireDashboard();
     //       app.UseHangfireServer();
        }
    }
}
/*
           GlobalConfiguration.Configuration.UseSqlServerStorage("al_hotalEntities");
           

JobStorage.Current = new SqlServerStorage("metadata=res://*/
//Models.Hotal.csdl | res://*/Models.Hotal.ssdl|res://*/Models.Hotal.msl");
/*
            SchedulerController obSchedulerController = new SchedulerController();
RecurringJob.AddOrUpdate(() => obSchedulerController.RunSchedulerMethod(), Cron.Minutely);
*/