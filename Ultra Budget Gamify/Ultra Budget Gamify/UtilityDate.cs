using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ultra_Budget_Gamify
{
    public static class UtilityDate
    {
        #region Methods
        public static string GetPeriodText(DateTime currentDate)
        {
            if (currentDate == DateTime.Now.Date)
                return "d'aujourd'hui";
            else if (currentDate == DateTime.Now.Date.AddDays(-1))
                return "d'hier";
            else if (currentDate < DateTime.Now.Date)
                return "d'avant";
            else
                return "du futur";
        }
        public static string GetFrenchDayOfWeek(DateTime date)
        {
            CultureInfo frenchCulture = new CultureInfo("fr-FR");
            return frenchCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }
        public static int GetWeekOfMonth(DateTime date)
        {
            int daysInWeek = 7;
            int firstWeekDayOfMonth = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek;

            int weekNumber = (date.Day + firstWeekDayOfMonth - 1) / daysInWeek ;

            return weekNumber;
        }
        public static DateTime GetFirstDayOfWeek(DateTime Date)
        {
            DateTime FirstDayOfWeek = Date;
            while (FirstDayOfWeek.ToString("dddd") != "lundi" && FirstDayOfWeek.ToString("dddd") != "monday")
            {
                Console.WriteLine(FirstDayOfWeek.ToString("dddd"));
                Console.WriteLine(FirstDayOfWeek);
                FirstDayOfWeek = FirstDayOfWeek.AddDays(-1);
            }
            return FirstDayOfWeek.Date;
        }
        public static DateTime GetLastDayOfWeek(DateTime Date)
        {
            DateTime LastDayOfWeek = Date;
            while (LastDayOfWeek.ToString("dddd") != "dimanche" && LastDayOfWeek.ToString("dddd") != "sunday")
            {
                LastDayOfWeek = LastDayOfWeek.AddDays(1);
            }
            return LastDayOfWeek.Date;
        }

        public static DateTime[] GetWeekPeriod(DateTime date)
        {
            DateTime firstDayOfWeek = GetFirstDayOfWeek(date);
            DateTime lastDayOfWeek = GetLastDayOfWeek(date);

            return new DateTime[] { firstDayOfWeek, lastDayOfWeek };
        }
        #endregion

        #region Enums
        public enum DayName
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        #endregion

    }
}
