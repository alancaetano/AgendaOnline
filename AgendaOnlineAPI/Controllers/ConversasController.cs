using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgendaOnlineAPI.Models;
using System.Collections;
using AgendaOnlineAPI.Models.VO;

namespace AgendaOnlineAPI.Controllers
{
    public class ConversasController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Conversas
        public IEnumerable GetConversas(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException("Parametro id do usuário está nulo.");

            string queryConsultaListaDeConversas = "select tmp.id_conversa as id, " +
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

            IEnumerable conversas = from conv in db.Database.SqlQuery<ConversaVO>(queryConsultaListaDeConversas, new object[]{ id }) 
                                              select new { id = conv.Id, tipo = conv.Tipo, nomeUsuario = conv.NomeUsuario, ultimaMensagemDataEnvio = conv.UltimaMensagemDataEnvio, ultimaMensagemTexto = conv.UltimaMensagemTexto};

            return conversas;
            
        }

        // POST: api/Conversas
        [ResponseType(typeof(conversa))]
        public IHttpActionResult PostConversa(conversa conversa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.conversa.Add(conversa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (conversaExists(conversa.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = conversa.id }, conversa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool conversaExists(Guid id)
        {
            return db.conversa.Count(e => e.id == id) > 0;
        }

       
    }
}