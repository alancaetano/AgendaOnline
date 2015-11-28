using AgendaOnline.Client.Model.Entities;

namespace AgendaOnline.Client.Model.Contracts
{
    public interface IContactInvitationSender
    {
        void Send(Contact contact);
    }
}
