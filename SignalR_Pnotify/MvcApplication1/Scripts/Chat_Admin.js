/// <reference path="jquery-1.7.1.min.js" />
/// <reference path="jquery.signalR-1.0.0-rc1.js" />

$(function () {
    //Classe .net
    var chat = $.connection.chatHub;

    $.connection.hub.start()
        .done(function () {

            $("#enviar").click(function () {
                var title = $("#title").val();
                var message = $("#message").val();

                chat.server.enviarMensagemPublica(title, message);

            });

        });
});