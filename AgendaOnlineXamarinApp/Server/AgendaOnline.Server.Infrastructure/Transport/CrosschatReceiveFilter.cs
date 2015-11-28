using System;
using System.Linq;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Infrastructure.Protocol;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;

namespace AgendaOnline.Server.Infrastructure.Transport
{
    public class AgendaOnlineReceiveFilter : FixedHeaderReceiveFilter<BinaryRequestInfo>
    {
        private static readonly CommandParser CommandParser = ServiceLocator.Resolve<CommandParser>();

        public AgendaOnlineReceiveFilter() : base(CommandParser.LengthBytesCount + CommandParser.NameBytesCount) { }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            return CommandParser.ParseBodyLength(header, offset, length);
        }

        protected override BinaryRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            var commandName = CommandParser.ParseCommandName(header.Array.Skip(header.Offset).Take(CommandParser.NameBytesCount).ToArray());
            return new BinaryRequestInfo(commandName.ToString(), bodyBuffer.CloneRange(offset, length));
        }
    }
}
