using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoUnitTestAPI.Controllers;
using DemoUnitTestAPI.DTO;
using DemoUnitTestAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTestsForDemoAPI.Controllers
{
    /// <summary>
    /// Contact Controller Unit Tests
    /// </summary>
    public class ContactControllerTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetContacts_ReturnsAOkObjectResult_WithAListOfContacts()
        {
            // Arrange
            var mockRepo = new Mock<IContactsRepository>();

            mockRepo.Setup(repo => repo.GetContactsAll())
                .ReturnsAsync(GetTestContacts());

            var mockLogger = new Mock<ILogger<ContactController>>();

            var logger = mockLogger.Object;

            var controller = new ContactController(mockRepo.Object, logger);

            // Act
            var result = await controller.GetContacts();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

            var resultReturned = Assert.IsAssignableFrom<IEnumerable<ContactDto>>(okObjectResult.Value);

            Assert.Equal(5, resultReturned.Count());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<ContactDto> GetTestContacts()
        {
            var contacts = new List<ContactDto>
            {
                new ContactDto()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "1 Main Street",
                    City = "Cuyahoga Falls",
                    StateAbbr = "OH",
                    ZipCode = "44223",
                    PhoneNumber = "111-111-2222"
                },

                new ContactDto()
                {
                    FirstName = "Sarah",
                    LastName = "Silver",
                    Address = "2 Blind Ave",
                    City = "Flint",
                    StateAbbr = "MI",
                    ZipCode = "43012",
                    PhoneNumber = "333-444-5555"
                },

                new ContactDto()
                {
                    FirstName = "Will",
                    LastName = "Burns",
                    Address = "3 Happy Lane",
                    City = "Milton",
                    StateAbbr = "PA",
                    ZipCode = "26034",
                    PhoneNumber = "777-333-2333"
                },

                new ContactDto()
                {
                    FirstName = "Paul",
                    LastName = "Rich",
                    Address = "4 Docker Way",
                    City = "Canton",
                    StateAbbr = "OH",
                    ZipCode = "44234",
                    PhoneNumber = "343-734-8833"
                },

                new ContactDto()
                {
                    FirstName = "Catherine",
                    LastName = "Bailey",
                    Address = "5 Hope Ave",
                    City = "Cleveland",
                    StateAbbr = "OH",
                    ZipCode = "44433",
                    PhoneNumber = "663-343-7489"
                }
            };

            return contacts;
        }
    }
}
