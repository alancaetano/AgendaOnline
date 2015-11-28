using AgendaOnline.Client.Seedwork;
using AgendaOnline.Client.Seedwork.Controls;

namespace AgendaOnline.Client.Views
{
    public class HomePage : MvvmableTabbedPage
    {
        public HomePage(ViewModelBase viewModel) : base(viewModel)
        {
            Children.Add(new ChatPage(viewModel));
            Children.Add(new OnlineUsersPage(viewModel));
            Children.Add(new SettingsPage(viewModel));
        }
    }
}
