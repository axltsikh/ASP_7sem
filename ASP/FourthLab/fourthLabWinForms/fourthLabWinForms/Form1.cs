using fourthLab;
using System;
using System.Linq;
using System.Windows.Forms;

namespace fourthLabWinForms
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            ServiceReference1.SimplexSoapClient service = new ServiceReference1.SimplexSoapClient();
            ServiceReference1.A a1 = new ServiceReference1.A();
            a1.s = firstString.Text;
            a1.k = Convert.ToInt32(firstInt.Text);
            a1.f = float.Parse(firstFloat.Text);
            ServiceReference1.A a2 = new ServiceReference1.A();
            a2.s = secondString.Text;
            a2.k = Convert.ToInt32(secondInt.Text);
            a2.f = float.Parse(secondFloat.Text);
            
            ServiceReference1.A result = service.Sum(a1, a2);
            addResult.Text = "Result\n";
            addResult.Text += "String concat: " + result.s.ToString() + "\n";
            addResult.Text += "Int sum: " + result.k.ToString() + "\n";
            addResult.Text += "Float sum: " + result.f.ToString() + "\n";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ServiceReference1.SimplexSoapClient service = new ServiceReference1.SimplexSoapClient();
            addLabel.Text = "Result: " + (service.Add(Convert.ToInt32(addX.Text), Convert.ToInt32(addY.Text))).ToString();
        }

        private void concatButton_Click(object sender, EventArgs e)
        {
            ServiceReference1.SimplexSoapClient service = new ServiceReference1.SimplexSoapClient();
            concatLabel.Text = "Result: " + (service.Concat(concatS.Text, Convert.ToDouble(concatD.Text))).ToString();
        }
    }
}
