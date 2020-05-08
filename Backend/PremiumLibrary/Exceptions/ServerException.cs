using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumLibrary.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message)
        {

        }

    }
}
