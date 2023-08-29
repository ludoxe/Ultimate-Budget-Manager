using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ultra_Budget_Gamify
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        public async void OnStartPageButtonClicked(object sender, EventArgs e)
        {
            if(SingletonBudgetArray.GetSingleBudgetArray().GetStartDate == DateTime.MinValue
                || SingletonBudgetArray.GetSingleBudgetArray().GetStartDate == DateTime.MaxValue)
            {
                await Navigation.PushAsync(new SettingsBudgetPage());
                return;
            }

            await Navigation.PushAsync(new BalanceSheetTabPage());
        }

    }
}
