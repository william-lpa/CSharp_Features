using CSharp_5.Caller_Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintaxFeatures
{
    class ExceptionFilters
    {
        public ExceptionFilters()
        {
            HandleExceptionBeforeExceptionFilters();
            HandleExceptionAfterExceptionFilters();
        }

        public static string HandleExceptionBeforeExceptionFilters()
        {
            try
            {
                var streamTask = new System.Net.Http.HttpClient().GetStringAsync("https://localHost:10000");
                var responseText = streamTask.Result;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                if (e.Message.Contains("301"))
                    return "Site Moved";
                if (e.Message.Contains("400"))
                    return "Bad Request";
                if (e.Message.Contains("500"))
                    return "Internal Server Error";
                return "";
            }
            catch (Exception e)
            {
                Log.Instance.AddEntry(LogEntry.CreateNew(e.Message, SeverityLevel.Error));
                return null;
            }
        }
        public static async Task<string> HandleExceptionAfterExceptionFilters()
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("400"))
            {
                return "Bad Request";
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("500"))
            {
                return "Internal Server Error";
            }
            catch (Exception e)
            {
                Log.Instance.AddEntry(LogEntry.CreateNew(e.Message, SeverityLevel.Error));
                return null;
            }
        }
    }
}
