using System.Threading.Tasks;
using AgendaOnline.Client.Droid.Infrastructure;
using AgendaOnline.Client.Model.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceInfo))]

namespace AgendaOnline.Client.Droid.Infrastructure
{
    public class DeviceInfo : IDeviceInfo
    {
        public Task InitAsync()
        {
            return Task.FromResult(false);
        }

        public string Huid { get { return "TODO:HUID"; }}
        public string PushUri { get; private set; }
    }
}
