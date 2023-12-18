using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class _Default : Page
    {
        public Simplex simplex;
        protected void Page_Load(object sender, EventArgs e)
        {
            simplex = new Simplex();
        }

        protected void SumButton_Click(object sender, EventArgs e)
        {
            A a1 = new A();
            A a2 = new A();
            a1.s = (FindControl("firstString") as TextBox).Text;
            a1.k = Convert.ToInt32((FindControl("firstInt") as TextBox).Text);
            a1.f = float.Parse((FindControl("firstFloat") as TextBox).Text);

            a2.s = (FindControl("secondString") as TextBox).Text;
            a2.k = Convert.ToInt32((FindControl("secondInt") as TextBox).Text);
            a2.f = float.Parse((FindControl("secondFloat") as TextBox).Text);
            A result = simplex.Sum(a1, a2);
            Label addResult = (FindControl("sumOutput") as Label);
            addResult.Text = "Result\n";
            addResult.Text += "String concat: " + result.s.ToString() + "\n";
            addResult.Text += "Int sum: " + result.k.ToString() + "\n";
            addResult.Text += "Float sum: " + result.f.ToString() + "\n";
            
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32((FindControl("addX") as TextBox).Text);
            int y = Convert.ToInt32((FindControl("addY") as TextBox).Text);
            int result = simplex.Add(x, y);
            Label addResult = (FindControl("addOutput") as Label);
            addResult.Text = "Result: " + result.ToString();
           
        }

        protected void ConcatButton_Click(object sender, EventArgs e)
        {

            string s = (FindControl("concatS") as TextBox).Text;
            double d = Convert.ToDouble((FindControl("concatD") as TextBox).Text);
            string result = simplex.Concat(s, d);
            Label concatResult = (FindControl("concatOutput") as Label);
            concatResult.Text = "Result: " + result.ToString();

        }
    }
}