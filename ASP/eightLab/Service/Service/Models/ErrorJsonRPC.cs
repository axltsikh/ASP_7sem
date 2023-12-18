using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ErrorJsonRPC : IJsonResponse
    {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public Error error { get; set; }

        public ErrorJsonRPC(string id, string json, Error _error)
        {
            Id = id;
            Jsonrpc = json;
            error = _error;
        }
    }
}