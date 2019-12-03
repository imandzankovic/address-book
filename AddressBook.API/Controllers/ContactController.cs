using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Core.Services;
using AddressBook.Models.Request.Contact;
using AddressBook.Models.Response.Contact;
using AddressBook.Models.Search.Contact;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;

        }

        /*  [HttpGet]
          public async Task<ActionResult<IEnumerable<ContactResponseModel>>> SearchContacts  ([FromQuery]ContactSearchModel model)
          {
              var contacts = await _contactService.SearchContactsAsync(model);

              return Ok(contacts);
          }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponseModel>>> GetAll()
        {
            var contacts = await _contactService.GetContactsAsync();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResponseModel>> GetById(int id)
        {
            var contact = await _contactService.GetContactById(id);

            return Ok(contact);
        }


        [HttpPost]
        public async Task<ActionResult<ContactResponseModel>> Post([FromBody] ContactRequestModel contact)
        {
            return await _contactService.AddContactAsync(contact);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ContactResponseModel>> Update(int id, [FromBody]  ContactRequestModel contact)
        {
            return await _contactService.UpdateContactAsync(id, contact);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactResponseModel>> Delete(int id)
        {
            return await _contactService.DeactivateContactAsync(id);
        }
    }
}
