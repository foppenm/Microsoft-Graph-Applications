using System;

namespace GraphApplications.Core.Exceptions
{
    public class CacheNotFoundException: Exception
    {
        public CacheNotFoundException()
        {
        }

        public CacheNotFoundException(string message)
            : base(message)
        {
        }

        public CacheNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
