using AgendaOnlineAPI.Models;
using AgendaOnlineAPI.Models.VO;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
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
        MensagemVO vo = (MensagemVO)serializer.Deserialize<MensagemVO>(json);

        mensagem msg = new mensagem();
        msg.id = Guid.NewGuid();
        msg.id_usuario = vo.IdUsuario;
        msg.id_conversa = vo.IdConversa;
        msg.texto = vo.Texto;
        msg.dt_envio = DateTime.Now;

        using (Modelo db = new Modelo())
        {
            db.mensagem.Add(msg);
            db.SaveChanges();

            EnviarNotificacao(vo);
        }
       
    }

    public void EnviarNotificacao(MensagemVO vo)
    {
        //notificação push para o app
    }
}

