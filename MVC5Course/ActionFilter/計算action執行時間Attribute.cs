using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class 計算action執行時間Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.StartTime = DateTime.Now;
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine("StartTime:" + filterContext.Controller.ViewBag.StartTime);
            Console.WriteLine("NowTime:"+DateTime.Now);
            base.OnActionExecuted(filterContext);
        }
    }
}