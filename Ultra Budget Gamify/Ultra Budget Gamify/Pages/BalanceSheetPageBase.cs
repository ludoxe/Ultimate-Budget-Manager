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
        {
            BalanceSheetTabPage parentPage = this.Parent as BalanceSheetTabPage;

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

        }

        public int GetCurrentPageIndex()
        {
            return -1;
        }

        #endregion

        #region Public Set

        public void SetMainSheetPageDate(DateTime date)
        {

        }

        public void SetDateWithMainSheetPage()
        {

        }

        #endregion

    }
}