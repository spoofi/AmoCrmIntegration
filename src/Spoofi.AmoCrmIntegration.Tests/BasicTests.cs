using System.Linq;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Service;
using Spoofi.AmoCrmIntegration.Tests.Config;
using Xunit;

namespace Spoofi.AmoCrmIntegration.Tests
{
    public class BasicTests
    {
        private readonly IAmoCrmService _service = new AmoCrmService(TestCrmConfig.Get());
        private const int ContactId = 65682868;

        [Fact]
        public void GetAccountInfoTest()
        {
            var accountInfo = _service.GetAccountInfo();
            Assert.NotNull(accountInfo);
            Assert.NotNull(accountInfo.Id);
            Assert.NotNull(accountInfo.Name);
        }

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
    }
}