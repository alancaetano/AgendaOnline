using AgendaOnline.Server.Application.DataTransferObjects.Messages;

namespace AgendaOnline.Server.Application.DataTransferObjects.Requests
{
    public class UserFriendsRequest : RequestBase
    {
    }
    public class UserFriendsResponse : ResponseBase
    {
        public UserDto[] Friends { get; set; }
    }
}