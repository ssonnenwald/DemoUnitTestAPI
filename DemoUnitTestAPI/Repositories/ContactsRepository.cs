using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoUnitTestAPI.Contexts;
using DemoUnitTestAPI.DTO;
using DemoUnitTestAPI.Entities;
using DemoUnitTestAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoUnitTestAPI.Repositories
{
    /// <summary>
    /// Contacts Repository
    /// </summary>
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext _db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ContactsRepository(ContactsDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>Return a list of contacts.</returns>
        public async Task<IEnumerable<ContactDto>> GetContactsAll()
        {
            var results = await _db.Contacts
                .Select(c => new ContactDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    City = c.City,
                    StateAbbr = c.StateAbbr,
                    ZipCode = c.ZipCode,
                    PhoneNumber = c.PhoneNumber
                })
                .ToListAsync();

            return results;
        }
    }
}
