using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThirdLab.Utils;

namespace ThirdLab.Models
{
    public class StudentList
    {
        public List<Link> links = new List<Link>();
        public List<Student> students;
        public StudentList(List<Student> _students)
        {
            students = _students;
            links = Utility.getStudentListLink();
        }
        
    }
}