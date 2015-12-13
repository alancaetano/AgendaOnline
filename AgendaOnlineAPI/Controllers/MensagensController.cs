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
using System.Web.Script.Serialization;
using System.Text;
using AgendaOnlineAPI.Models.VO;

namespace AgendaOnlineAPI.Controllers
{
    public class MensagensController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Mensagens
        public IQueryable GetMensagens(Guid id)
        {
            return from msgs in db.mensagem 
                   where (msgs.id_conversa == id) 
                   select new { id = msgs.id, texto = msgs.texto, dt_envio = msgs.dt_envio, id_usuario = msgs.id_usuario, nomeUsuario = msgs.usuario.nome};
        }

        // POST: api/Mensagens
        [ResponseType(typeof(mensagem))]
        public IHttpActionResult Postmensagem(mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mensagem.Add(mensagem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (mensagemExists(mensagem.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }



            return CreatedAtRoute("DefaultApi", new { id = mensagem.id }, mensagem);
        }

        private void EnviarMensagemParaClienteWeb(MensagemVO msg)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(jss.Serialize(msg)));
            //terminar
            /*foreach (WebSocket s in sockets)
                s.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);*/
        }

        // DELETE: api/Mensagens/5
        [ResponseType(typeof(mensagem))]
        public IHttpActionResult Deletemensagem(Guid id)
        {
            mensagem mensagem = db.mensagem.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            db.mensagem.Remove(mensagem);
            db.SaveChanges();

            return Ok(mensagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mensagemExists(Guid id)
        {
            return db.mensagem.Count(e => e.id == id) > 0;
        }
    }
}