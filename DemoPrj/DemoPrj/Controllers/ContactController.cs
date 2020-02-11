using DemoPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoPrj.Controllers
{
    //every method starts with this prefix
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        
        Contact[] contacts = new Contact[]
        {
            new Contact(){ID=0,FirstName="Melric",LastName="Rebello"},
            new Contact(){ID=1,FirstName="Ronson",LastName="Rebello"},
            new Contact(){ID=2,FirstName="Cleona",LastName="Rebello"}
        };
        // GET: api/Contact
        [Route("")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }


       //[Route("{id:int}")]
        // GET: api/Contact/5
        //[Route("{id:int}/lastname/{Name}")] -- for multiple parameters
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(c => c.ID == id);
            if(contact==null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [Route("{Name}")]
        [HttpGet]
        public IEnumerable<Contact> GetContactByName(string Name)
        {
            Contact[] contactArray = contacts.Where<Contact>(c=>c.FirstName.Contains(Name)).ToArray<Contact>();
            return contactArray;
        }

        // POST: api/Contact
        [Route("")]
        public IEnumerable<Contact> Post([FromBody] Contact newContact)
        {
            List<Contact> contactList = contacts.ToList<Contact>();
            newContact.ID = contactList.Count;
            contactList.Add(newContact);
            contacts = contactList.ToArray();
            return contacts;
        }

        // PUT: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Put(int id, [FromBody]Contact ChangedContact)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(c => c.ID == id);
                if(contact !=null)
            {
                contact.FirstName = ChangedContact.FirstName;
                contact.LastName = ChangedContact.LastName;
            }
            return contacts;
        }

        // DELETE: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Delete(int id)
        {
            contacts = contacts.Where<Contact>(c => c.ID != id).ToArray<Contact>();
            return contacts;
        }
    }
}
