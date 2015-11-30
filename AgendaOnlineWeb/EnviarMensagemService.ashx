<%@ WebHandler Language="C#" Class="MensagemService" %>

using System;
using System.Web;

public class MensagemService : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //terminar
        /*if (context.IsWebSocketRequest)
            context.AcceptWebSocketRequest(new MensagemHandler());*/
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}