using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetailStore.CommonLibrary; 

namespace RetailStore.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {
            
            if (typeof(System.Web.HttpRequestValidationException).IsInstanceOfType(filterContext.Exception))
            {
                Response.Redirect("~/Error/Error500");
                return;
            }

            if (Request.IsAjaxRequest())
            {
                LogException(filterContext.Exception);
            }
            else
            {
                LogException(filterContext.Exception);
                // Redirect to customer support page or error page or try again later (message here).
                filterContext.ExceptionHandled = true;
                this.View("Error").ExecuteResult(this.ControllerContext);
            }


            base.OnException(filterContext);
        }

        protected void LogException(Exception ex)
        {
            string message = "";
            Exception inner = ex.InnerException;
            while (inner != null)
            {
                message = message + "\r\n" + inner.Message;
                inner = inner.InnerException;
            }

            AppExceptionHandling.LogException("RetailStore UI Layer", ex);
        }
    }
}
