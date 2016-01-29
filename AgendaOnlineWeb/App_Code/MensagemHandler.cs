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
    public static Dictionary<string, WebSocket> sockets;
    
    public override void OnOpen()
    {
        
    }

    public override void OnMessage(string json)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        MensagemVO vo = (MensagemVO)serializer.Deserialize<MensagemVO>(json);

        if (vo.IdConversa.ToString() == string.Empty)
            ArmazenarSocket(vo.IdUsuario.ToString());
        else
            SalvarMensagem(vo);       
    }

    private void ArmazenarSocket(string idUsuario){
        if (sockets == null)
            sockets = new Dictionary<string, WebSocket>();

        WebSocket socket = null;
        sockets.TryGetValue(idUsuario, out socket);
        if (socket != null)
            sockets.Remove(idUsuario);
            
        sockets.Add( idUsuario, this.WebSocketContext.WebSocket);
    }

    private void SalvarMensagem(MensagemVO vo){
        mensagem msg = new mensagem();
        msg.id = Guid.NewGuid();
        msg.id_usuario = new Guid(vo.IdUsuario);
        msg.id_conversa = new Guid(vo.IdConversa);
        msg.texto = vo.Texto;
        msg.dt_envio = DateTime.Now;

        bool ehProfessor = false;

        using (Modelo db = new Modelo())
        {
            db.mensagem.Add(msg);
            db.SaveChanges();

            usuario u = db.usuario.Where(usu => usu.id.ToString() == vo.IdUsuario).FirstOrDefault();
            ehProfessor = u.tipo == "P";

        }

        if (ehProfessor)
            EnviarNotificacao(vo);
        else
            EnviarMensagemNoSocket(vo);
                
    }

    public void EnviarNotificacao(MensagemVO vo)
    {
        //notificação push para o app
    }

    public void EnviarMensagemNoSocket(MensagemVO vo)
    {
        usuario professor = null;
        using (Modelo db = new Modelo())
        {
            conversa c = db.conversa.Find(vo.IdConversa);
            professor = c.usuario.Where(u => u.id.ToString() != vo.IdUsuario).FirstOrDefault();

        }

        WebSocket socket = null;
        sockets.TryGetValue(professor.id.ToString(), out socket);

        ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(vo.Texto));

        socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
    }
}

