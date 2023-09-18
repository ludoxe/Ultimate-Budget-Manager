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
        public BalanceSheetTabPage GetCarousel()
        {rentPage != n BalanceSheetTabPage parentPage = this.Parent as BalanceSheetTabPage;

            while (parentPage != null && !(parentPage is CarouselPage))
            {
                parentPage = parentPage.Parent as BalanceSheetTabPage;
            }

            // Vérifiez si parentPage est une instance de CarouselPage
            if (parentPage is CarouselPage carouselPage)
            {
                return parentPage;
            }
            else
            {
                return null;
            }

tPage est une instance de CarouselPage
            if (parentPage is CarouselPage carouselPage)
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
            BalanceSheetTabPage parentPage = GetCarousel();

            if (parentBalanceSheetPageBase)
 MainSheetPage             PageBase GetMaif (this is BalanceSheetPageBase) return this;
            else
            {
                return this.Parent as BalanceSheetPageBase;
            }    if (this is BalanceSheetPageBase) return this;
            else
            {
          hMainSheetPageurn this.Parent as BalanceSBalanceSheetPageBase MainSheetPage
 GetMainSheetPage() 

        p     BalanceSheetPageBase MaiMainSheetge = GetMainSheetPage();

            DatePageProprety = MPageBasetPageSheetePropreGetMainSheetPage    }
        publMainSheetPagehDatePagePropretiesTime DatublDatePagePropretiesithMainSheetPagetDatePagePropreties{
       e)
        {
            BalanceSheetPageBase MainSheetPage = GetMainSheetPage();

            MainSheetPage.DatePageProprety = Date;

        }

        #endregion

    }
}