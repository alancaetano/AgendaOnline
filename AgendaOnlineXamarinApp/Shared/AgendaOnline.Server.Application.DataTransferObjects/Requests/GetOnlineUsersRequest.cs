using AgendaOnline.Server.Application.DataTransferObjects.Messages;

namespace AgendaOnline.Server.Application.DataTransferObjects.Requests
{
    public class GetOnlineUsersRequest : RequestBase { }
    public class GetOnlineUsersResponse : ResponseBase
    {
        public UserDto[] Users { get; set; }
    }
}