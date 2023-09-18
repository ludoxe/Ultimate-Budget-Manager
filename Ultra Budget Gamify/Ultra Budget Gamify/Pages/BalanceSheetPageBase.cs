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
        private BalanceSheetPageBase MainSheetPage;

        public BalanceSheetPageBase()
        {

        }

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

        public void SetMainSheetPageDate(DateTime date)
        {
            CarouselPage Carousel = GetCarousel();
            BalanceSheetTabPage MainSheetPage;
            Console.WriteLine(this.ToString());
            Console.WriteLine(Carousel.ToString());
            if (Carousel is BalanceSheetTabPage)
            {
                MainSheetPage = Carousel as BalanceSheetTabPage;

                Console.WriteLine(MainSheetPage.ToString());
            }
            else throw new Exception("MainSheetPage is not BalanceSheetTabPage");

            MainSheetPage.DatePageProprety = date;

            Console.WriteLine(date);
        }

        public void SetDateWithMainSheetPage()
        {
            CarouselPage Carousel = GetCarousel();
            BalanceSheetTabPage MainSheetPage;

            Console.WriteLine(this.ToString());
            Console.WriteLine(Carousel.ToString());
            if (Carousel is BalanceSheetTabPage)
            {
                MainSheetPage = Carousel as BalanceSheetTabPage;
                DatePagePropreties = MainSheetPage.DatePageProprety;
            }
            else throw new Exception("MainSheetPage is not BalanceSheetTabPage");

            
        }

        #endregion

    }
}