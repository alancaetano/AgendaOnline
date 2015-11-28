using AgendaOnline.Server.Application.Contracts;

namespace AgendaOnline.Server.Infrastructure
{
    /// <summary>
    /// </summary>
    public class HardcodedSettings : ISettings
    {
        public bool IsServerBusy { get; private set; }
        public string ServerAddress { get { return "localhost"; } }
        public int ServerPort { get { return GlobalConfig.Port; } }
        public string Subject { get { return "Welcome to AgendaOnline!"; } }
        public int LastMessagesCount { get { return 20; } }
        public int ComposeRandomDuelsEachXSeconds { get { return 5; }}
        public string ImagesLocalFolder { get { return @"C:\inetpub\wwwroot\cc"; } }//
        public int ThumbnailSize { get { return 64; } }
        public int HallOfFameCount { get { return 25; } }
    }
}
