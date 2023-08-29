using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ultra_Budget_Gamify
{
    public partial class SettingsBudgetPage : ContentPage
    {
        public SettingsBudgetPage()
        {
            InitializeComponent();
        }

        private async void ValidateButton_Clicked(object sender, EventArgs e)
        {
            DateTime ChoosenStartDate = startDatePicker.Date;
            DateTime ChoosenEndDate = endDatePicker.Date;

            SingletonBudgetArray.SetSingleBudgetArray(new BudgetArray(ChoosenStartDate, ChoosenEndDate)) ;

            // Retour à la page d'principale
            await Navigation.PushAsync(new BalanceSheetTabPage());
        }
    }
}