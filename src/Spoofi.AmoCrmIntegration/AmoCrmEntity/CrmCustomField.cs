using System.Collections.Generic;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmCustomField
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<CrmCustomFieldValue> Values { get; set; }
    }

    public class CrmCustomFieldValue
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string @Enum { get; set; }
        public long LastModified { get; set; }
    }
}