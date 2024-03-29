﻿using System.Globalization;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBudgetActionPage : CustomBaseContentPage
    {
        public AddBudgetActionPage()
        {
            DatePagePropreties = DateTime.Now;
            Initialize();
        }
        public AddBudgetActionPage(DateTime Date)
        {
            DatePagePropreties = Date;
            Initialize();
        }

            #region Initialization

        private void Initialize()
        {
            InitializeComponent();
            InitializeView();
        }

            private void InitializeView()
        {
            DateTime currentDate = DatePagePropreties;
            string periodText = UtilityDate.GetPeriodText(currentDate);
            string dayOfWeek = UtilityDate.GetFrenchDayOfWeek(currentDate);
            string dateFormatted = currentDate.ToString("dd/MM/yyyy");

            BindingContext = new
            {
                PeriodText = periodText,
                DayOfWeek = dayOfWeek,
                DateFormatted = dateFormatted
            };
        }

        #endregion


        #region Button Click Event

        private async void ValidateButton_Clicked(object sender, EventArgs e)
        {
            string action = actionEntry.Text;
            float gain = float.TryParse(gainEntry.Text, out float gainValue) ? gainValue : 0;
            float loss = float.TryParse(lossEntry.Text, out float lossValue) ? lossValue : 0;

            var newAction = new BudgetAction(action, gain, loss);

            AddActionToBudget(newAction);

            await NavigateToBalanceSheetPage();
        }

        #endregion

        #region Action Handling

        private void AddActionToBudget(BudgetAction newAction)
        {
            var currentDate = DatePagePropreties;
            var dailyBudgetReport =
                SingletonBudgetArray.GetSingleBudgetArray().GetDailyBudgetReport(currentDate)[currentDate];

            dailyBudgetReport.AddBudgetAction(newAction);
        }

        #endregion

        #region Navigation

        private async Task NavigateToBalanceSheetPage()
        {
            await Navigation.PushAsync(new BalanceSheetTabPage());
        }

        #endregion
    }
}
