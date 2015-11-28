using AgendaOnline.Client.Model.Contracts;
using AgendaOnline.Client.Model.Managers;
using AgendaOnline.Client.ViewModels;
using AgendaOnline.Server.Application.DataTransferObjects.Enums;
using AgendaOnline.Server.Infrastructure.Protocol;
using Xamarin.Forms;

namespace AgendaOnline.Client.Views
{
    public class SplashscreenPage : ContentPage
    {
        private static ApplicationManager applicationManager;

        public SplashscreenPage()
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label
                    {
                        Text = "Conectando, aguarde...",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Font = Font.BoldSystemFontOfSize(24),
                    },
                    new ActivityIndicator
                    {
                        IsRunning = true
                    }
                }
            };

            //Ajusta layout para barra de status do IPhone.
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
        }

        protected override async void OnAppearing()
        {
            if (applicationManager == null)
            {
                applicationManager = new ApplicationManager(DependencyService.Get<ITransportResource>(), DependencyService.Get<IDtoSerializer>(), DependencyService.Get<IStorage>(), DependencyService.Get<IDeviceInfo>());
                applicationManager.ConnectionManager.ConnectionDropped += () => Navigation.PushAsync(new SplashscreenPage());
            }

            AuthenticationResponseType autenticacao;
            try
            {
                autenticacao = await applicationManager.AccountManager.ValidateAccount();
            }
            catch (System.Exception)
            {
                await DisplayAlert("Aviso!", "Serviço não disponível no momento. Tente novamente mais tarde", "Ok", null);
                return;
            }

            //Se já está autenticado, abre tela principal, senão, envia para tela de login.
            if (autenticacao == AuthenticationResponseType.Success)
                await Navigation.PushAsync(new HomePage(new HomeViewModel(applicationManager)));
            else
                await Navigation.PushAsync(new LoginPage(new LoginViewModel(applicationManager)));

            base.OnAppearing();
        }
    }
}