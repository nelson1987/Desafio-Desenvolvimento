using System;
using System.Runtime.Serialization;

namespace Desafio.Domain.Exceptions
{
    [Serializable]
    public class DomainServiceException : Exception
    {
        public DomainServiceException()
        {
        }

        public DomainServiceException(string message) : base(message)
        {
        }

        public DomainServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}