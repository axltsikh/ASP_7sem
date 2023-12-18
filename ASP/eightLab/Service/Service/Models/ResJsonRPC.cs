using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ResJsonRPC : IJsonResponse
    {
        public string Method { get; set; }
        public int Result { get; set; }
        public string Id { get; set; }
        public string Jsonrpc { get; set; }

        public ResJsonRPC()
        {
            Id = "";
            Jsonrpc = "";
            Method = "";
            Result = 0;
        }
        public ResJsonRPC(string id, string rpc, string method, int res)
        {
            Id = id;
            Jsonrpc = rpc;
            Method = method;
            Result = res;
        }
    }
}