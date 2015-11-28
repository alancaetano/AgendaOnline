using AgendaOnline.Client.Seedwork;
using AgendaOnline.Client.Seedwork.Controls;
using Xamarin.Forms;

namespace AgendaOnline.Client.Views
{
    public class SettingsPage : MvvmableContentPage
    {
        public SettingsPage(ViewModelBase viewModel) : base(viewModel)
        {
            Title = "Opções";
            Icon = "settings.png";

            var inviteButton = new Button();
            inviteButton.Text = "Invite contacts";
            inviteButton.SetBinding(Button.CommandProperty, new Binding("InviteCommand"));

            Content = new StackLayout
            {
                Children =
                {
                    inviteButton
                }
            };
        }
    }
}