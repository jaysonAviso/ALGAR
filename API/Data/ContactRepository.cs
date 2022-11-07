using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ContactRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Contact> AddContactAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            await _context.Contacts.AddAsync(contact);

            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await GetContactByIdAsync(id);
            if (contact == null)
                return false;
                
            _context.Contacts.Remove(contact);
            return await SaveAllAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            var contactInfo = await GetContactByIdAsync(contact.Id);

            if (contactInfo == null)
                return contactInfo;

            
            contactInfo.LastName = contact.LastName;
            contactInfo.FirstName = contact.FirstName;
            contactInfo.Phone = contact.Phone;
            contactInfo.Email = contact.Email;

            _context.Contacts.Update(contactInfo);
            
            await SaveAllAsync();

            return contactInfo;
        }
    }
}