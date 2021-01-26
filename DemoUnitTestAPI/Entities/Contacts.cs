﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoUnitTestAPI.Entities
{
    /// <summary>
    /// Contacts Entity
    /// </summary>
    public class Contacts
    {
        /// <summary>
        /// Unique Identifier for the contact.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The first name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The address of the contact.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city of the contact.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state abbreviation of the contact.
        /// </summary>
        public string StateAbbr { get; set; }

        /// <summary>
        /// The zipcode of the contact.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// The phone number of the contact.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
