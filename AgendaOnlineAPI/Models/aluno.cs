namespace AgendaOnlineAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aluno")]
    public partial class aluno
    {
        public Guid id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        public Guid? id_usuario_responsavel { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
