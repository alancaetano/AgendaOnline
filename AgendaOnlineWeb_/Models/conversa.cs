namespace AgendaOnlineWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("conversa")]
    public partial class conversa
    {
        public conversa()
        {
            mensagem = new HashSet<mensagem>();
            usuario = new HashSet<usuario>();
        }

        public Guid id { get; set; }

        [StringLength(1)]
        public string tipo { get; set; }

        public virtual ICollection<mensagem> mensagem { get; set; }

        public virtual ICollection<usuario> usuario { get; set; }
    }
}
