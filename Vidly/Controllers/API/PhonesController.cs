using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PhoneStore.Models;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class PhonesController : ApiController
    {
        private ApplicationDbContext db;

        public PhonesController()
        {
            db = new ApplicationDbContext();
        }

        // GET: api/Phones
        [HttpGet]
        public IHttpActionResult GetPhones()
        {
            IEnumerable<Phone> phones = db.Phones
                                                                            .Include(p => p.Manufacturer)
                                                                            .Include(p => p.Materials)
                                                                            .Include(p => p.Model)
                                                                            .Include(p => p.OperatingSystem)
                                                                            .ToList();

            return Ok(phones);
        }

        // GET: api/Phones/5
        [ResponseType(typeof(Phone))]
        public IHttpActionResult GetPhone(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        // PUT: api/Phones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhone(int id, Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phone.Id)
            {
                return BadRequest();
            }

            db.Entry(phone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
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

        // POST: api/Phones
        [ResponseType(typeof(Phone))]
        public IHttpActionResult PostPhone(Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phones.Add(phone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phone.Id }, phone);
        }

        // DELETE: api/Phones/5
        [ResponseType(typeof(Phone))]
        public IHttpActionResult DeletePhone(int id)
        {
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return NotFound();
            }

            db.Phones.Remove(phone);
            db.SaveChanges();

            return Ok(phone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.Id == id) > 0;
        }
    }
}