using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra_Budget_Gamify.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Ultra_Budget_Gamify
{
    public class BalanceSheetPageBase : CustomBaseContentPage
    {
        protected bool SingleInitializeComponentLocker = false;

        public BalanceSheetPageBase()
        {

        }

        #region Virtual Void

        protected virtual void InitializePage()
        {
            SetDatePageWithSingletonGlobalPageState();
            SingleInitializeComponentLocker = true;

        }

        protected virtual void NavigateToSamePageOnDate(DateTime Date)
        {
            CarouselPage Carousel;

            if (GetCarousel() != null) Carousel = GetCarousel();
            else throw new Exception("Carousel == null");

            ContentPage myPage = null ;
            switch (this as BalanceSheetPageBase)
            {
                case DailyBalanceSheetPage1 _:
                    myPage = new DailyBalanceSheetPage1(Carousel, Date);
                    break;
                case WeeklyBalanceSheetPage2 _:
                    myPage = new WeeklyBalanceSheetPage2(Carousel, Date);
                    break;
                case MonthlyBalanceSheetPage3 _:
                    myPage = new MonthlyBalanceSheetPage3(Carousel, Date);
                    break;
                case AnnuallyBalanceSheetPage4 _:
                    myPage = new AnnuallyBalanceSheetPage4(Carousel, Date);
                    break;
                case null:
                    throw new Exception("Switch case error");
            }

            Carousel.Children[GetCurrentPageIndex()] = myPage;

            Carousel.CurrentPage = myPage;

            foreach (ContentPage page in Carousel.Children)
            {
                if (page is BalanceSheetPageBase)
                {
                    (page as BalanceSheetPageBase).RefreshPage();
                }
            }


        }

        #endregion

        #region Virtual Button
        protected async virtual void GoToRecurrentActionButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecurrentActionPage());
        }
        #endregion

        #region Public Method

        public void RefreshPage()
        {
            InitializePage();
        }

        #endregion  

        #region Public Get
        public CarouselPage GetCarousel()
        {
            CarouselPage parentPage = this.Parent as CarouselPage;

            while (parentPage != null && !(parentPage is CarouselPage))
            {
                parentPage = parentPage.Parent as BalanceSheetTabPage;
            }

            // Vérifiez si parentPage est une instance de CarouselPage
            if (parentPage is CarouselPage)
            {
                return parentPage;
            }
            else
            {
                return null;
            }

        }



        public int GetCurrentPageIndex()
        {
            CarouselPage myCarouselPage = GetCarousel();

            Console.WriteLine(myCarouselPage.ToString());

            return GetCarousel().Children.IndexOf(myCarouselPage.CurrentPage); ;
        }

        #endregion

        #region Public Set


        public void SetSingletonGlobalPageState(DateTime Date)
        {
            SingletonGlobalPageState.GetSingleGlobalPageState().CurrentDatePagesProprety = Date;

        }

        public void SetDatePageWithSingletonGlobalPageState()
        {
            DateTime GlobalDate = SingletonGlobalPageState.GetSingleGlobalPageState().CurrentDatePagesProprety;

            if (GlobalDate != DateTime.MinValue)
                DatePagePropreties = GlobalDate;
            else DatePagePropreties = DateTime.Now.Date;
        }

        #endregion

    }
}
