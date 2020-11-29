using System;
using System.Globalization;

namespace HackerNews.Domain.Helpers
{
    public static class DateHelper
    {
        public static DateTime ConvertToDateTime(int time)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(time).ToLocalTime();
            return dtDateTime;
        }
    }
}
