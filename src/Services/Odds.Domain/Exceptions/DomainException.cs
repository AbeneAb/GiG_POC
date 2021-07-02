using System;

namespace Odds.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        {

        }
        public DomainException(string mesage):base(mesage)
        {

        }
        public DomainException(string message, Exception innerException): base(message, innerException) 
        {

        }
    }
}
