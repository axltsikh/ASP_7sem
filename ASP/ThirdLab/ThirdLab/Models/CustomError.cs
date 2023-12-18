using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThirdLab.Utils;

namespace ThirdLab.Models
{
    [Serializable]
    public class CustomError
    {
        public CustomError()
        {
            code = "";
            description = "";
            links = new List<Link>();
        }
        public string code { get; set; }
        public string description { get; set; }
        public List<Link> links { get; set; }
        public CustomError(string _code)
        {
            code = _code;
            if(_code=="4040")
            description = "Запрашиваемый ресурс не найден";
            links = Utility.errorLinks(_code);
        }
    }
}