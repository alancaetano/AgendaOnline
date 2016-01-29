/*function conectar(usuarioLogadoID) {
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
    };

    while (socket.readyState == 0) {
        alert(socket.readyState);
    }
    enviarMensagem(usuarioLogadoID, null, null);
}

function carregarMensagens(usuarioLogadoID, conversaID) {
    conversaSelecionada = conversaID;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("scroll-panel-msgs").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "http://" + window.location.host + "/BuscarMensagensService.ashx?usuarioLogadoID=" + usuarioLogadoID + "&conversaID=" + conversaID, true);
    xhttp.send();
}

function enviarMensagem(usuarioLogadoID, conversaID, texto) {
    socket.send(JSON.stringify({ IdUsuario: usuarioLogadoID, IdConversa: conversaID, Texto: texto }));

    if (texto) {
        var balao = "<div class='row'><div class='col-sm-11'><div class='bubble me'>" + texto + "</div></div></div>";
        document.getElementById("scroll-panel-msgs").innerHTML += balao;
        document.getElementById('campo-escrever').value = "";
    }
    
}*/