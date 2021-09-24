using System;
using System.Runtime.Serialization;

namespace UserManagementSystemApi.CustomExceptions
{
    [Serializable]
    public class NoDataAvailableException : Exception
    {
        public NoDataAvailableException()
        {
        }

        public NoDataAvailableException(string message) : base(message)
        {
        }

        public NoDataAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoDataAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}