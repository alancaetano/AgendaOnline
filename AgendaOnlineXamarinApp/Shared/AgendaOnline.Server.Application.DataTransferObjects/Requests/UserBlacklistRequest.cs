using AgendaOnline.Server.Application.DataTransferObjects.Messages;

namespace AgendaOnline.Server.Application.DataTransferObjects.Requests
{
    public class UserBlacklistRequest : RequestBase
    {
    }
    public class UserBlacklistResponse : ResponseBase
    {
        public UserDto[] Blacklist { get; set; }
    }
}