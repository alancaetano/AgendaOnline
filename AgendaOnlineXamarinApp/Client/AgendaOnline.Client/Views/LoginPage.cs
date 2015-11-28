using AgendaOnline.Client.Seedwork;
using AgendaOnline.Client.Seedwork.Controls;
using AgendaOnline.Client.Views.ValueConverters;
using Xamarin.Forms;

namespace AgendaOnline.Client.Views
{
    public class LoginPage : MvvmableContentPage
    {
        public LoginPage(ViewModelBase viewModel) : base(viewModel)
        {
            Label lblLogin = new Label
            {
                Text = "Login",
                Font = Font.BoldSystemFontOfSize(36),
                HorizontalOptions = LayoutOptions.Center
            };

            Button btnLogin = new Button();
            btnLogin.Text = "Entrar";
            btnLogin.SetBinding(IsEnabledProperty, new Binding("IsBusy", converter: new InverterConverter()));
            btnLogin.SetBinding(Button.CommandProperty, new Binding("EntrarCommand"));
            btnLogin.BackgroundColor = Color.Green;
            btnLogin.TextColor = Color.White;

            Entry txtNome = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "E-mail",
            };
            txtNome.SetBinding(Entry.TextProperty, new Binding("Email", BindingMode.TwoWay));

            Entry txtSenha = new Entry
            {
                Keyboard = Keyboard.Text,
                IsPassword = true,
                Placeholder = "Senha",
            };
            txtSenha.SetBinding(Entry.TextProperty, new Binding("Senha", BindingMode.TwoWay));

            //Configura layout para barra de status do iOS.
            Padding = new Thickness(10, Device.OnPlatform(iOS: 20, Android: 0, WinPhone: 0), 10, 5);

            Content = new StackLayout
            {
                Children =
                        {
                            lblLogin,
                            txtNome,
                            txtSenha,
                            btnLogin
                        }
            };
        }
    }
}