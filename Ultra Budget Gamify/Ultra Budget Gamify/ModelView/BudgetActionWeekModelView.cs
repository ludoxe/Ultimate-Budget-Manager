using System;
using System.Collections.Generic;
using System.Text;

namespace Ultra_Budget_Gamify
{
    public class BudgetActionWeekModelView
    {
        public string DayName { get; set; }
        public SortedList<string, BudgetAction> BudgetActions { get; set; }
        


    }
}
