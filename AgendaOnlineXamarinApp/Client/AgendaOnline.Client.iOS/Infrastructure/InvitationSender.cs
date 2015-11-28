using AgendaOnline.Client.iOS.Infrastructure;
using AgendaOnline.Client.Model.Contracts;
using AgendaOnline.Client.Model.Entities;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(InvitationSender))]

namespace AgendaOnline.Client.iOS.Infrastructure
{
    public class InvitationSender : IContactInvitationSender
    {
        public void Send(Contact contact)
        {
            var smsTo = NSUrl.FromString("sms:" + contact.Number);
            UIApplication.SharedApplication.OpenUrl(smsTo);
        }
    }
}
