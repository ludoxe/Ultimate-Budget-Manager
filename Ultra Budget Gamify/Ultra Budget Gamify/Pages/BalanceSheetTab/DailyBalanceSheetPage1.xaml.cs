using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyBalanceSheetPage1 : CustomBaseContentPage
    {
        #region Constructor

        public DailyBalanceSheetPage1()
        {
            DatePagePropreties = DateTime.Now;
            InitializePage();
        }
        public DailyBalanceSheetPage1(DateTime Date)
        {
            DatePagePropreties = Date;
            InitializePage();

        }

        #endregion

        #region Initialization

        private void InitializePage()
        {
            InitializeComponent();
            SetListView();
            SetDateInformationDisplay();
        }
        private void SetListView()
        {
            List<BudgetAction> dayBudgetReportShow = SingletonBudgetArray
       .GetSingleBudgetArray()
       .GetDailyBudgetReport(DatePagePropreties)[DatePagePropreties]
       .GetBudgetActions;

            dailyBalanceListView.ItemsSource = dayBudgetReportShow;
        }

        private void SetDateInformationDisplay()
        {
            // Configurer la liaison de données pour le label DayOfWeek
            string dayOfWeek = UtilityDate.GetFrenchDayOfWeek(DatePagePropreties);
            // Configurer la liaison de données pour le label Date
            string formattedDate = DatePagePropreties.ToString("dd/MM/yyyy");

            BindingContext = new
            {
                PeriodText = UtilityDate.GetPeriodText(DatePagePropreties),
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
            await NavigateToSamePageOneDayBefore();
        }
        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToSamePageOneDayAfter();
        }


        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage(DatePagePropreties));
        }

        private async Task NavigateToSamePageOneDayBefore()
        {
            
            await Navigation.PushAsync(new DailyBalanceSheetPage1(DatePagePropreties.AddDays(-1)));
        }
        private async Task NavigateToSamePageOneDayAfter()
        {
            await Navigation.PushAsync(new DailyBalanceSheetPage1(DatePagePropreties.AddDays(1)));
        }
        #endregion


    }
}
