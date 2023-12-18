using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThirdLab.Models;

namespace ThirdLab.Utils
{
    public static class Utility
    {

        public static List<Link> getLinksByMethod(int id)
        {
            List<Link> linkBuffer = new List<Link>();
            linkBuffer.Add(new Link("http://localhost:5000/Home/JSON/Student/" + id.ToString(), "self", "GET"));
            linkBuffer.Add(new Link("http://localhost:5000/Home/JSON/Update?id=" + id.ToString(), "self", "PUT"));
            linkBuffer.Add(new Link("http://localhost:5000/Home/JSON/Delete/" + id, "self", "DELETE"));
            linkBuffer.Add(new Link("http://localhost:5000/Home/JSON/Add/", "self", "POST"));
            return linkBuffer;
        }
        public static List<Link> getStudentListLink()
        {
            List<Link> linkBuffer = new List<Link>();
            linkBuffer.Add(new Link("http://localhost:5000/Home/JSON/Students", "self", "GET"));
            linkBuffer.Add(new Link("http://localhost:5000/Home/XML/Students", "self", "GET"));
            return linkBuffer;
        }
        public static List<Link> errorLinks(string code)
        {
            List<Link> linkBuffer = new List<Link>();
            if (code == "4040")
            {
                linkBuffer.Add(new Link("http://localhost:5000/Error/Index?errorCode=" + code, "self", "GET"));
            }
            return linkBuffer;
        }
    }
}