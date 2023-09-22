using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
