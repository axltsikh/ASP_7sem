using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThirdLab.Models
{
    [Serializable]
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }


        [NotMapped]
        public List<Link> studentLinks { get; set; }
        public Student()
        {
            id = 0;
            name = "";
            phone = "";
            studentLinks = new List<Link>();
        }
        public Student(string username,string _phone)
        {
            id = 0;
            name = username;
            phone = _phone;
        }
        public Student(int _id,string _name,string _phone)
        {
            id = _id;
            name = _name;
            phone = _phone;
            studentLinks = new List<Link>();
        }
    }
}