using AgendaOnline.Client.Seedwork;
using AgendaOnline.Client.Seedwork.Controls;
using AgendaOnline.Client.Views.Controls;
using Xamarin.Forms;

namespace AgendaOnline.Client.Views
{
    public class ChatPage : MvvmableContentPage
    {
        public ChatPage(ViewModelBase viewModel) : base(viewModel)
        {
            Title = "Mensagens";
            Icon = "chat.png";

            Label lblHeader = new Label();
            lblHeader.Font = Font.BoldSystemFontOfSize(24);
            lblHeader.TextColor = Device.OnPlatform(Color.Green, Color.Yellow, Color.Yellow);
            lblHeader.SetBinding(Label.TextProperty, new Binding("Subject", stringFormat: "  {0}"));

            Button btnEnviar = new Button();
            btnEnviar.Text = "Enviar";
            btnEnviar.VerticalOptions = LayoutOptions.EndAndExpand;
            btnEnviar.SetBinding(Button.CommandProperty, new Binding("SendMessageCommand"));
            ConfiguraBtnEnviarWinPhone(btnEnviar);

            Entry txtMensagem = new Entry();
            txtMensagem.HorizontalOptions = LayoutOptions.FillAndExpand;
            txtMensagem.Keyboard = Keyboard.Chat;
            txtMensagem.Placeholder = "Escreva uma mensagem...";
            txtMensagem.HeightRequest = 30;
            txtMensagem.SetBinding(Entry.TextProperty, new Binding("InputText", BindingMode.TwoWay));

            ChatListView listaMsg = new ChatListView();
            listaMsg.VerticalOptions = LayoutOptions.FillAndExpand;
            //listaMsg.SetBinding(ChatListView.ItemsSourceProperty, new Binding("Events"));
            listaMsg.SetBinding(ChatListView.ItemsSourceProperty, new Binding("Mensagens"));
            listaMsg.ItemTemplate = new DataTemplate(CreateMessageCell);

            Content = new StackLayout
            {
                Padding = Device.OnPlatform(new Thickness(6, 6, 6, 6), new Thickness(0), new Thickness(0)),
                Children =
                {
                    new StackLayout
                    {
                        Children = {txtMensagem, btnEnviar},
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, Device.OnPlatform(0, 20, 0),0,0),
                    },
                    lblHeader,
                    listaMsg,
                }
            };
        }

        private Cell CreateMessageCell()
        {
            Label lblTimeSpan = new Label();
            lblTimeSpan.SetBinding(Label.TextProperty, new Binding("Timestamp", stringFormat: "[{0:HH:mm}]"));
            lblTimeSpan.TextColor = Color.Silver;
            lblTimeSpan.Font = Font.SystemFontOfSize(14);

            Label lblAutor = new Label();
            lblAutor.SetBinding(Label.TextProperty, new Binding("AuthorName", stringFormat: "{0}: "));
            lblAutor.TextColor = Device.OnPlatform(Color.Blue, Color.Yellow, Color.Yellow);
            lblAutor.Font = Font.SystemFontOfSize(14);

            Label lblMensagem = new Label();
            lblMensagem.SetBinding(Label.TextProperty, new Binding("Text"));
            lblMensagem.Font = Font.SystemFontOfSize(14);

            StackLayout stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblAutor, lblMensagem }
            };

            if (Device.Idiom == TargetIdiom.Tablet)
                stack.Children.Insert(0, lblTimeSpan);

            MessageViewCell view = new MessageViewCell { View = stack };
            return view;
        }

        private void ConfiguraBtnEnviarWinPhone(Button btnEnviar)
        {
            if (Device.OS == TargetPlatform.WinPhone)
            {
                btnEnviar.BackgroundColor = Color.Green;
                btnEnviar.BorderColor = Color.Green;
                btnEnviar.TextColor = Color.White;
            }
        }
    }
}