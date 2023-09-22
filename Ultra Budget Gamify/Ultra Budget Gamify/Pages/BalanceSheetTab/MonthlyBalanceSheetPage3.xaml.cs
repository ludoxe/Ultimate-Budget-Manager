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
    public partial class MonthlyBalanceSheetPage3 : BalanceSheetPageBase
    {
        #region Binding
        public string BindingMonth { get; set; }
        public string BindingYear { get; set; }
        public SortedList<DateTime, DayBudgetReport> MonthBudgetReport = new SortedList<DateTime, DayBudgetReport>();

        #endregion

        #region Constructor

        public MonthlyBalanceSheetPage3()
        {
            InitializePage();
        }

        #endregion

        #region Initialization

        protected override void InitializePage()
        {
            if (SingleInitializeComponentLocker == false) InitializeComponent();
            base.InitializePage();
            SetListView();
            SetDateInformationShow();
            BindingContext = this;
        }

        private void SetListView()
        {
            MonthBudgetReport = SingletonBudgetArray
       .GetSingleBudgetArray().GetMonthlyBudgetReport(DateTime.Now.Date);



            MonthlyBalanceSortedListView.ItemsSource = MonthBudgetReport;



        }

        private void SetDateInformationShow()
        {
            // Configurer la liaison de données pour le label DayOfWeek
            string dayOfWeek = UtilityDate.GetFrenchDayOfWeek(DateTime.Now.Date);
            // Configurer la liaison de données pour le label Date
            string formattedDate = DateTime.Now.Date.ToString("dd/MM/yyyy");

            BindingMonth = DateTime.Now.ToString("MMMM");
            BindingYear = DateTime.Now.ToString("yyyy");
        }

        #endregion

        #region Button Click Event

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToAddBudgetActionPage();
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneMonthBefore();
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneMonthAfter();
        }

        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
        }

        private void NavigateToSamePageOneMonthBefore()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddMonths(-1));
        }
        private void NavigateToSamePageOneMonthAfter()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddMonths(1));
        }

        #endregion
    }
}
