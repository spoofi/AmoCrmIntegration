using System.Collections.Generic;
using System.Linq;
using Spoofi.AmoCrmIntegration.Dtos.Request;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Misc;
using Spoofi.AmoCrmIntegration.Service;
using Spoofi.AmoCrmIntegration.Tests.Config;
using Xunit;

namespace Spoofi.AmoCrmIntegration.Tests
{
    public class ContactsTests
    {
        private const string ContactName = "Геннадий";
        private const int ContactId = 65682868;
        private const int ResponsibleUserId = 144078;
        private readonly IAmoCrmService _service = new AmoCrmService(TestCrmConfig.Get());

        [Fact]
        public void GetAllContactsTest()
        {
            var contacts = _service.GetContacts();
            Assert.True(contacts.Any());
        }

        [Fact]
        public void GetContactByIdTest()
        {
            var contact = _service.GetContact(ContactId);
            Assert.NotNull(contact);
            Assert.Equal(ContactId, contact.Id);
        }

        [Fact]
        public void GetContactsByQueryTest()
        {
            var contacts = _service.GetContacts(ContactName);
            Assert.NotNull(contacts);
            Assert.True(contacts.Any(c => c.Name.Contains(ContactName)));
        }

        [Fact]
        public void GetContactsByResponsibleUserIdTest()
        {
            var contacts = _service.GetContacts(ResponsibleUserId);
            Assert.NotNull(contacts);
            Assert.True(contacts.All(c => c.ResponsibleUserId == ResponsibleUserId));
        }

        [Fact]
        public void CreateContactOnlyWithNameTest()
        {
            var newContact = new AddOrUpdateCrmContact
            {
                Name = "Тестовый контакт"
            };

            var result = _service.AddOrUpdateContact(new AddOrUpdateCrmContacts
            {
                Add = new List<AddOrUpdateCrmContact> {newContact}
            });

            Assert.True(result.Add.Any());
        }

        [Fact]
        public void CreateContactWithEmptyDataThrowsTest()
        {
            Assert.Throws<AmoCrmException>(() => _service.AddOrUpdateContact(null));
        }
    }
}