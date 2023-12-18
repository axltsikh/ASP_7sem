using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        SixthLabModel.SixthLabEntities entities;
        public Form1()
        {
            InitializeComponent();
            entities = new SixthLabModel.SixthLabEntities(new Uri("http://localhost:53920/WcfDataService1.svc/"));
            foreach(var a in entities.Students.AsEnumerable())
            {
                StudentsOutput.Text += a.id + ". " + a.name + "\n";
            }
            foreach(var a in entities.Notes.AsEnumerable())
            {
                NotesOutput.Text += a.id + ". " + a.subject + "\n" + entities.Students.Where(s=>s.id == a.studentId).FirstOrDefault().name + ": " + a.note1 + "\n";
            }
        }
    }
}
