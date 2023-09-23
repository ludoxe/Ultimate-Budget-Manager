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
        private string _bindingYear;
        public string BindingYear
        {
            get => _bindingYear;
            set
            {
                _bindingYear = value;
                OnPropertyChanged(nameof(BindingYear));
            }
        }
        private string _bindingMonth;
        public string BindingMonth {
            get => _bindingMonth;
            set
            {
                _bindingMonth = value;
                OnPropertyChanged(nameof(BindingMonth));
            }
        }
        public SortedList<DateTime, DayBudgetReport> MonthBudgetReport = new SortedList<DateTime, DayBudgetReport>();

        #endregion

        #region Constructor

        public MonthlyBalanceSheetPage3()
        {
            InitializePage();
        }
        public MonthlyBalanceSheetPage3(CarouselPage Carousel, DateTime Date)
        {
            this.Parent = Carousel;
            SetSingletonGlobalPageState(Date);
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
       .GetSingleBudgetArray().GetMonthlyBudgetReport(DatePagePropreties);



            MonthlyBalanceSortedListView.ItemsSource = MonthBudgetReport;



        }

        private void SetDateInformationShow()
        {
            BindingMonth = DatePagePropreties.ToString("MMMM");
            BindingYear = DatePagePropreties.ToString("yyyy");

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
