using System;

namespace TECIS.Web.Helpers.UI
{
    public class DateHelper
    {
        const int SECOND = 1;
        const int MINUTE = 60 * SECOND;
        const int HOUR = 60 * MINUTE;
        const int DAY = 24 * HOUR;
        const int MONTH = 30 * DAY;
        /// <summary>
        /// Gets human readable time elapsed between two dates
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static string TimeElapsed(DateTime from)
        {
            TimeSpan ts = DateTime.Now - from;
            if (ts.TotalMinutes < 1)//seconds ago
                return "just now";
            if (ts.TotalHours < 1)//min ago
                return (int)ts.TotalMinutes == 1 ? "1 Minute ago" : (int)ts.TotalMinutes + " Minutes ago";
            if (ts.TotalDays < 1)//hours ago
                return (int)ts.TotalHours == 1 ? "1 Hour ago" : (int)ts.TotalHours + " Hours ago";
            if (ts.TotalDays < 7)//days ago
                return (int)ts.TotalDays == 1 ? "1 Day ago" : (int)ts.TotalDays + " Days ago";
            if (ts.TotalDays < 30.4368)//weeks ago
                return (int)(ts.TotalDays / 7) == 1 ? "1 Week ago" : (int)(ts.TotalDays / 7) + " Weeks ago";
            if (ts.TotalDays < 365.242)//months ago
                return (int)(ts.TotalDays / 30.4368) == 1 ? "1 Month ago" : (int)(ts.TotalDays / 30.4368) + " Months ago";
            //years ago
            return (int)(ts.TotalDays / 365.242) == 1 ? "1 Year ago" : (int)(ts.TotalDays / 365.242) + " Years ago";


            //var ts = new TimeSpan(DateTime.UtcNow.Ticks - from.Ticks);
            //double delta = Math.Abs(ts.TotalSeconds);

            //if (delta < 1 * MINUTE)
            //{
            //    return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            //}
            //if (delta < 2 * MINUTE)
            //{
            //    return "a minute ago";
            //}
            //if (delta < 45 * MINUTE)
            //{
            //    return ts.Minutes + " minutes ago";
            //}
            //if (delta < 90 * MINUTE)
            //{
            //    return "an hour ago";
            //}
            //if (delta < 24 * HOUR)
            //{
            //    return ts.Hours + " hours ago";
            //}
            //if (delta < 48 * HOUR)
            //{
            //    return "yesterday";
            //}
            //if (delta < 30 * DAY)
            //{
            //    return ts.Days + " days ago";
            //}
            //if (delta < 12 * MONTH)
            //{
            //    int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
            //    return months <= 1 ? "one month ago" : months + " months ago";
            //}
            //else
            //{
            //    int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            //    return years <= 1 ? "one year ago" : years + " years ago";
            //}

        }
    }
}