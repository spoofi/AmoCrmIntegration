namespace Spoofi.AmoCrmIntegration.Tests.Config
{
    public static class TestCrmConfig
    {
        private static readonly AmoCrmConfig Config = new AmoCrmConfig("subdomain", "user_login", "user_hash");

        public static AmoCrmConfig Get()
        {
            return Config;
        }
    }
}