<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> 
        paginaCarregada = function () {
            var element = document.getElementById('scroll-panel');
            element.scrollTop = element.offsetHeight
        }
        Sys.Application.add_load(paginaCarregada);
    </script>

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-2 painel-usuarios">
                <div class="list-group">
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading after-header">Aluno 1</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                    <a href="#" class="list-group-item">
                        <h4 class="list-group-item-heading">Aluno 2</h4>
                    </a>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="painel-barra-de-rolagem" id="scroll-panel">
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Hello there!</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Hi. I'm an expandeable chat box with box shadow. How are you? I expand horizontally and vertically, as you can see here.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble you">Awesome.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Hello there!</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble you">Hi. I'm an expandeable chat box with box shadow. How are you? I expand horizontally and vertically, as you can see here.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Awesome.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Hello there!</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble you">Hi. I'm an expandeable chat box with box shadow. How are you? I expand horizontally and vertically, as you can see here.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Awesome.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Hello there!</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble you">Hi. I'm an expandeable chat box with box shadow. How are you? I expand horizontally and vertically, as you can see here.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Awesome.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Hello there!</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble you">Hi. I'm an expandeable chat box with box shadow. How are you? I expand horizontally and vertically, as you can see here.</div></div></div>
                    <div class="row"><div class="col-sm-11"><div class="bubble me">Awesome.</div></div></div>
                </div>
                <div>
                    <div class="row container-enviar-mensagem">
                        <div class="col-lg-10 campo-escrever-mensagem col-xs-14"><input type="text" class="form-control input-lg input-escrever-mensagem col-xs-14"/></div>
                        <div class="col-lg-2"><button type="button" class="btn btn-primary btn-lg botao-enviar">Enviar</button></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
