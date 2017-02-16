using Prism.Navigation;
using Prism.Unity;
using PrismApp.Views;
using Xamarin.Forms;

namespace PrismApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var parameters = new NavigationParameters();
            parameters.Add("product", new Product
            {
                Id = 1,
                Name = "ps4"
            });

            NavigationService
                .NavigateAsync("MainPage", parameters);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MDPage>();
            Container.RegisterTypeForNavigation<ViewA>();
            Container.RegisterTypeForNavigation<Navigation>();
            Container.RegisterTypeForNavigation<ViewB>();
        }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
