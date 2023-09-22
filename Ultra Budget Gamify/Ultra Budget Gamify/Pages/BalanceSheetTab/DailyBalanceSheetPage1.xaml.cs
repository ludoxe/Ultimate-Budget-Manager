using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyBalanceSheetPage1 : BalanceSheetPageBase
    {
        #region Constructor

        public DailyBalanceSheetPage1()
        {
            InitializePage();
        }
        public DailyBalanceSheetPage1(DateTime Date)
        {
            SetSingletonGlobalPageState(Date);
            InitializePage();
        }
        public DailyBalanceSheetPage1(CarouselPage Carousel, DateTime Date)
        {
            this.Parent = Carousel;
            SetSingletonGlobalPageState(Date);
            InitializePage();
        }
        #endregion

        #region Initialization

        protected override void InitializePage()
        {
            if(SingleInitializeComponentLocker == false) InitializeComponent();
            base.InitializePage();
            SetListView();
            SetDateInformationDisplay();
        }

        private void SetListView()
        {
            List<BudgetAction> dayBudgetReportShow = SingletonBudgetArray
                   .GetSingleBudgetArray().
                   GetDailyBudgetReport(DatePagePropreties)[DatePagePropreties]
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
        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneDayBefore();
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneDayAfter();
        }


        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage(DatePagePropreties));
        }


        private void NavigateToSamePageOneDayBefore()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddDays(-1));
        }
        private void NavigateToSamePageOneDayAfter()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddDays(1));
        }
        #endregion


    }
}

