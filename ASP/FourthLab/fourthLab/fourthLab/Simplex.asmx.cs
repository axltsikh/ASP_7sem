using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace fourthLab
{

    [WebService(Namespace = "http://taa/", Description = "Simplex service with Add, AddS, Concat and Sum methods")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(Description = "Сложение чисел", MessageName = "Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "Конкатенация s и d", MessageName = "Concat")]
        public string Concat(string s, double d)
        {
            return (s + d.ToString());
        }

        [WebMethod(Description = "Сложение объектов", MessageName = "Sum")]
        public A Sum(A a1, A a2)
        {
            StreamWriter sw = new StreamWriter("D:/request.txt");
            Stream str = this.Context.Request.InputStream;
            str.Position = 0;
            StreamReader sr = new StreamReader(str);
            string s = sr.ReadToEnd();
            sw.WriteLine(s);
            sw.Close();
            sr.Close();
            A buffer = new A("", 0, 0);
            buffer.s = a1.s + a2.s;
            buffer.f = a1.f + a2.f;
            buffer.k = a1.k + a2.k;
            a1.s += a2.s;
            a1.k += a2.k;
            a1.f += a2.f;
            Console.WriteLine(a1.s);
            return buffer;
        }

        [WebMethod(Description = "Сложение объектов через ajax", MessageName = "AddS")]
        [ScriptMethod(ResponseFormat =ResponseFormat.Json)]
        public string AddS(int x,int y)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return (x + y).ToString();
        }
    }
}

