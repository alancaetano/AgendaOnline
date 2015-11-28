using AgendaOnline.Client.Model.Managers;
using AgendaOnline.Client.Seedwork;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendaOnline.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ApplicationManager _appManager;
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginViewModel(ApplicationManager appManager)
        {
            _appManager = appManager;
        }

        public ICommand EntrarCommand
        {
            get { return new Command(Entrar); }
        }

        private async void Entrar()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
                await Notify("Aviso!", "E-mail ou Senha inválidos.");
            else
                await new HomeViewModel(_appManager).ShowAsync();
        }
    }
}