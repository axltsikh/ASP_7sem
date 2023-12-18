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
            addResult.Text += "Float sum: " + result.f.ToString() + "\n";
            addResult.Text += "Int sum: " + result.k.ToString() + "\n";
        }
    }
}