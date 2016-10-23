using RetailStore.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace RetailStore.WebAPI.Common
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void HandleCore(ExceptionHandlerContext context)
        {
            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = context.Exception.Message// "Oops! Sorry! Something went wrong, We'll take care of it"
            };
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }


    public class ExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleAsync(ExceptionHandlerContext context,
                                        CancellationToken cancellationToken)
        {
            if (!ShouldHandle(context))
            {
                return Task.FromResult(0);
            }

            return HandleAsyncCore(context, cancellationToken);
        }

        public virtual Task HandleAsyncCore(ExceptionHandlerContext context,
                                           CancellationToken cancellationToken)
        {
            HandleCore(context);
            return Task.FromResult(0);
        }

        public virtual void HandleCore(ExceptionHandlerContext context)
        {
        }

        public virtual bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }

    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            try
            {
                //Log to the DB or email or log file
                AppExceptionHandling.LogException("Retail Store Web API",context.Exception);
            }
            catch (Exception ex)
            {
                LogMessage("Message: " + ex.Message + "Inner Exception: " + ex.InnerException);
            }
        }

        private const String LogInvalidateCache = "LogInvalidateCachePath";
        private String _logInvalidateCachePath;
        private String LogInvalidateCachePath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_logInvalidateCachePath) && ConfigurationManager.AppSettings[LogInvalidateCache] != null)
                    _logInvalidateCachePath = ConfigurationManager.AppSettings[LogInvalidateCache].ToString();

                return _logInvalidateCachePath;
            }
        }

        public void LogMessage(string message)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(LogInvalidateCachePath))
                {
                    using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(LogInvalidateCachePath, true))
                    {
                        file.WriteLine(message);
                    }
                }
            }
            catch { }
        }

    }
}
