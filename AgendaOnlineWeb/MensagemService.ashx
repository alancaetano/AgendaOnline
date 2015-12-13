<%@ WebHandler Language="C#" Class="MensagemService" %>

using System;
using System.Web;
using Microsoft.Web.WebSockets;

public class MensagemService : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.IsWebSocketRequest)
        {
            context.AcceptWebSocketRequest(new MensagemHandler());
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

