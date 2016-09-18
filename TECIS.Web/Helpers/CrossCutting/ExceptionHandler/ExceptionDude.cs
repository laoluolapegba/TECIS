/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 � 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using System;
using TECIS.Helpers.CrossCutting.Logging;
namespace TECIS.Helpers.CrossCutting.ExceptionHandler
{
    public static class ExceptionDude
    {
        public static string FormatMessage(Exception ex, bool log = true)
        {
            if (log)
                Logger.LogError(ex);

            string message = "Error: There was a problem while processing your request: " + ex.Message;

            if (ex.InnerException != null)
            {
                Exception inner = ex.InnerException;
                if (inner is System.Data.Common.DbException)
                    message = "Our database is currently experiencing problems. " + inner.Message;
                else if (inner is NullReferenceException)
                    message = "There are one or more required fields that are missing.";
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    message = string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    message = "Exception in application" + inner.Message;
                else
                    message = inner.Message;

            }

            return message;
        }
    }
}