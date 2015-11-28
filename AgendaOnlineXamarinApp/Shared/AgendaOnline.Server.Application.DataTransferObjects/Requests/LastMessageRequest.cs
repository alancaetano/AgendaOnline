using AgendaOnline.Server.Application.DataTransferObjects.Messages;

namespace AgendaOnline.Server.Application.DataTransferObjects.Requests
{
    public class LastMessageRequest : RequestBase { }
    public class LastMessageResponse : ResponseBase
    {
        public string Subject { get; set; }

        public PublicMessageDto[] Messages { get; set; }

        public LastMessageResponse()
        {
            Messages = new PublicMessageDto[2];
            Messages[0] = new PublicMessageDto() { AuthorName = "Fabio", Body = "Olá como vai?" };
        }
    }
}