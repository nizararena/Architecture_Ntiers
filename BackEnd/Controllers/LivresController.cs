using BusinessLayer;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IBusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BackEnd.Controllers
{
    public class LivresController : ApiController
    {
        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ILivreBLL>().ImplementedBy<LivreBLL>());
            return container;
        }
        ILivreBLL context = InitDependency().Resolve<ILivreBLL>();

        // GET: api/Livres
        public IQueryable<Livre> GetLivres()
        {
            try
            {
                return (context.GetLivres());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        // POST: api/Livres
        [ResponseType(typeof(Livre))]

        public async Task<IHttpActionResult> PostLivre(Livre livre)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //utilisation du service
            context.PostLivre(livre);

            return CreatedAtRoute("DefaultApi", new { id = livre.IdLivre }, livre);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}