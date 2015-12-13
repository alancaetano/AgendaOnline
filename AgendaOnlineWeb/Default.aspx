<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src=".\Scripts\chat.js" ></script>
    <script type="text/javascript"> 
        var conversaSelecionada = undefined;
        var socket = undefined;

        conectar();

        paginaCarregada = function () {
            var element = document.getElementById('scroll-panel-msgs');
            element.scrollTop = element.offsetHeight;
        }

        Sys.Application.add_load(paginaCarregada);
    </script>

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-2 painel-usuarios">
                <div class="list-group">
                    <asp:Repeater runat="server" ID="rptConversas">
                        <ItemTemplate>
                            <a class="list-group-item" href="#" onclick="carregarMensagens('<%=Session["usuarioLogadoID"] %>', '<%#Eval("Id")%>')">
                                <h4 class="list-group-item-heading after-header"><%#Eval("NomeAluno")%></h4>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="painel-barra-de-rolagem" id="scroll-panel-msgs">
                </div>
                <div>
                    <div class="row container-enviar-mensagem">
                        <div class="col-lg-10 campo-escrever-mensagem col-xs-14"><input type="text" id="campo-escrever" class="form-control input-lg input-escrever-mensagem col-xs-14"/></div>
                        <div class="col-lg-2"><button type="button" class="btn btn-primary btn-lg botao-enviar" onclick="enviarMensagem('<%=Session["usuarioLogadoID"] %>', conversaSelecionada, document.getElementById('campo-escrever').value)">Enviar</button></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
