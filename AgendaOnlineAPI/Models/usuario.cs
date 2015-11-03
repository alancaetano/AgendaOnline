namespace AgendaOnlineAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    [Table("usuario")]
    public partial class usuario
    {
        public usuario()
        {
            mensagem = new HashSet<mensagem>();
            conversa = new HashSet<conversa>();
        }

        public Guid id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string senha { get; set; }

        [StringLength(1)]
        public string tipo { get; set; }

        public virtual ICollection<mensagem> mensagem { get; set; }

        public virtual ICollection<conversa> conversa { get; set; }
    }
}
