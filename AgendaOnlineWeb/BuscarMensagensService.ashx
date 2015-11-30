<%@ WebHandler Language="C#" Class="BuscarMensagensService" %>

using System;
using System.Web;
using System.Linq;
using AgendaOnlineAPI.Models;
using AgendaOnlineAPI.Models.VO;
using System.Text;

public class BuscarMensagensService : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {    
        string usuarioLogadoID = context.Request.Params["usuarioLogadoID"];
        string conversaID = context.Request.Params["conversaID"];
        
        Modelo db = new AgendaOnlineAPI.Models.Modelo();
        var mensagens = from msgs in db.mensagem where (msgs.id_conversa.ToString() == conversaID) orderby msgs.id
               select new MensagemVO{ Id = msgs.id, Texto = msgs.texto, DataEnvio = msgs.dt_envio.Value, EhMensagemDoRemetente = msgs.id_usuario.ToString() != usuarioLogadoID};
        
        string templateMensagem = "<div class='row'><div class='col-sm-11'><div class='bubble {0}'>{1}</div></div></div>";

        StringBuilder sb = new StringBuilder();
        
        foreach(MensagemVO vo in mensagens)
        {
            sb.AppendFormat(templateMensagem, vo.EhMensagemDoRemetente ? "you" : "me", vo.Texto);
        }

        context.Response.Write(sb.ToString());       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}