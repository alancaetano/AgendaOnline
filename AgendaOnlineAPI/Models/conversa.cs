namespace AgendaOnlineAPI.Models
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

        public static string queryConsultaListaDeConversas = "select tmp.id_conversa as id, " +
        "tmp.tipo_conversa as tipo, " +
        "tmp.nome_usuario as nomeUsuario, " +
        "msg.dt_envio as ultimaMensagemDataEnvio, " +
        "msg.texto as ultimaMensagemTexto " +
        "from  " +
        "(select c.id as id_conversa,  " +
           "c.tipo as tipo_conversa, " +
           "u.id as id_usuario, " +
           "u.nome as nome_usuario, " +
           "MAX(m.id) as ult_msg_id " +
           "from conversa c " +
           "join usuario_conversa uc on c.id = uc.id_conversa " +
           "join usuario u on uc.id_usuario = u.id " +
           "left join mensagem m on m.id_conversa = c.id " +
           "where u.tipo = 'P' " +
           "and c.id in(select id_conversa from usuario_conversa where id_usuario = @p0) " +
           "group by c.id, c.tipo, u.id, u.nome) as tmp " +
        "left join mensagem msg on msg.id = tmp.ult_msg_id ";
    }

}
