<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<script type="text/javascript" src="Scripts\chat.js" ></script>-->
    <script type="text/javascript"> 
        var conversaSelecionada = undefined;
        var socket = undefined;

        paginaCarregada = function () {
            var usuarioID = '<%=Session["usuarioLogadoID"] %>';
            conectar(usuarioID);
            irParaRodape();
        }

        Sys.Application.add_load(paginaCarregada);

        carregarMensagens = function (usuarioLogadoID, conversaID) {
            conversaSelecionada = conversaID;
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (xhttp.readyState == 4 && xhttp.status == 200) {
                    document.getElementById("scroll-panel-msgs").innerHTML = xhttp.responseText;
                    irParaRodape();
                }
            };
            xhttp.open("GET", "http://" + window.location.host + "/BuscarMensagensService.ashx?usuarioLogadoID=" + usuarioLogadoID + "&conversaID=" + conversaID, true);
            xhttp.send();
        }

        enviarMensagem = function (usuarioLogadoID, conversaID, texto) {
            socket.send(JSON.stringify({ IdUsuario: usuarioLogadoID, IdConversa: conversaID, Texto: texto }));

            if (texto) {
                var balao = "<div class='row'><div class='col-sm-11'><div class='bubble me'>" + texto + "</div></div></div>";
                document.getElementById("scroll-panel-msgs").innerHTML += balao;
                document.getElementById('campo-escrever').value = "";
                irParaRodape();
            }
        }

        conectar = function (usuarioLogadoID) {
            var serviceURL = "ws://" + window.location.host + "/MensagemService.ashx";

            if (!window.WebSocket && window.MozWebSocket)
                window.WebSocket = window.MozWebSocket;
            if (!window.WebSocket)
                alert("WebSocket não é suportado pelo seu navergador.");

            socket = new WebSocket(serviceURL);

            socket.onmessage = function (msg) {
                var vo = JSON.parse(msg.data);
                var balao = "<div class='row'><div class='col-sm-11'><div class='bubble you'>" + vo.Texto + "</div></div></div>";
                document.getElementById("scroll-panel-msgs").innerHTML += balao;
                irParaRodape();
            };

            socket.onopen = function () {
                enviarMensagem(usuarioLogadoID, "", "");
            }

            irParaRodape = function () {
                var element = document.getElementById('scroll-panel-msgs');
                element.scrollTop = element.offsetHeight;
            }

        }
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
