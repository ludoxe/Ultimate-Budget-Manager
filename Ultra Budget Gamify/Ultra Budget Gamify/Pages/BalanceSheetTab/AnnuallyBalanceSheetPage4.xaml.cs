using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnnuallyBalanceSheetPage4 : ContentPage
    {
        #region Constructor

        public AnnuallyBalanceSheetPage4()
        {
            InitializeComponent();
            InitializeView();
            SetDateInformationShow();
        }

        #endregion

        #region Initialization

        private void InitializeView()
        {
            SetListView();
        }

        private void SetListView()
        {
            List<BudgetAction> dayBudgetReportShow = SingletonBudgetArray
       .GetSingleBudgetArray()
       .GetDailyBudgetReport(DateTime.Now.Date)[DateTime.Now.Date]
       .GetBudgetActions;

            BalanceListView.ItemsSource = dayBudgetReportShow;
        }

        private void SetDateInformationShow()
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

        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
        }
        private async void PreviousButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
            //Do something
        }
        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
            //Do something again nigga
        }

        #endregion
    }
}