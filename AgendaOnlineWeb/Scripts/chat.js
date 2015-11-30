function conectar() {
    var socket = undefined;
    var serviceURL = "";

    if (!window.WebSocket && window.MozWebSocket)
        window.WebSocket = window.MozWebSocket;
    if (!window.WebSocket)
        alert("WebSocket não é suportado pelo seu navergador.");

    socket = new WebSocket(serviceURL);

    socket.onmessage = function (msg) {
        var data = JSON.parse(msg.data);
    };
}

function carregarMensagens(usuarioLogadoID, conversaID) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("scroll-panel-msgs").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "http://"+window.location.host + "/BuscarMensagensService.ashx?usuarioLogadoID="+usuarioLogadoID+"&conversaID="+conversaID, true);
    xhttp.send();
}