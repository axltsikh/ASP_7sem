using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }

        public Error(int _code,string _message)
        {
            code = _code;
            message = _message;
        }
    }
}