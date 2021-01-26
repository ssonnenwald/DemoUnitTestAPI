using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoUnitTestAPI.DTO;
using DemoUnitTestAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoUnitTestAPI.Controllers
{
    /// <summary>
    /// Contact Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactsRepository _contactsRepo;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contactsRepo">The contact repository.</param>
        /// <param name="logger">The logger.</param>
        public ContactController(IContactsRepository contactsRepo, ILogger<ContactController> logger)
        {
            _contactsRepo = contactsRepo;
            _logger = logger;
        }

        /// <summary>
        /// Get the contacts.
        /// </summary>
        /// <returns>Returns a list of contacts.</returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Contact" })]
        [ProducesResponseType(typeof(IEnumerable<ContactDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetContacts()
        {
            List<ContactDto> contacts = new List<ContactDto>();

            try
            {
                contacts = (List<ContactDto>)await _contactsRepo.GetContactsAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error - GetContacts");
            }

            return Ok(contacts);
        }
    }
}
