using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaOnlineAPI.Models.VO
{
    public class ConversaVO
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public string Tipo { get; set; }

        public string NomeUsuario { get; set; }

        public string NomeAluno { get; set; }

        public DateTime UltimaMensagemDataEnvio { get; set; }

        public string UltimaMensagemTexto { get; set; }

    }
}