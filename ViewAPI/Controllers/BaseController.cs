using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request["password"] != Configs.ApiPassword)
            {
                filterContext.Result = new HttpStatusCodeResult(403);
            }
        }
    }
}