using System;
using System.Runtime.Serialization;

namespace Spoofi.AmoCrmIntegration.Misc
{
    [Serializable]
    public class AmoCrmException : ApplicationException
    {
        public AmoCrmException()
        {
        }

        public AmoCrmException(string message) : base(message)
        {
        }

        public AmoCrmException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AmoCrmException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}