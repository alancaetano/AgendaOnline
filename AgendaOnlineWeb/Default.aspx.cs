using AgendaOnlineAPI.Models;
using AgendaOnlineAPI.Models.VO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private Modelo db = new Modelo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuarioLogadoID"] == null || Session["usuarioLogadoID"].ToString() == string.Empty)
        {
            Response.Redirect("Account/Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
            return;
        }

        string usuarioLogadoID = Session["usuarioLogadoID"].ToString();

        string queryConsultaListaDeConversas = "select tmp.id_conversa as Id, " +
               "tmp.tipo_conversa as Tipo, " +
               "tmp.nome_usuario as NomeUsuario, " +
               "tmp.nome_aluno as NomeAluno, " +
               "msg.dt_envio as UltimaMensagemDataEnvio, " +
               "msg.texto as UltimaMensagemTexto " +
               "from  " +
               "(select c.id as id_conversa,  " +
                  "c.tipo as tipo_conversa, " +
                  "ur.id as id_usuario, " +
                  "ur.nome as nome_usuario, " +
                  "a.nome as nome_aluno," +
                  "MAX(m.id) as ult_msg_id " +
                  "from conversa c " +
                  "join usuario_conversa uc on c.id = uc.id_conversa " +
                  "join usuario ur on uc.id_usuario = ur.id " +
                  "left join mensagem m on m.id_conversa = c.id " +
                  "join aluno a on a.id_usuario_responsavel = ur.id " +
                  "where ur.tipo = 'R' " +
                  "and c.id in(select id_conversa from usuario_conversa where id_usuario = @p0) " +
                  "group by c.id, c.tipo, ur.id, ur.nome, a.nome) as tmp " +
               " left join mensagem msg on msg.id = tmp.ult_msg_id " + 
               " order by msg.dt_envio ";

        IEnumerable lstConversas = from conv in db.Database.SqlQuery<ConversaVO>(queryConsultaListaDeConversas, new object[] { usuarioLogadoID })
                                   select new { Id = conv.Id, 
                                                IdUsuario = conv.IdUsuario,
                                                Tipo = conv.Tipo, 
                                                NomeUsuario = conv.NomeUsuario, 
                                                NomeAluno = conv.NomeAluno, 
                                                UltimaMensagemDataEnvio = conv.UltimaMensagemDataEnvio, 
                                                UltimaMensagemTexto = conv.UltimaMensagemTexto };

        rptConversas.DataSource = lstConversas;
        rptConversas.DataBind();

    }
}