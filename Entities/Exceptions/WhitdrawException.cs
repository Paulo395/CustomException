using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions.Entities.Exceptions
{
    internal class WhitdrawException : Exception
    {
        public WhitdrawException(string message) : base(message)
        {
        }
    }
}
