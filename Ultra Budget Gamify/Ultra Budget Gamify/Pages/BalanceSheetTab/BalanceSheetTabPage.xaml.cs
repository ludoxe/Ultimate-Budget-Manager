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
    public partial class BalanceSheetTabPage : CarouselPage
    {
        private DateTime DatePage;
        public BalanceSheetTabPage()
        {
            DatePageProprety = DateTime.Now.Date;
            InitializeComponent();
        }
        public BalanceSheetTabPage(DateTime Date)
        {
            DatePageProprety = Date;
            InitializeComponent();
        }


        public DateTime DatePageProprety { get { return DatePage.Date; } set { DatePage = value; } }

    }
}