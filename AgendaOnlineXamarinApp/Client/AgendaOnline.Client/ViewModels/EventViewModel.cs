using AgendaOnline.Client.Model.Entities.Messages;
using AgendaOnline.Client.Seedwork;

namespace AgendaOnline.Client.ViewModels
{
    public class EventViewModel : ViewModelBase
    {
        private readonly Event _eventPoco;

        public EventViewModel(Event eventPoco)
        {
            _eventPoco = eventPoco;
        }
    }
}
