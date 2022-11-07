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
    [ApiController]
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

        [HttpGet("lastname/{lastname}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactByLastname(string lastname)
        {
            return Ok(await _contactRepository.GetContactByLastnameAsync(lastname.ToLower()));
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(ContactDto contactDto)
        {
            
            contactDto.LastName.ToLower();
            return await _contactRepository.AddContactAsync(contactDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, Contact contact)
        {
            var contactInfo = await _contactRepository.UpdateContactAsync(id, contact);
            if (contactInfo == null)
                return NotFound();
                
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