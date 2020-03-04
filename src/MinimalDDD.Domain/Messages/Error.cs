using System;
using System.Collections.Generic;
using System.Text;

namespace MinimalDDD.Domain
{
    public class Error
    {
        public Error(string pMessage)
        {
            message = pMessage;
        }

        public string message { get; private set; }
    }
}
