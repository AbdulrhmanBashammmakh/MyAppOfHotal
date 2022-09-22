using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyAppOfHotal.App_Start
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult Index()
        {
            return View();
        }
/*
        public async Task<ActionResult>   RunSchedulerMethod1()
        {
           return await View();
        }
*/
        public  void RunSchedulerMethod()
        {
              Console.WriteLine("Recurring!");
        }
    }
}