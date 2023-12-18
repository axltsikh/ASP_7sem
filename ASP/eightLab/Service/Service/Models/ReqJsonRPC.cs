using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ReqJsonRPC
    {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public int[] Params { get; set; }
    }
}