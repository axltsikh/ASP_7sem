using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ThirdLab.Database;
using ThirdLab.Models;
using ThirdLab.Utils;

namespace ThirdLab.Controllers
{
    public class HomeController:Controller
    {
        StudentContext dbContext = new StudentContext();
        public ActionResult Index()
        {
            
            ViewBag.Students = dbContext.Students;
            foreach (Student a in ViewBag.Students)
            {
                a.studentLinks = Utility.getLinksByMethod(a.id);
            }
            return View();
        }


        [HttpGet]
        public ActionResult Student(int id)
        {
            Student student = dbContext.Students.ToList().Find(item=>item.id==id);
            if (student == null)
            {
                Response.StatusCode = 404;
                CustomError error = new CustomError("4040");
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            student.studentLinks = Utility.getLinksByMethod(id);
            if (HttpContext.Request.Url.AbsoluteUri.Contains("XML")){
                return Content(generateXml(student));
            }
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Students(int limit=-1,int sort=0,int offset=0,int minid = -1,int maxid=-1,string like="",string columns="",string globalike="")
        {
            List<Student> buffer = dbContext.Students.ToList();
            
            foreach(var a in dbContext.Students)
            {
                a.studentLinks = Utility.getLinksByMethod(a.id);
            }
            if (sort != 0)
            {
                buffer = buffer.OrderBy(element => element.name).ToList();
            }
            if (limit > 0)
            {
                buffer = dbContext.Students.Take(limit).ToList();
            }
            if (minid > 0)
            {
                buffer = buffer.Where(element => element.id >= minid).ToList();
            }
            if (maxid > 0)
            {
                buffer = buffer.Where(element => element.id <= maxid).ToList();
            }
            if (like != "")
            {
                buffer = buffer.Where(element => element.name.Contains(like)).ToList();
            }
            if (globalike != "")
            {
                buffer = buffer.Where(element => (element.id + element.name + element.phone).ToString().Contains(globalike)).ToList();
            }
            if (offset > 0)
            {
                buffer = buffer.Skip(offset).ToList();
            }
            if (columns != "")
            {
                if (!columns.Contains("name"))
                {
                    foreach (var a in buffer)
                    {
                        a.name = "";
                    }
                }
                if (!columns.Contains("phone"))
                {
                    foreach (var a in buffer)
                    {
                        a.phone = "";
                    }
                }
                if (!columns.Contains("id"))
                {
                    foreach (var a in buffer)
                    {
                        a.id = 0;
                    }
                }
            }
            
            Response.StatusCode = 200;
            StudentList studentList = new StudentList(buffer);
            if (HttpContext.Request.Url.AbsoluteUri.Contains("XML"))
            {
                return Content(generateListXml(studentList));
            }
           
            return Json(studentList, JsonRequestBehavior.AllowGet);  
        }
        [HttpPost]
        public ActionResult Add(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            Response.StatusCode = 200;
            student.studentLinks = Utility.getLinksByMethod(student.id);
            if (HttpContext.Request.Url.AbsoluteUri.Contains("XML"))
            {
                return Content(generateXml(student));
            }
            return Json(student);
        }
        [HttpPut]
        public ActionResult Update(Student student)
        {
            
            dbContext.Entry(student).State = EntityState.Modified;
            dbContext.SaveChanges();
            Response.StatusCode = 200;
            Student buffer = dbContext.Students.ToList().Find(item => item.id == student.id);
            if (buffer == null)
            {
                Response.StatusCode = 404;
                CustomError error = new CustomError("4040");
                return Json(error);
            }
            buffer.studentLinks = Utility.getLinksByMethod(buffer.id);
            if (HttpContext.Request.Url.AbsoluteUri.Contains("XML"))
            {
                return Content(generateXml(buffer));
            }
            return Json(buffer);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Student buffer = dbContext.Students.ToList().Find(item => item.id == id);
            if (buffer == null)
            {
                Response.StatusCode = 404;
                CustomError error = new CustomError("4040");
                return Json(error);
            }
            buffer.studentLinks = Utility.getLinksByMethod(id);
            dbContext.Entry(buffer).State = EntityState.Deleted;
            dbContext.SaveChanges();
            Response.StatusCode = 200;
            if (HttpContext.Request.Url.AbsoluteUri.Contains("XML"))
            {
                return Content(generateXml(buffer));
            }
            return Json(buffer, JsonRequestBehavior.AllowGet);
        }



        private string generateXml(Student student)
        {
            XDocument xdoc = new XDocument();
            XElement Xstudent = new XElement("Student");
            XElement id = new XElement("id",student.id);
            XElement name = new XElement("name",student.name);
            XElement phone = new XElement("phone",student.phone);
            XElement links = new XElement("links");
            foreach(Link a in student.studentLinks)
            {
                XElement link = new XElement("link");
                XElement href = new XElement("href", a.Href);
                XElement rel = new XElement("rel", a.Rel);
                XElement method = new XElement("method", a.Method);
                link.Add(href);
                link.Add(rel);
                link.Add(method);
                links.Add(link);
            }
            Xstudent.Add(id);
            Xstudent.Add(name);
            Xstudent.Add(phone);
            Xstudent.Add(links);
            xdoc.Add(Xstudent);
            return xdoc.ToString();
        }
        private string generateListXml(StudentList students)
        {

            XDocument xdoc = new XDocument();
            XElement XStudents = new XElement("Students");
            XElement XStudentsList = new XElement("StudentsList");
            XElement XStudentLinks = new XElement("StudentsLinks");
            foreach(Link link in students.links)
            {
                XElement XLink = new XElement("Link");
                XElement href = new XElement("Href",link.Href);
                XElement rel = new XElement("Rel",link.Rel);
                XElement method = new XElement("Method",link.Method);
                XLink.Add(href);
                XLink.Add(rel);
                XLink.Add(method);
                XStudentLinks.Add(XLink);
            }
            foreach(Student student in students.students)
            {
                XElement Xstudent = new XElement("Student");
                XElement id = new XElement("id", student.id);
                XElement name = new XElement("name", student.name);
                XElement phone = new XElement("phone", student.phone);
                XElement links = new XElement("links");
                foreach (Link a in student.studentLinks)
                {
                    XElement link = new XElement("link");
                    XElement href = new XElement("href", a.Href);
                    XElement rel = new XElement("rel", a.Rel);
                    XElement method = new XElement("method", a.Method);
                    link.Add(href);
                    link.Add(rel);
                    link.Add(method);
                    links.Add(link);
                }
                Xstudent.Add(id);
                Xstudent.Add(name);
                Xstudent.Add(phone);
                Xstudent.Add(links);
                XStudentsList.Add(Xstudent);
            }
            XStudents.Add(XStudentLinks);
            XStudents.Add(XStudentsList);
            xdoc.Add(XStudents);
            return xdoc.ToString();
        }
    }
}