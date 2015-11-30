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
            Response.Redirect("Account/Login.aspx");

        var responsaveis = (from usuarios in db.aluno where usuarios.usuario.tipo == "R" 
                            select new UsuarioResponsavelVO{ Id = usuarios.usuario.id, NomeResponsavel = usuarios.usuario.nome, NomeAluno = usuarios.nome }).ToList();
        rptUsuarios.DataSource = responsaveis;
        rptUsuarios.DataBind();

    }
}