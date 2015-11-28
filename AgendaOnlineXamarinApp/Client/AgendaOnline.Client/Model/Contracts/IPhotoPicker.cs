using System.Threading.Tasks;

namespace AgendaOnline.Client.Model.Contracts
{
    public interface IPhotoPicker
    {
        Task<byte[]> PickPhoto();
    }
}
