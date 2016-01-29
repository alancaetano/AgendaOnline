using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaOnlineAPI.Models.VO
{
    public class MensagemVO
    {
        public string Id { get; set; }

        public string IdUsuario { get; set; }

        public string IdConversa { get; set; }

        public string Texto { get; set; }

        public bool EhMensagemDoRemetente { get; set; }

        public DateTime DataEnvio { get; set; }

    }
}