using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IContactRepository
    {
        void Update(Contact contact);
        Task<bool> SaveAllAsync();
        Task<bool> DeleteContact(int id);
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<Contact> AddContactAsync(ContactDto contactDto);
    }
}