using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiRest.Controllers
{
    public class DeviseController : ApiController
    {
        private List<Devise> devises = new List<Devise>();

        public DeviseController()
        {
            //Create a list of devise because i don't have a database for the moment
            devises.Add(new Devise() { Id = 1, Nom = "Dollar", Taux =1.08 });
            devises.Add(new Devise() { Id = 2, Nom = "Franc Suisse", Taux = 1.07 });
            devises.Add(new Devise() { Id = 3, Nom = "Yen", Taux = 120 });
        }
        
        // GET: api/Devise
        public IEnumerable<Devise> Get()
        {
            //return all devises
            return devises;
        }

        // GET: api/Devise/5
        [ResponseType(typeof(Devise))]
        public IHttpActionResult Get(int id)
        {
            //find the devise into the lise
            Devise devise = (from d in devises where d.Id == id select d).FirstOrDefault();
            //if null return 404
            if(devise == null)
            {
                return NotFound();
            }
            //else return status 200 with the devise
            return Ok(devise);
        }

        // POST: api/Devise
        [ResponseType(typeof(Devise))]
        public IHttpActionResult Post(Devise devise)
        {
            //if the model post is not corect
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // add the devise to the list
            devises.Add(devise);
            return CreatedAtRoute("DefaultApi", new { id = devise.Id }, devise);
        }

        // PUT: api/Devise/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Devise devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != devise.Id)
            {
                return BadRequest();
            }
            int index = devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Devise/5
        [ResponseType(typeof(Devise))]
        public IHttpActionResult Delete(int id)
        {
            Devise devise = (from d in devises where d.Id == id select d).FirstOrDefault();
            if (devise == null)
            {
                return NotFound();
            }
            else
            {
                devises.Remove(devise);
                return Ok(devise);
            }
        }
    }
}
