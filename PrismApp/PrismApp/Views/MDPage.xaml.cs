using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismApp.Views
{
    public partial class MDPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MDPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation 
            => Device.Idiom != TargetIdiom.Phone;
    }
}