using AgendaOnlineAPI.Models.VO;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for MensagemHandler
/// </summary>
public class MensagemHandler : WebSocketHandler
{
    public static List<WebSocket> sockets;
    public override void OnOpen()
    {
        if (sockets == null)
            sockets = new List<WebSocket>();

        sockets.Add(this.WebSocketContext.WebSocket);
    }

    public override void OnMessage(string json)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        MensagemVO item = serializer.Deserialize<MensagemVO>(json);
        //terminar
        //this.EnviarMensagem();
        
        
    }
}
