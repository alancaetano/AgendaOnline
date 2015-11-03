﻿using System;
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

namespace AgendaOnlineAPI.Controllers
{
    public class ConversasController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Conversas
        public IEnumerable<conversa> GetConversas(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException("Parametro id do usuário está nulo.");

            IEnumerable<conversa> conversas = from conv in db.conversa.SqlQuery(conversa.queryConsultaListaDeConversas, id) 
                                              select new conversa{ id = conv.id, tipo = conv.tipo, nomeUsuario = conv.nomeUsuario, ultimaMensagemDataEnvio = conv.ultimaMensagemDataEnvio, ultimaMensagemTexto = conv.ultimaMensagemTexto};

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