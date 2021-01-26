using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoUnitTestAPI.DTO;
using DemoUnitTestAPI.Entities;

namespace DemoUnitTestAPI.Interfaces
{
    /// <summary>
    /// Interface for Contacts Repository.
    /// </summary>
    public interface IContactsRepository
    {
        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>Return a list of contacts.</returns>
        Task<IEnumerable<ContactDto>> GetContactsAll();
    }
}
