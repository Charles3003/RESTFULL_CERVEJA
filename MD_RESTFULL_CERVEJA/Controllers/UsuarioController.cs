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
using MD_RESTFULL_NEGOCIO.Negocio;
using MD_RESTFULL_NEGOCIO.Pesistencia;

namespace MD_RESTFULL_CERVEJA.Controllers
{
    public class UsuarioController : ApiController
    {
        private MD_CERVEJA_AGORA db = new MD_CERVEJA_AGORA();

        // GET: api/Usuario
        public IEnumerable<TB_CAD_USUARIO> Get_Pesquiar()
        {
            return db.TB_CAD_USUARIO.ToList();
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(TB_CAD_USUARIO))]
        public IHttpActionResult Get_Pesquiar(int id)
        {
            TB_CAD_USUARIO tB_CAD_USUARIO = db.TB_CAD_USUARIO.Find(id);
            if (tB_CAD_USUARIO == null)
            {
                return NotFound();
            }

            return Ok(tB_CAD_USUARIO);
        }

        [ResponseType(typeof(Autenticar_Usuario_Grid_BD))]
        public IHttpActionResult Get_Autenticar_Usuario(string pEmail, string pSenha)
        {
            try
            {
                using (MD_CERVEJA_AGORA OBD = new MD_CERVEJA_AGORA())
                {
                    Autenticar_Usuario_Grid_BD oDistribuidora = (from d in OBD.TB_CAD_USUARIO

                                                                 where (d.DS_EMAIL == pEmail && d.DS_SENHA == pSenha && d.FL_ATIVO == true)

                                                                 join u in OBD.TB_CAD_DISTRIBUIDORA
                                                                 on d.CD_USUARIO equals u.CD_USUARIO into lf_d
                                                                 from lf_y in lf_d.DefaultIfEmpty()

                                                                 select new Autenticar_Usuario_Grid_BD
                                                                 {
                                                                     Codigo = d.CD_USUARIO,
                                                                     Email = d.DS_EMAIL,
                                                                     E_Distribuidora = true,
                                                                     Imagem = (lf_y == null ? null : lf_y.IMG_LOGO_DISTRIBUIDORA),
                                                                     Nome_Razao_Social = (lf_y == null ? null : lf_y.NM_RAZAO_SOCIAL),
                                                                     Codigo_Perfil = d.CD_PERFIL

                                                                 }).FirstOrDefault();

                    return Ok(oDistribuidora);
                }

            }
            catch
            {
                return null;
            }
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put_Alterar(int id, TB_CAD_USUARIO tB_CAD_USUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_CAD_USUARIO.CD_USUARIO)
            {
                return BadRequest();
            }

            db.Entry(tB_CAD_USUARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_CAD_USUARIOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario
        [ResponseType(typeof(TB_CAD_USUARIO))]
        public IHttpActionResult Post_Inserir(TB_CAD_USUARIO tB_CAD_USUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_CAD_USUARIO.Add(tB_CAD_USUARIO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tB_CAD_USUARIO.CD_USUARIO }, tB_CAD_USUARIO);
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(TB_CAD_USUARIO))]
        public IHttpActionResult Delete_Excluir(int id)
        {
            TB_CAD_USUARIO tB_CAD_USUARIO = db.TB_CAD_USUARIO.Find(id);
            if (tB_CAD_USUARIO == null)
            {
                return NotFound();
            }

            db.TB_CAD_USUARIO.Remove(tB_CAD_USUARIO);
            db.SaveChanges();

            return Ok(tB_CAD_USUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_CAD_USUARIOExists(int id)
        {
            return db.TB_CAD_USUARIO.Count(e => e.CD_USUARIO == id) > 0;
        }
    }
}