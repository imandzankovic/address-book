using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Core.Services;
using AddressBook.Models.Response.Contact;
using AddressBook.Models.Search.Contact;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponseModel>>> Get([FromQuery]ContactSearchModel model)
        {
            var contacts = await contactService.GetContactsAsync(model);

            return Ok(contacts);
        }

        
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var contacts = contactService.GetContactById(id);

            return Ok(contacts);
        }

        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
