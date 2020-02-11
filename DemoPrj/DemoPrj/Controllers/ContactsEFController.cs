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
using DemoPrj.Models;

namespace DemoPrj.Controllers
{
    [RoutePrefix("api/ContactsEF")]
    public class ContactsEFController : ApiController
    {
        private ContactContext db = new ContactContext();

        // GET: api/ContactsEF
        [Route("")]
        public IQueryable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        // GET: api/ContactsEF/5
        [ResponseType(typeof(Contact))]
        [Route("{id:int}")]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [Route("{Name}")]
        [HttpGet]
        public IHttpActionResult GetContactByName(string Name)
        {
            //Contact contact = db.Contacts.Find(Name);
            Contact[] contact = db.Contacts.Where<Contact>(c => c.FirstName.Contains(Name)).ToArray<Contact>();

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);


            //Contact[] contactArray = contacts.Where<Contact>(c => c.FirstName.Contains(Name)).ToArray<Contact>();
            //return contactArray;
        }

        // PUT: api/ContactsEF/5
        [ResponseType(typeof(void))]
        [Route("{id:int}")]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
           // contact.ID = 2;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ID)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(contact);
        }

        // POST: api/ContactsEF
        [ResponseType(typeof(Contact))]
        [Route("")]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            return Ok(contact);//CreatedAtRoute("DefaultApi", new { id = contact.ID }, contact);
        }

        // DELETE: api/ContactsEF/5
        [ResponseType(typeof(Contact))]
        [Route("{id:int}")]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.ID == id) > 0;
        }
    }
}