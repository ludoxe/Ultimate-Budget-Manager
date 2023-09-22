using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Ultra_Budget_Gamify.UtilityDate;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyBalanceSheetPage2 : BalanceSheetPageBase
    {
        #region Binding
        private List<BudgetActionWeekModelView> _budgetActionWeekListView;
        public List<BudgetActionWeekModelView> BudgetActionWeekListView
        {
            get => _budgetActionWeekListView;
            set
            {
                _budgetActionWeekListView = value;
                OnPropertyChanged(nameof(BudgetActionWeekListView));
            }
        }
        private string _actionName;
        public string ActionName
        {
            get => _actionName;
            set
            {
                _actionName = value;
                OnPropertyChanged(nameof(ActionName));
            }
        }
        private string _actionGain;
        public string ActionGain
        {
            get => _actionGain;
            set
            {
                _actionGain = value;
                OnPropertyChanged(nameof(ActionGain));
            }
        }
        private string _actionLoss;
        public string ActionLoss
        {
            get => _actionLoss;
            set
            {
                _actionLoss = value;
                OnPropertyChanged(nameof(ActionLoss));
            }
        }

        private string _weekOfMonth;
        public string WeekOfMonth
        {
            get => _weekOfMonth;
            set
            {
                _weekOfMonth = value;
                OnPropertyChanged(nameof(WeekOfMonth));
            }
        }

        private string _weekPeriod;
        public string WeekPeriod
        {
            get => _weekPeriod;
            set
            {
                _weekPeriod = value;
                OnPropertyChanged(nameof(WeekPeriod));
            }
        }

        private string _dayName;
        public string DayName
        {
            get => _dayName;
            set
            {
                _dayName = value;
                OnPropertyChanged(nameof(DayName));
            }
        }

        private List<BudgetAction> _budgetActions;
        public List<BudgetAction> BudgetActions
        {
            get => _budgetActions;
            set
            {
                _budgetActions = value;
                OnPropertyChanged(nameof(BudgetActions));
            }
        }

        private string _getActionName;
        public string GetActionName
        {
            get => _getActionName;
            set
            {
                _getActionName = value;
                OnPropertyChanged(nameof(GetActionName));
            }
        }

        private string _getActionGain;
        public string GetActionGain
        {
            get => _getActionGain;
            set
            {
                _getActionGain = value;
                OnPropertyChanged(nameof(GetActionGain));
            }
        }

        private string _getActionLoss;
        public string GetActionLoss
        {
            get => _getActionLoss;
            set
            {
                _getActionLoss = value;
                OnPropertyChanged(nameof(GetActionLoss));
            }
        }

        private List<BudgetAction> _mondayBudgetActions;
        public List<BudgetAction> MondayBudgetActions
        {
            get { return _mondayBudgetActions; }
            set
            {
                _mondayBudgetActions = value;
                OnPropertyChanged(nameof(MondayBudgetActions));
            }
        }
        private List<BudgetAction> _tuesdayBudgetActions;
        public List<BudgetAction> TuesdayBudgetActions
        {
            get { return _tuesdayBudgetActions; }
            set
            {
                _tuesdayBudgetActions = value;
                OnPropertyChanged(nameof(TuesdayBudgetActions));
            }
        }
        private List<BudgetAction> _wednesdayBudgetActions;
        public List<BudgetAction> WednesdayBudgetActions
        {
            get { return _wednesdayBudgetActions; }
            set
            {
                _wednesdayBudgetActions = value;
                OnPropertyChanged(nameof(WednesdayBudgetActions));
            }
        }
        private List<BudgetAction> _thursdayBudgetActions;
        public List<BudgetAction> ThursdayBudgetActions
        {
            get { return _thursdayBudgetActions; }
            set
            {
                _thursdayBudgetActions = value;
                OnPropertyChanged(nameof(ThursdayBudgetActions));
            }
        }
        private List<BudgetAction> _fridayBudgetActions;
        public List<BudgetAction> FridayBudgetActions
        {
            get { return _fridayBudgetActions; }
            set
            {
                _fridayBudgetActions = value;
                OnPropertyChanged(nameof(FridayBudgetActions));
            }
        }
        private List<BudgetAction> _saturdayBudgetActions;
        public List<BudgetAction> SaturdayBudgetActions
        {
            get { return _saturdayBudgetActions; }
            set
            {
                _saturdayBudgetActions = value;
                OnPropertyChanged(nameof(SaturdayBudgetActions));
            }
        }
        private List<BudgetAction> _sundayBudgetActions;
        public List<BudgetAction> SundayBudgetActions
        {
            get { return _sundayBudgetActions; }
            set
            {
                _sundayBudgetActions = value;
                OnPropertyChanged(nameof(SundayBudgetActions));
            }
        }

        #endregion

        #region Constructor

        public WeeklyBalanceSheetPage2()
        {       
            InitializePage();
        }

        #endregion

        #region Initialization

        protected override void InitializePage()
        {
            if(SingleInitializeComponentLocker == false) InitializeComponent();
            base.InitializePage();
            SetListView();
            SetDateInformationShow();
            BindingContext = this;
        }
        private void SetListView()
        {
            SortedList<DateTime, DayBudgetReport> WeekBudgetReportRaw =
            new SortedList<DateTime, DayBudgetReport>(
                SingletonBudgetArray.GetSingleBudgetArray()
                .GetWeeklyBudgetReport(DatePagePropreties, UtilityDate.GetWeekOfMonth(DatePagePropreties)));

            List<BudgetActionWeekModelView> BudgetActionWeekListView = new List<BudgetActionWeekModelView>();

            MondayBudgetActions = new List<BudgetAction>();
            TuesdayBudgetActions = new List<BudgetAction>();
            WednesdayBudgetActions = new List<BudgetAction>();
            ThursdayBudgetActions = new List<BudgetAction>();
            FridayBudgetActions = new List<BudgetAction>();
            SaturdayBudgetActions = new List<BudgetAction>();
            SundayBudgetActions = new List<BudgetAction>();

            foreach (KeyValuePair<DateTime, DayBudgetReport> kvp in WeekBudgetReportRaw)
            {
                Console.WriteLine(kvp.Key.ToString("dddd"));
                switch (kvp.Key.ToString("dddd"))
                {
                    case "lundi":
                        MondayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                    case "mardi":
                        TuesdayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                    case "mercredi":
                        WednesdayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                    case "jeudi":
                        ThursdayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                    case "vendredi":
                        FridayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                    case "samedi":
                        SaturdayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                    case "dimanche":
                        SundayBudgetActions = new List<BudgetAction>(kvp.Value.GetBudgetActions);
                        break;
                }

            }
        }

        private void SetDateInformationShow()
        {
            DateTime WeekStart = UtilityDate.GetWeekPeriod(DatePagePropreties)[0];
            DateTime WeekEnd = UtilityDate.GetWeekPeriod(DatePagePropreties)[1];

            WeekOfMonth = "Semaine " + UtilityDate.GetWeekOfMonth(DatePagePropreties);
            WeekPeriod = WeekStart.ToString("dd/MM/yyyy") + " - " + WeekEnd.ToString("dd/MM/yyyy");



        }

        #endregion

        #region Button Click Event

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToAddBudgetActionPage();
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneWeekBefore();
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            NavigateToSamePageOneWeekAfter();
        }

        #endregion

        #region Navigation

        private async Task NavigateToAddBudgetActionPage()
        {
            await Navigation.PushAsync(new AddBudgetActionPage());
        }

        private void NavigateToSamePageOneWeekBefore()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddDays(-7));
        }
        private void NavigateToSamePageOneWeekAfter()
        {
            NavigateToSamePageOnDate(DatePagePropreties.AddDays(7));
        }
        #endregion
    }
}
