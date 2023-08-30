using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Xamarin.Forms;

namespace Ultra_Budget_Gamify
{
    public class BudgetArray
    {
        private SortedList<DateTime, DayBudgetReport> BudgetSortedList = new SortedList<DateTime, DayBudgetReport>();
        private DateTime StartDate;
        private DateTime EndDate;

        #region Constructeur

        public BudgetArray()
        {
            BudgetSortedList = new SortedList<DateTime, DayBudgetReport>();
        }
        public BudgetArray(BudgetArray NewBudgetArray)
        {
            BudgetSortedList = new SortedList<DateTime, DayBudgetReport>(NewBudgetArray.GetBudgetSortedList);
        }
        public BudgetArray(DateTime StartDate, DateTime EndDate)
        {
            BudgetSortedList = new SortedList<DateTime, DayBudgetReport>();


            for (DateTime i = StartDate.Date; i <= EndDate.Date; i = i.AddDays(1))
            {
                BudgetSortedList.Add(i.Date, new DayBudgetReport());
            }

            return;
        }
        #endregion

        #region public Get

        public DateTime GetStartDate => StartDate;
        public DateTime GetEndDate => EndDate;
        public SortedList<DateTime, DayBudgetReport> GetBudgetSortedList =>
            new SortedList<DateTime, DayBudgetReport>(BudgetSortedList);
        public SortedList<DateTime, DayBudgetReport> GetDailyBudgetReport(DateTime Day)
        {
            return new SortedList<DateTime, DayBudgetReport>()
            {
                { Day, BudgetSortedList[Day] }
            };
        }
        public SortedList<DateTime, DayBudgetReport> GetWeeklyBudgetReport(DateTime Date, int weekNumber)
        {



            // Trouver le premier jour du mois
            DateTime firstDayOfMonth = new DateTime(Date.Year, Date.Month, 1);

            // Trouver le premier jour de la semaine spécifiée (lundi)
            DateTime firstDayOfWeek = UtilityDate.GetFirstDayOfWeek(Date);

            // Trouver le dernier jour de la semaine spécifiée
            DateTime lastDayOfWeek = UtilityDate.GetLastDayOfWeek(Date);

            // Trouver le dernier jour du mois
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            DateTime DayBudgetReportDate;

            SortedList<DateTime, DayBudgetReport> result = new SortedList<DateTime, DayBudgetReport>();
            // Ajouter les DayBudgetReport pour chaque jour de la semaine
            foreach (KeyValuePair<DateTime, DayBudgetReport> kvp in BudgetSortedList)
            {

                DayBudgetReportDate = kvp.Key.Date;
      
                if (DayBudgetReportDate >= firstDayOfWeek && DayBudgetReportDate <= lastDayOfWeek
                    && DayBudgetReportDate.Month == Date.Month)
                {
                    result.Add(kvp.Key, kvp.Value);
                }
                else if (DayBudgetReportDate > lastDayOfWeek)
                {
                    break; // On arrête dès qu'on dépasse la semaine
                }
            }

            return result;
        }
        public SortedList<DateTime, DayBudgetReport> GetMonthlyBudgetReport(DateTime Date)
        {
            DateTime startOfMonth = new DateTime(Date.Year, Date.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            SortedList<DateTime, DayBudgetReport> result = new SortedList<DateTime, DayBudgetReport>();
            foreach (KeyValuePair<DateTime, DayBudgetReport> kvp in BudgetSortedList)
            {
                if (kvp.Key >= startOfMonth && kvp.Key <= endOfMonth)
                {
                    result.Add(kvp.Key.Date, kvp.Value);
                    
                }
            }
            Console.WriteLine("end Of Month " + endOfMonth);
            return result;
        }
        #endregion

        #region public Set

        public DateTime SetStartDate { set => StartDate = value; }
        public DateTime SetEndDate { set => EndDate = value; }
        #endregion
    }
}

