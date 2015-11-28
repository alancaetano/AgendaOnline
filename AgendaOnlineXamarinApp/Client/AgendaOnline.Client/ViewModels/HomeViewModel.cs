using System.Collections.ObjectModel;
using System.Windows.Input;
using AgendaOnline.Client.Model.Contracts;
using AgendaOnline.Client.Model.Managers;
using AgendaOnline.Client.Seedwork;
using AgendaOnline.Client.Seedwork.Extensions;
using Xamarin.Forms;
using AgendaOnline.Client.Model.Entities.Messages;
using System;
using System.Collections.Generic;

namespace AgendaOnline.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ApplicationManager appManager;
        private readonly EventViewModelFactory eventViewModelFactory;
        private readonly IPhotoPicker photoPicker;
        private ObservableCollection<UserViewModel> users;
        private ObservableCollection<EventViewModel> events;
        private string inputText;
        private string subject;
        public List<TextMessageViewModel> Mensagens { get; set; }

        public HomeViewModel(ApplicationManager appManager)
        {
            this.appManager = appManager;
            Users = new ObservableCollection<UserViewModel>();
            Events = new ObservableCollection<EventViewModel>();
            eventViewModelFactory = new EventViewModelFactory();
            photoPicker = DependencyService.Get<IPhotoPicker>();
            LoadData();
            
            TextMessage t = new TextMessage();
            t.AuthorName = "Professor Zé";
            t.Body = "Olá pai, seu filho é muito bagunceiro.";
            t.Id = 1;
            t.Timestamp = DateTime.Now;

            TextMessage t2 = new TextMessage();
            t2.AuthorName = "Pai";
            t2.Body = "Vai apanha esse jaguara.";
            t2.Id = 1;
            t2.Timestamp = DateTime.Now;

            TextMessageViewModel tm = new TextMessageViewModel(t, "Zé");
            TextMessageViewModel tm2 = new TextMessageViewModel(t2, "Pai");
            Mensagens = new List<TextMessageViewModel>();
            Mensagens.Add(tm);
            Mensagens.Add(tm2);
        }

        private async void LoadData()
        {
            IsBusy = true;
            await appManager.ChatManager.ReloadChat();
            await appManager.ChatManager.ReloadUsers();
            Subject = appManager.ChatManager.Subject;

            appManager.ChatManager.OnlineUsers.SynchronizeWith(Users, u => new UserViewModel(u));
            appManager.ChatManager.Messages.SynchronizeWith(Events, i => eventViewModelFactory.Get(i, appManager.AccountManager.AccountName));
            IsBusy = false;
        }

        public ObservableCollection<UserViewModel> Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }

        public ObservableCollection<EventViewModel> Events
        {
            get { return events; }
            set { SetProperty(ref events, value); }
        }

        public string InputText
        {
            get { return inputText; }
            set { SetProperty(ref inputText, value); }
        }

        public string Subject
        {
            get { return subject; }
            set { SetProperty(ref subject, value); }
        }

        public ICommand SendMessageCommand
        {
            get { return new Command(OnSendMessage); }
        }

        public ICommand InviteCommand
        {
            get { return new Command(() => new InviteToAppViewModel().ShowAsync()); }
        }

        public ICommand SendImageCommand
        {
            get { return new Command(OnSendImage); }
        }

        private async void OnSendImage()
        {
            var imageData = await photoPicker.PickPhoto();
            IsBusy = true;
            await appManager.ChatManager.SendImage(imageData);
            IsBusy = false;
        }

        private void OnSendMessage()
        {
            if (string.IsNullOrEmpty(InputText))
                return;
            string text = InputText;
            InputText = string.Empty;
            appManager.ChatManager.SendMessage(text);
        }
    }
}
