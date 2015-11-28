using AgendaOnline.Server.Application.DataTransferObjects.Messages;

namespace AgendaOnline.Server.Application.DataTransferObjects.Requests
{
    public class UsersSearchRequest : RequestBase
    {
        public string QueryString { get; set; }
    }
    public class UsersSearchResponse : ResponseBase
    {
        public UserDto[] Result { get; set; }
    }
}
