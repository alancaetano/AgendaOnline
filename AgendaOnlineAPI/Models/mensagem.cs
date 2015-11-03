namespace AgendaOnlineAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mensagem")]
    public partial class mensagem
    {
        public Guid id { get; set; }

        public Guid id_conversa { get; set; }

        public Guid id_usuario { get; set; }

        [StringLength(50)]
        public string texto { get; set; }

        public DateTime? dt_envio { get; set; }

        public virtual conversa conversa { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
