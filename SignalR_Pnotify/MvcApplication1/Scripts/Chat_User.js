/// <reference path="jquery-1.7.1.min.js" />
/// <reference path="jquery.signalR-1.0.0-rc1.js" />

$(function () {
    //Classe .net
    var chat = $.connection.chatHub;

    // Função chamada em real-time pelo servidor
    chat.client.novaMensagem = function (title, message) {
        
        $.pnotify({
            pnotify_title: title,
            pnotify_text: message,
            pnotify_type: 'notice',
            pnotify_opacity: 1
        });
    };
    $.connection.hub.start();
});