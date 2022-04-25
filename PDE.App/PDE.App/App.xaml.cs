using System.Threading.Tasks;
using PDE.App.PageModels;
using PDE.App.PageModels.Base;
using PDE.App.Services.Navigation;
using Xamarin.Forms;

namespace PDE.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private Task InitNavigation()
        {
            var navigationService = PageModelLocator.Resolve<INavigationService>();
            return navigationService.NavigateToAsync<LoginPageModel>(null, true);
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
        }
    }
}
