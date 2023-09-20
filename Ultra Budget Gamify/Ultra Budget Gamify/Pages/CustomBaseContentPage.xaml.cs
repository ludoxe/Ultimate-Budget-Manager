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
	public abstract partial class CustomBaseContentPage : ContentPage
	{
        #region DynamicPageSettings
        private DateTime DatePage = DateTime.Now;
        private ContentPage CachePage;
        #endregion
        #region Constructor

        public CustomBaseContentPage ()
		{

		}
        #endregion

        #region Public Propreties
        public DateTime DatePagePropreties { get => DatePage; set => DatePage = value.Date; }

        #endregion

        #region public Set

        #endregion
    }
}