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