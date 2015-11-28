using System.Threading.Tasks;
using AgendaOnline.Client.Model.Entities;

namespace AgendaOnline.Client.Model.Contracts
{
    public interface IContactsRepository
    {
        Task<Contact[]> GetAllAsync();
    }
}
