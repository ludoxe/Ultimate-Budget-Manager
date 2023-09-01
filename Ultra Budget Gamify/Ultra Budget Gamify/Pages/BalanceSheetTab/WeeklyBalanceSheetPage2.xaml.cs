using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Ultra_Budget_Gamify.UtilityDate;
using System.Collections;

namespace Ultra_Budget_Gamify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyBalanceSheetPage2 : ContentPage
    {
        #region Binding

        public string BindingWeekOfMonth { get; set; }

        public string BindingWeekPeriod { get; set; }

        public List<BudgetAction> BudgetActions { get; set; }

        public Dictionary<string, List<BudgetAction>> WeekBudgetActions { get; set; }
        #endregion

        #region Constructor

        public WeeklyBalanceSheetPage2()
        {
            InitializeComponent();
            SetListView();
            SetDateInformationShow();

            BindingContext = this;

        }

        #endregion

        #region Initialization

        private void SetListView()
        {
            SortedList<DateTime, DayBudgetReport> WeekBudgetReportRaw =
            new SortedList<DateTime, DayBudgetReport>(
                SingletonBudgetArray.GetSingleBudgetArray()
                .GetWeeklyBudgetReport(DateTime.Now.Date, UtilityDate.GetWeekOfMonth(DateTime.Now.Date)));
            // Créez une liste ordonnée des jours de la semaine dans l'ordre souhaité



            WeekBudgetActions = new Dictionary<string, List<BudgetAction>>()
            {
                 { "Lundi",  new List<BudgetAction>()},
                 { "Mardi",  new List<BudgetAction>()},
                 { "Mercredi",  new List<BudgetAction>()},
                 { "Jeudi",  new List<BudgetAction>()},
                 { "Vendredi",  new List<BudgetAction>()},
                 { "Samedi",  new List<BudgetAction>()},
                 { "Dimanche",  new List<BudgetAction>()}
            };

            foreach (KeyValuePair<DateTime, DayBudgetReport> kvp in WeekBudgetReportRaw)
            {
                Console.WriteLine(kvp.Key.ToString("dddd"));
                switch (kvp.Key.ToString("dddd"))
                {
                    case "lundi":
                        WeekBudgetActions["Lundi"] = kvp.Value.GetBudgetActions;
                        break;
                    case "mardi":
                        WeekBudgetActions["Mardi"] = kvp.Value.GetBudgetActions;
                        break;
                    case "mercredi":
                        WeekBudgetActions["Mercredi"] = kvp.Value.GetBudgetActions;
                        break;
                    case "jeudi":
                        WeekBudgetActions["Jeudi"] = kvp.Value.GetBudgetActions;
                        break;
                    case "vendredi":
                        WeekBudgetActions["Vendredi"] = kvp.Value.GetBudgetActions;
                        break;
                    case "samedi":
                        WeekBudgetActions["Samedi"] = kvp.Value.GetBudgetActions;
                        break;
                    case "dimanche":
                        WeekBudgetActions["Dimanche"] = kvp.Value.GetBudgetActions;
                        break;
                }

            }
        }

        private void SetDateInformationShow()
        {
            DateTime WeekStart = UtilityDate.GetWeekPeriod(DateTime.Now.Date)[0];
            DateTime WeekEnd = UtilityDate.GetWeekPeriod(DateTime.Now.Date)[1];

            BindingWeekOfMonth = "Semaine " + UtilityDate.GetWeekOfMonth(DateTime.Now.Date);
            BindingWeekPeriod = WeekStart.ToString("dd/MM/yyyy") + " - " + WeekEnd.ToString("dd/MM/yyyy");
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
