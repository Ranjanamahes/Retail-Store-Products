using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.CommonLibrary
{
   public static class AppLog
    {
       private static readonly Object thisLock = new object();
       public static void LogError(string appSource, string message, Exception exception)
       {
           if (!Directory.Exists(AppConfig.ErrorLogPath))
           {
               Directory.CreateDirectory(AppConfig.ErrorLogPath);
           }

           string filePath = AppConfig.ErrorLogPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + AppConfig.ErrorLogFile;

           lock (thisLock)
           {
               var fileWriter = new StreamWriter(filePath, true);

               if (!string.IsNullOrEmpty(appSource))
               {
                   fileWriter.WriteLine(string.Format("Source: {0}", appSource));
               }

               fileWriter.WriteLine(DateTime.Now);

               if (!string.IsNullOrEmpty(message))
               {
                   fileWriter.WriteLine(message);
               }

               if (exception != null)
               {
                   fileWriter.WriteLine(exception.Source);
                   fileWriter.WriteLine(exception.Message);
                   fileWriter.WriteLine(exception.StackTrace);
               }

               fileWriter.WriteLine("=============================================");
               fileWriter.Flush();
               fileWriter.Close();
           }
       }
    }
}
