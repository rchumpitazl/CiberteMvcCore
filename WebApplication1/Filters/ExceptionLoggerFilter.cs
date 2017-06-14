using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace Cibertec.Web.Filters
{
    public class ExceptionLoggerFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(context.Exception);
        }
    }
}
