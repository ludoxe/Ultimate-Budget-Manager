using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyBalanceSheetPage1 : ContentPage
    {

        #region Constructor

        public DailyBalanceSheetPage1()
        {
            InitializeComponent();
            SetListView();
            SetDateInformationDisplay();
        }

        #endregion

        #region Initialization


        private void SetListView()
        {
            List<BudgetAction> dayBudgetReportShow = SingletonBudgetArray
       .GetSingleBudgetArray()
       .GetDailyBudgetReport(DateTime.Now.Date)[DateTime.Now.Date]
       .GetBudgetActions;

            dailyBalanceListView.ItemsSource = dayBudgetReportShow;
        }

        private void SetDateInformationDisplay()
        {
            // Configurer la liaison de données pour le label DayOfWeek
            string dayOfWeek = UtilityDate.GetFrenchDayOfWeek(DateTime.Now.Date);
            // Configurer la liaison de données pour le label Date
            string formattedDate = DateTime.Now.Date.ToString("dd/MM/yyyy");

            BindingContext = new
            {
                PeriodText = UtilityDate.GetPeriodText(DateTime.Now.Date),
                DayOfWeek = dayOfWeek,
                Date = formattedDate
            };
        }

        #endregion

        #region Button Click Event

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToAddBudgetActionPage();
        }
        private async void PreviousButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToAddBudgetActionPage();
        }
        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
            //Do something again nigga
        }


        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
        }

        #endregion
    }
}
