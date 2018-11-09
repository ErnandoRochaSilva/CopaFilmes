using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWorldCup.WebAPI.Requests
{
    public class DefaultApiResponse
    {
        public string Message { get; private set; }
        public string Info { get; private set; }

        public DefaultApiResponse(string message, string info = null)
        {
            Message = message;
            Info = info;
        }
    }
}