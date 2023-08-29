using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Ultra_Budget_Gamify
{
    public class DayBudgetReport
    {
        private List<BudgetAction> BudgetActions = new List<BudgetAction>();
        private DateTime ReportDate ;

        private void SortBudgetActions()
        {
            BudgetActions.Sort((action1,action2) => action1.GetId().CompareTo(action2.GetId()));
            foreach(BudgetAction action in BudgetActions)
            {
                action.SetId(BudgetActions.IndexOf(action));
            }
        }

        public DayBudgetReport(List<BudgetAction> actions) 
        {
            BudgetActions = actions;
        }
        public DayBudgetReport()
        {
            BudgetActions = new List<BudgetAction>();
        }

        #region Public Get

        public List<BudgetAction> GetBudgetActions
        {
            get
            {
                SortBudgetActions();
                return BudgetActions;
            }
        }
        public DateTime GetReportDate() 
        { return ReportDate; }

        #endregion

        #region Public commands
        public void AddBudgetAction(BudgetAction budgetAction)
        {
            BudgetActions.Add(budgetAction);
            budgetAction.SetId(BudgetActions.IndexOf(budgetAction) +1);
        }
        // Houlàlà
        public void RemoveBudgetAction(BudgetAction budgetAction)
        {
            BudgetActions.Remove(budgetAction);
        }
        public void ClearBudgetAction(BudgetAction budgetAction)
        {
            BudgetActions.Clear();
        }
        public void EditBudgetAction(BudgetAction oldBudgetAction, BudgetAction NewBudgetAction)
        {

            BudgetAction OldBudgetAction = BudgetActions.Find(p => p.GetId() == oldBudgetAction.GetId()) ;
            NewBudgetAction.SetId(OldBudgetAction.GetId()) ;

            BudgetActions.Remove(oldBudgetAction) ;
            BudgetActions.Add(NewBudgetAction) ;
            SortBudgetActions() ;

        }

        #endregion



    }
}
