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
    public partial class AnnuallyBalanceSheetPage4 : BalanceSheetPageBase
    {
        #region Binding
        public SortedList<DateTime, DayBudgetReport> BudgetReportShow { get; set; }
        public string BindingBudgetPeriod { get; set; }

        #endregion
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
            if (SingleInitializeComponentLocker == false) InitializeComponent();
            base.InitializePage();
            SetListView();
            SetDateInformationShow();
            BindingContext = this;
        }

        private void SetListView()
        {
            BudgetReportShow = SingletonBudgetArray
       .GetSingleBudgetArray().GetBudgetSortedList;

            
        }

        private void SetDateInformationShow()
        {
            // Configurer la liaison de données pour le label Date
            string StartDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string EndDate = DateTime.Now.Date.ToString("dd/MM/yyyy");

            BindingBudgetPeriod = StartDate + " - " + EndDate;


        }

        #endregion

        #region Button Click Event

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToAddBudgetActionPage();
        }
        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneYearBefore();
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneYearAfter();
        }
        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
        }
        private void NavigateToSamePageOneYearBefore()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddYears(-1));
        }
        private void NavigateToSamePageOneYearAfter()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddYears(1));
        }

        #endregion
    }
}