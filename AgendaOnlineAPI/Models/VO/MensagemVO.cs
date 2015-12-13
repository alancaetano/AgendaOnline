using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaOnlineAPI.Models.VO
{
    public class MensagemVO
    {
        public Guid Id { get; set; }

        public Guid IdUsuario { get; set; }

        public Guid IdConversa { get; set; }

        public string Texto { get; set; }

        public bool EhMensagemDoRemetente { get; set; }

        public DateTime DataEnvio { get; set; }

    }
}