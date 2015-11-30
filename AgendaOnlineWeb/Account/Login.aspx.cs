using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using localhost;
using AgendaOnlineAPI.Models;
using System.Linq;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogadoID"] != null && Session["usuarioLogadoID"] != string.Empty)
                Response.Redirect("../Default.aspx");

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                Modelo db = new Modelo();
                var usuario = ((from usuarios in db.usuario where (usuarios.email == UserName.Text && usuarios.senha == Password.Text) select new { id = usuarios.id, nome = usuarios.nome, email = usuarios.email, tipo = usuarios.tipo }).SingleOrDefault());
                if (usuario != null)
                {
                    Session.Add("usuarioLogadoID", usuario.id);
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    FailureText.Text = "E-mail ou senha inválidos.";
                    ErrorMessage.Visible = true;
                }
            }
        }
}