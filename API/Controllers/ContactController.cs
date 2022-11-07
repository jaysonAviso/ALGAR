using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _contactRepository.GetContactsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(ContactDto contactDto)
        {
            return await _contactRepository.AddContactAsync(contactDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContact(Contact contact)
        {
            var contactInfo = await _contactRepository.UpdateContactAsync(contact);

            return Ok(contactInfo);            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            if(await _contactRepository.DeleteContact(id))
                return Ok();

            return BadRequest("Deleting Error");
        }


    }
}