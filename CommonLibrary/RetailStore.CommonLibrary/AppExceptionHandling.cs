using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.CommonLibrary
{
    public static class AppExceptionHandling
    {

        public static void LogException(string customMessage, Exception ex)
        {
            AppLog.LogError(customMessage, ex.Message, ex);
        }

    }
}
