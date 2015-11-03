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

namespace AgendaOnlineAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Usuarios
        public IQueryable GetUsuarios()
        {
            return (from usuarios in db.usuario select new { id = usuarios.id, nome = usuarios.nome, email = usuarios.email, tipo = usuarios.tipo });
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Login(string id)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(id);
                string decodificado = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                string email = decodificado.Split(';')[0];
                string senha = decodificado.Split(';')[1];

                IQueryable<usuario> lista = db.usuario.Where(u => u.email == email && u.senha == senha);

                var usuario = ((from usuarios in db.usuario where (usuarios.email == email && usuarios.senha == senha) select new { id = usuarios.id, nome = usuarios.nome, email = usuarios.email, tipo = usuarios.tipo }).SingleOrDefault());
                if (usuario == null)
                    return NotFound();

                return Ok(usuario);

            }catch
            {
                return NotFound();
            }
        }

        // POST: api/Usuarios
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Postusuario(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuario.Add(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (usuarioExists(usuario.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.id }, usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuarioExists(Guid id)
        {
            return db.usuario.Count(e => e.id == id) > 0;
        }
    }
}