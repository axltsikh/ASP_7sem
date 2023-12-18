using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fourthLabProxyWinForm
{
    public partial class Form1 : Form
    {
        Simplex simplex = null;
        public Form1()
        {
            InitializeComponent();
            simplex = new Simplex();
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click");
            A a = new A();
            a.s = firstString.Text;
            a.f = float.Parse(firstFloat.Text);
            a.k = Convert.ToInt32(firstInt.Text);
            A b = new A();
            b.s = secondString.Text;
            b.f = float.Parse(secondFloat.Text);
            b.k = Convert.ToInt32(secondInt.Text);
            A result = simplex.Sum(a, b);
            addResult.Text = "Result\n";
            addResult.Text += "String concat: " + result.s.ToString() + "\n";
            addResult.Text += "Float sum: " + result.f.ToString() + "\n";
            addResult.Text += "Int sum: " + result.k.ToString() + "\n";
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            addLabel.Text = "Result: " + (simplex.Add(Convert.ToInt32(addX.Text), Convert.ToInt32(addY.Text))).ToString();
        }

        private void concatButton_Click(object sender, EventArgs e)
        {
            concatLabel.Text = "Result: " + (simplex.Concat(concatS.Text, Convert.ToDouble(concatD.Text))).ToString();
        }
    }
}
