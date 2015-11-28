using AgendaOnline.Client.ViewModels;
using AgendaOnline.Client.Views;
using Xamarin.Forms;

namespace AgendaOnline.Client
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new NavigationPage(new SplashscreenPage());
        }
    }
}
