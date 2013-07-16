using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mic﻿rosoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace MvcApplication1.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public string IdConexao { get; set; }
        
        public void EnviarMensagemPrivada(string nome, string mensagem, string conexao)
        {
            //Clients.All.publicarMensagem(nome, mensagem);
            //Clients.Client(conexao).novaMensagem(nome + " - " + mensagem);
            
            //IdConexao = conexao;
            //Clients.Caller.novaMensagem(nome + " - " + mensagem);
        
        }

        public void EnviarMensagemPublica(string title, string message)
        {
            Clients.All.novaMensagem(title, message);
            //Clients.Client(conexao).publicarMensagem(nome, mensagem);
        }
    }

}