using Android.Content;
using Android.Telephony;
using AgendaOnline.Client.Droid.Infrastructure;
using AgendaOnline.Client.Model.Contracts;
using AgendaOnline.Client.Model.Entities;
using Xamarin.Forms;

[assembly: Dependency(typeof(InvitationSender))]

namespace AgendaOnline.Client.Droid.Infrastructure
{
    public class InvitationSender : IContactInvitationSender
    {
        public void Send(Contact contact)
        {
            //if (!string.IsNullOrEmpty(contact.Email))
            //{
            //    var email = new Intent(Intent.ActionSend);
            //    email.PutExtra(Intent.ExtraEmail, new[] { contact.Email });
            //    email.PutExtra(Intent.ExtraSubject, "Hey, join me in AgendaOnline!");
            //    email.PutExtra(Intent.ExtraText, "Check this out: https://github.com/EgorBo/AgendaOnline-Xamarin.Forms");
            //    email.SetType("message/rfc822");
            //    Forms.Context.StartActivity(email);
            //}
            SmsManager.Default.SendTextMessage(contact.Number, null, "Check this out: https://github.com/EgorBo/AgendaOnline-Xamarin.Forms", null, null);
        }
    }
}
