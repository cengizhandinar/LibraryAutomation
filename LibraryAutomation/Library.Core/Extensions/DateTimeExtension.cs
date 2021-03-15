using System;

namespace Library.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static string FullDateTimeWithUnderscore(this DateTime dateTime)
        {
            return
                $"{dateTime.Millisecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Month}_{dateTime.Year}";

            /* For Example Return Value

             * CengizhanDinar_465_4_21_12_3_11_2020.png
            
             */
        }
    }
}