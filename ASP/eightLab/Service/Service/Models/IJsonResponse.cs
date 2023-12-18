using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public interface IJsonResponse
    {
        string Id { get; set; }
        string Jsonrpc { get; set; }
    }
}
