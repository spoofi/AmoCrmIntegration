﻿using System.Linq;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Service;
using Spoofi.AmoCrmIntegration.Tests.Config;
using Xunit;

namespace Spoofi.AmoCrmIntegration.Tests
{
    public class BasicTests
    {
        private readonly IAmoCrmService _service = new AmoCrmService(TestCrmConfig.Get());

        [Fact]
        public void GetAccountInfoTest()
        {
            var accountInfo = _service.GetAccountInfo();
            Assert.NotNull(accountInfo);
            Assert.NotNull(accountInfo.Id);
            Assert.NotNull(accountInfo.Name);
        }

        [Fact]
        public void GetCrmUsersTest()
        {
            var users = _service.GetCrmUsers();
            Assert.NotNull(users);
            Assert.True(users.Any());
        }
    }
}