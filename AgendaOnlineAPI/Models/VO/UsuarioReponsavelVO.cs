using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaOnlineAPI.Models.VO
{
    public class UsuarioResponsavelVO
    {
        public Guid Id { get; set; }

        public string NomeResponsavel { get; set; }

        public string NomeAluno { get; set; }

    }
}